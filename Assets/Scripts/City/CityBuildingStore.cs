using Curveball;

namespace Volt
{
    public class CityBuildingStore : CBGGameObject
    {
        private static CityBuildingStore singleton;

        public CityBuildingModel CityCentrePrefab;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }

        public static CityBuildingModel GetCityCentrePrefab()
        {
            return singleton.CityCentrePrefab;
        }
    }
}
