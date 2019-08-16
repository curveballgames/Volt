using Curveball;
using UnityEngine;

namespace Volt
{
    public class BuildManager : CBGGameObject
    {
        private static int? placementLayerMask;

        private static BuildingModel buildingBeingPlaced;
        private static BuildingIdentifier? lastPlacedType;

        private void Awake()
        {
            buildingBeingPlaced = null;

            if (!placementLayerMask.HasValue)
            {
                placementLayerMask = Curveball.Utilities.GetCollisionMask("Ground", "Water");
            }

            EventSystem.Subscribe<StartConstructionEvent>(OnStartConstruction, this);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<StartConstructionEvent>(OnStartConstruction, this);
        }

        private void Update()
        {
            if (buildingBeingPlaced == null)
            {
                return;
            }

            RaycastHit hitInfo;

            if (Curveball.Utilities.RaycastMousePosition(out hitInfo, placementLayerMask.Value, InGameCamera.Camera))
            {
                int x = Mathf.FloorToInt(hitInfo.point.x);
                int z = Mathf.FloorToInt(hitInfo.point.z);

                buildingBeingPlaced.transform.position = new Vector3(x, 0f, z);

                if (BuildGridManager.CanBuildAt(x, z, buildingBeingPlaced.View.Size))
                {
                    buildingBeingPlaced.View.RenderPlaceable();

                    if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && Input.GetButtonDown("Place"))
                    {
                        PlaceBuilding();
                    }
                }
                else
                {
                    buildingBeingPlaced.View.RenderUnplaceable();
                }
            }
            else
            {
                buildingBeingPlaced.View.RenderUnplaceable();
            }
        }

        void PlaceBuilding()
        {
            if (buildingBeingPlaced == null)
            {
                return;
            }

            int x = (int)buildingBeingPlaced.transform.position.x;
            int z = (int)buildingBeingPlaced.transform.position.z;
            int size = buildingBeingPlaced.View.Size;

            BuildGridManager.OccupyTiles(x, z, size, TileOccupant.PlayerBuilding);

            buildingBeingPlaced.Place();
            buildingBeingPlaced = null;

            if (Input.GetButton("Multiplace") && lastPlacedType.HasValue)
            {
                EventSystem.Publish(new StartConstructionEvent(lastPlacedType.Value));
            }
            else
            {
                lastPlacedType = null;
            }
        }

        void CancelConstruction()
        {
            if (buildingBeingPlaced != null)
            {
                DestroyImmediate(buildingBeingPlaced.gameObject);
            }
        }

        void OnStartConstruction(StartConstructionEvent e)
        {
            CancelConstruction();

            BuildingModel buildingPrefab = BuildingStore.GetBuildingWithIdentifier(e.BuildingIdentifier);
            buildingBeingPlaced = Instantiate(buildingPrefab.gameObject).GetComponent<BuildingModel>();
            lastPlacedType = e.BuildingIdentifier;
        }
    }
}
