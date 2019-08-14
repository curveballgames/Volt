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
    }
}
