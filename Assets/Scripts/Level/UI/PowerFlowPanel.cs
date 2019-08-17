using Curveball;
using Curveball.Strategy;
using TMPro;

namespace Volt
{
    public class PowerFlowPanel : CBGUIComponent
    {
        // TODO: this should be moved out!
        private static readonly float SURGE_OR_CUT_STANDARD_DEVIATION = 40f;
        private static readonly float HALF_STANDARD_DEVIATION = SURGE_OR_CUT_STANDARD_DEVIATION / 2f;

        public Healthbar PowerFlowBar;
        public TextMeshProUGUI DrainText;
        public TextMeshProUGUI PowerText;

        private void Awake()
        {
            PowerFlowBar.MaxValue = SURGE_OR_CUT_STANDARD_DEVIATION;
            EventSystem.Subscribe<FinishLevelEvent>(OnFinishLevel, this);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<FinishLevelEvent>(OnFinishLevel, this);
        }

        void OnFinishLevel(FinishLevelEvent e)
        {
            SetActive(false);
        }

        private void Update()
        {
            if (LevelStateManager.LevelFinished || LevelStateManager.Paused)
            {
                return;
            }

            float powerOutput = PlayerBuildingManager.GetTotalPowerOutput();
            float powerDrain = CityBuildingManager.GetTotalDrain();

            PowerText.text = powerOutput.ToString();
            DrainText.text = powerDrain.ToString();

            if (powerDrain == 0)
            {
                PowerFlowBar.Value = HALF_STANDARD_DEVIATION;
            }
            else
            {
                float totalPower = powerOutput - powerDrain;
                PowerFlowBar.Value = totalPower + HALF_STANDARD_DEVIATION;
            }
        }
    }
}
