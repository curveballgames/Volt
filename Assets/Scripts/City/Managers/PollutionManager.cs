using Curveball;

namespace Volt
{
    public class PollutionManager : CBGGameObject
    {
        private static CachedCalculator pollutionCalculator;

        private void Awake()
        {
            pollutionCalculator = new CachedCalculator(CalculateTotalPollution);
        }

        public static int GetTotalPollution()
        {
            return pollutionCalculator.GetCalculation();
        }

        private static int CalculateTotalPollution()
        {
            int pollution = 0;

            pollution += PlayerBuildingManager.GetTotalPollution();

            return pollution;
        }
    }
}
