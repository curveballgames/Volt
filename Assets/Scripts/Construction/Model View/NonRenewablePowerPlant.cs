using UnityEngine;

namespace Volt
{
    public class NonRenewablePowerPlant : PowerPlant
    {
        public float ConsumptionRate { get; set; }

        public override void Place()
        {
            ConsumptionRate = 1f;
            base.Place();
        }

        public override int GetPowerOutput()
        {
            return Mathf.CeilToInt(MaxPowerOutput * ConsumptionRate);
        }
    }
}
