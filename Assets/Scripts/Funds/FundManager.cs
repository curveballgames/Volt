using Curveball;
using UnityEngine;

namespace Volt
{
    public class FundManager : CBGGameObject
    {
        public static int Funds { get; private set; }

        private void Awake()
        {
            Funds = LevelStore.CurrentLevel.StartingFunds;

            EventSystem.Subscribe<PlayerBuildingPlacedEvent>(OnPlayerBuildingPlaced, this);
            EventSystem.Subscribe<CycleFinishedEvent>(OnCycleFinished, this);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<PlayerBuildingPlacedEvent>(OnPlayerBuildingPlaced, this);
            EventSystem.Unsubscribe<CycleFinishedEvent>(OnCycleFinished, this);
        }

        void OnPlayerBuildingPlaced(PlayerBuildingPlacedEvent e)
        {
            Funds -= e.BuildingModel.Cost;
        }

        void OnCycleFinished(CycleFinishedEvent e)
        {
            AddFunds(GetCashflow());
        }

        public static void AddFunds(int funds)
        {
            if (funds <= 0)
            {
                Debug.LogWarning("Tried to add non-positive funds: " + funds);
                return;
            }

            Funds += funds;
        }

        public static void RemoveFunds(int funds)
        {
            if (funds <= 0)
            {
                Debug.LogWarning("Tried to remove non-positive funds: " + funds);
                return;
            }

            Funds -= funds;
        }

        public static int GetCashflow()
        {
            return PlayerBuildingManager.GetTotalMaintenanceCost() * -1 + CityBuildingManager.GetTotalIncome();
        }
    }
}
