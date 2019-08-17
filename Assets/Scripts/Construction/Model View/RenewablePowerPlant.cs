namespace Volt
{
    public class RenewablePowerPlant : PowerPlant
    {
        public RenewableEnergyType EnergyType;

        public override int GetPowerOutput()
        {
            // TODO: calculate based on EnergyType (need other managers for this)
            // e.g. float modifier = WeatherManager.GetModifierForEnergyType(EnergyType);
            return MaxPowerOutput;
        }
    }
}
