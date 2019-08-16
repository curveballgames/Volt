using Curveball;
using UnityEngine;

namespace Volt
{
    public class CityManager : CBGGameObject
    {
        private void Awake()
        {
            EventSystem.Subscribe<LevelLoadedEvent>(OnLevelLoaded, this);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<LevelLoadedEvent>(OnLevelLoaded, this);
        }

        void OnLevelLoaded(LevelLoadedEvent e)
        {
            CreateBuilding(CityBuildingStore.GetCityCentrePrefab(), Vector3.zero);
        }

        void CreateBuilding(CityBuildingModel prefab, Vector3 location)
        {
            CityBuildingModel model = Instantiate(prefab, location, Quaternion.identity, transform).GetComponent<CityBuildingModel>();
            model.Place();
        }
    }
}
