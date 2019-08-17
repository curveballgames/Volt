namespace Volt
{
    public abstract class PowerPlant : PlayerBuildingModel
    {
        public int MaxPowerOutput;

        public abstract int GetPowerOutput();
    }
}
