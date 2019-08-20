using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class CityBuildingManager : CBGGameObject
    {
        private static List<CityBuildingModel> cityBuildings;
        private static CachedCalculator powerDrainCalculator;
        private static CachedCalculator incomeCalculator;

        private void Awake()
        {
            cityBuildings = new List<CityBuildingModel>();
            powerDrainCalculator = new CachedCalculator(CalculateDrain);
            incomeCalculator = new CachedCalculator(CalculateIncome);
            EventSystem.Subscribe<CityBuildingPlacedEvent>(OnCityBuildingPlaced, this);
        }

        private void OnDestroy()
        {
            cityBuildings.Clear();
            cityBuildings = null;

            EventSystem.Unsubscribe<CityBuildingPlacedEvent>(OnCityBuildingPlaced, this);
        }

        void OnCityBuildingPlaced(CityBuildingPlacedEvent e)
        {
            cityBuildings.Add(e.PlacedModel);
        }

        public static int GetTotalDrain()
        {
            return powerDrainCalculator.GetCalculation();
        }

        public static int GetTotalIncome()
        {
            return incomeCalculator.GetCalculation();
        }

        private static int CalculateDrain()
        {
            int totalDrain = 0;

            foreach (CityBuildingModel cityBuilding in cityBuildings)
            {
                totalDrain += cityBuilding.GetPowerDrain();
            }

            return totalDrain;
        }

        private static int CalculateIncome()
        {
            int totalDrain = 0;

            foreach (CityBuildingModel cityBuilding in cityBuildings)
            {
                totalDrain += cityBuilding.GetIncome();
            }

            return totalDrain;
        }
    }
}
