using Curveball;

namespace Volt
{
    public class CityBuildingStore : CBGGameObject
    {
        private static CityBuildingStore singleton;

        public CityBuildingModel CityCentrePrefab;
        public CityBuildingModel[] CityBuildingPrefabs;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }

        public static CityBuildingModel GetCityCentrePrefab()
        {
            return singleton.CityCentrePrefab;
        }

        public static CityBuildingModel GetRandomCityBuilding()
        {
            return Curveball.Utilities.SelectRandomlyFromArray(singleton.CityBuildingPrefabs);
        }
    }
}
