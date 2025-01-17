﻿using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class PlayerBuildingManager : CBGGameObject
    {
        public static List<PowerPlant> PowerPlants { get; private set; }

        private static CachedCalculator powerOutputCalculator;
        private static CachedCalculator pollutionCalculator;
        private static CachedCalculator maintenanceCostCalculator;

        private void Awake()
        {
            PowerPlants = new List<PowerPlant>();
            EventSystem.Subscribe<PlayerBuildingPlacedEvent>(OnPlayerBuildingPlaced, this);

            powerOutputCalculator = new CachedCalculator(CalculatePowerOutput);
            pollutionCalculator = new CachedCalculator(CalculatePollutionOutput);
            maintenanceCostCalculator = new CachedCalculator(CalculateMaintenanceCost);
        }

        private void OnDestroy()
        {
            PowerPlants.Clear();
            PowerPlants = null;

            EventSystem.Subscribe<PlayerBuildingPlacedEvent>(OnPlayerBuildingPlaced, this);
        }

        void OnPlayerBuildingPlaced(PlayerBuildingPlacedEvent e)
        {
            if (e.BuildingModel is PowerPlant)
            {
                PowerPlants.Add(e.BuildingModel as PowerPlant);
            }
        }

        public static int GetTotalPowerOutput()
        {
            return powerOutputCalculator.GetCalculation();
        }

        public static int GetTotalPollution()
        {
            return pollutionCalculator.GetCalculation();
        }

        public static int GetTotalMaintenanceCost()
        {
            return maintenanceCostCalculator.GetCalculation();
        }

        private static int CalculatePowerOutput()
        {
            int power = 0;

            foreach (var powerPlant in PowerPlants)
            {
                power += powerPlant.GetPowerOutput();
            }

            return power;
        }

        private static int CalculatePollutionOutput()
        {
            int power = 0;

            foreach (var powerPlant in PowerPlants)
            {
                power += powerPlant.GetPollutionOutput();
            }

            return power;
        }

        private static int CalculateMaintenanceCost()
        {
            int totalCost = 0;

            foreach (var powerPlant in PowerPlants)
            {
                totalCost += powerPlant.GetMaintenanceCost();
            }

            return totalCost;
        }
    }
}
