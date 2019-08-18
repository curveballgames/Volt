using Curveball;
using UnityEngine;

namespace Volt
{
    public class BuildManager : CBGGameObject
    {
        private static int? placementLayerMask;

        private static PlayerBuildingModel buildingBeingPlaced;
        private static BuildingIdentifier? lastPlacedType;

        private void Awake()
        {
            buildingBeingPlaced = null;

            if (!placementLayerMask.HasValue)
            {
                placementLayerMask = Curveball.Utilities.GetCollisionMask("Ground", "Water");
            }

            EventSystem.Subscribe<StartConstructionEvent>(OnStartConstruction, this);
            EventSystem.Subscribe<FinishLevelEvent>(OnFinishLevel, this);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<StartConstructionEvent>(OnStartConstruction, this);
            EventSystem.Unsubscribe<FinishLevelEvent>(OnFinishLevel, this);
        }

        private void Update()
        {
            if (buildingBeingPlaced == null || LevelStateManager.LevelFinished || LevelStateManager.Paused)
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

            Vector3 buildingLocation = buildingBeingPlaced.transform.position;

            int x = (int)buildingLocation.x;
            int z = (int)buildingLocation.z;
            int size = buildingBeingPlaced.View.Size;

            BuildGridManager.OccupyTiles(x, z, size, TileOccupant.PlayerBuilding);

            buildingBeingPlaced.Place();
            buildingBeingPlaced = null;

            if (Input.GetButton("Multiplace") && lastPlacedType.HasValue)
            {
                EventSystem.Publish(new StartConstructionEvent(lastPlacedType.Value));
                buildingBeingPlaced.transform.position = buildingLocation;
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

            PlayerBuildingModel buildingPrefab = BuildingStore.GetBuildingWithIdentifier(e.BuildingIdentifier);
            buildingBeingPlaced = Instantiate(buildingPrefab.gameObject).GetComponent<PlayerBuildingModel>();
            lastPlacedType = e.BuildingIdentifier;
        }

        void OnFinishLevel(FinishLevelEvent e)
        {
            CancelConstruction();
        }
    }
}
