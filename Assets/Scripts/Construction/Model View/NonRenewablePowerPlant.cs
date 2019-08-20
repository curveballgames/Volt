using UnityEngine;

namespace Volt
{
    public class NonRenewablePowerPlant : PowerPlant
    {
        public float ConsumptionRate { get; set; }
        public int PollutionRate;
        public int ConsumptionRateCost;

        public override void Place()
        {
            ConsumptionRate = 1f;
            base.Place();
        }

        public override int GetPowerOutput()
        {
            return Mathf.RoundToInt(MaxPowerOutput * ConsumptionRate);
        }

        public override int GetPollutionOutput()
        {
            return Mathf.FloorToInt(PollutionRate * ConsumptionRate);
        }

        public override int GetMaintenanceCost()
        {
            return BaseMaintenanceCost + Mathf.RoundToInt(ConsumptionRateCost * ConsumptionRate);
        }
    }
}
