using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class PlayerBuildingManager : CBGGameObject
    {
        public static List<PowerPlant> PowerPlants { get; private set; }

        private static int? totalPower;

        private void Awake()
        {
            PowerPlants = new List<PowerPlant>();
            EventSystem.Subscribe<PlayerBuildingPlacedEvent>(OnPlayerBuildingPlaced, this);
        }

        private void OnDestroy()
        {
            PowerPlants.Clear();
            PowerPlants = null;

            EventSystem.Subscribe<PlayerBuildingPlacedEvent>(OnPlayerBuildingPlaced, this);
        }

        private void LateUpdate()
        {
            totalPower = null;
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
            if (totalPower.HasValue)
            {
                return totalPower.Value;
            }

            totalPower = 0;

            foreach (PowerPlant pp in PowerPlants)
            {
                totalPower += pp.GetPowerOutput();
            }

            return totalPower.Value;
        }
    }
}
