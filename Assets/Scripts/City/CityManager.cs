using System.Collections.Generic;
using Curveball;
using UnityEngine;

namespace Volt
{
    public class CityManager : CBGGameObject
    {
        private const float SECONDS_BETWEEN_BUILDING_SPAWNS = 3f;

        private static HashSet<BuildGridReference> expansionAreas;

        private float spawnTimer;
        private bool startSpawning;

        private void Awake()
        {
            expansionAreas = new HashSet<BuildGridReference>();

            EventSystem.Subscribe<LevelLoadedEvent>(OnLevelLoaded, this);
        }

        private void Update()
        {
            if (!startSpawning)
            {
                return;
            }

            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f)
            {
                spawnTimer += SECONDS_BETWEEN_BUILDING_SPAWNS;
                SpawnNewRandomCityBuilding();
            }
        }

        private void OnDestroy()
        {
            expansionAreas.Clear();
            expansionAreas = null;

            EventSystem.Unsubscribe<LevelLoadedEvent>(OnLevelLoaded, this);
        }

        void OnLevelLoaded(LevelLoadedEvent e)
        {
            CreateBuilding(CityBuildingStore.GetCityCentrePrefab(), new BuildGridReference(0, 0));
            startSpawning = true;
            spawnTimer = SECONDS_BETWEEN_BUILDING_SPAWNS;
        }

        void SpawnNewRandomCityBuilding()
        {
            // TODO: need to find a fit for the tile specified (e.g. if 2x2 and only 1x1 area to build in, go for small building)
            CityBuildingModel randomModel = CityBuildingStore.GetRandomCityBuilding();

            // TODO: definitely inefficient
            List<BuildGridReference> gridRefs = new List<BuildGridReference>(expansionAreas);

            for (int i = 0; i < 20; i++)
            {
                BuildGridReference spawnReference = Curveball.Utilities.SelectRandomlyFromList(gridRefs);

                if (BuildGridManager.CanBuildAt(spawnReference, randomModel.Size))
                {
                    CreateBuilding(randomModel, spawnReference);
                    return;
                }
            }

            // was unable to spawn a building: set spawn timer to 0f to try again next frame
            spawnTimer = 0f;
        }

        void CreateBuilding(CityBuildingModel prefab, BuildGridReference location)
        {
            CityBuildingModel model = Instantiate(prefab, new Vector3(location.X, 0f, location.Z), Quaternion.identity, transform).GetComponent<CityBuildingModel>();
            model.Place();

            UpdateBuildAreas(model);
        }

        void UpdateBuildAreas(CityBuildingModel model)
        {
            BuildGridReference modelGridRef = Utilities.GetGridReference(model.transform.position);
            BuildGridArea gridArea = Utilities.GetArea(modelGridRef, model.Size);

            // remove expansion areas where building is now occupying
            foreach (BuildGridReference gridRef in Utilities.GetGridReferences(modelGridRef.X, modelGridRef.Z, model.Size))
            {
                expansionAreas.Remove(gridRef);
            }

            // add expansion areas in one tile radius (minus corners) around new building
            for (int x = gridArea.MinX; x <= gridArea.MaxX; x++)
            {
                CreateExpansionEntry(new BuildGridReference(x, gridArea.MinZ - 1));
                CreateExpansionEntry(new BuildGridReference(x, gridArea.MaxZ + 1));
            }

            for (int z = gridArea.MinZ; z <= gridArea.MaxZ; z++)
            {
                CreateExpansionEntry(new BuildGridReference(gridArea.MinX - 1, z));
                CreateExpansionEntry(new BuildGridReference(gridArea.MaxX + 1, z));
            }
        }

        void CreateExpansionEntry(BuildGridReference gridRef)
        {
            TileOccupant tileOccupantAtGridRef = BuildGridManager.GetOccupantAtLocation(gridRef);

            // add if anything but a city building, as could destroy a power plant, freeing up space. Will check can place at point of spawn.
            if (tileOccupantAtGridRef != TileOccupant.CityBuilding)
            {
                expansionAreas.Add(gridRef);
            }
        }
    }
}
