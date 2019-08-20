namespace Volt
{
    public abstract class PowerPlant : PlayerBuildingModel
    {
        public int MaxPowerOutput;
        public int BaseMaintenanceCost;

        public abstract int GetPowerOutput();
        public abstract int GetPollutionOutput();
        public abstract int GetMaintenanceCost();
    }
}
