using UnityEngine;

namespace Volt
{
    public class RenewablePowerPlant : PowerPlant
    {
        public RenewableEnergyType EnergyType;

        public override int GetPowerOutput()
        {
            float modifier = WeatherManager.GetModifierForEnergyType(EnergyType);
            return Mathf.CeilToInt(MaxPowerOutput * modifier);
        }
    }
}
