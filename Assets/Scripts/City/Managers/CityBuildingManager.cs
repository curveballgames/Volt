﻿using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class CityBuildingManager : CBGGameObject
    {
        private static List<CityBuildingModel> cityBuildings;
        private static CachedCalculator drainCalculator;

        private void Awake()
        {
            cityBuildings = new List<CityBuildingModel>();
            drainCalculator = new CachedCalculator(CalculateDrain);
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
            return drainCalculator.GetCalculation();
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
    }
}
