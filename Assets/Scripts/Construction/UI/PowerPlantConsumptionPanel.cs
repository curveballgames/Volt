using Curveball;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Volt
{
    public class PowerPlantConsumptionPanel : CBGGameObject
    {
        private const int SLIDER_STEPS = 10;

        public Slider ConsumptionSlider;
        public TextMeshProUGUI ConsumptionText;

        private NonRenewablePowerPlant trackedPlant;

        private void Awake()
        {
            ConsumptionSlider.onValueChanged.AddListener(OnConsumptionSliderChanged);
            ConsumptionSlider.maxValue = SLIDER_STEPS;
            ConsumptionSlider.wholeNumbers = true;
        }

        private void OnDestroy()
        {
            trackedPlant = null;
        }

        public void Configure(NonRenewablePowerPlant powerPlant)
        {
            trackedPlant = powerPlant;
            ConsumptionSlider.value = powerPlant.ConsumptionRate * SLIDER_STEPS;
            UpdateConsumptionText();
        }

        void OnConsumptionSliderChanged(float consumptionValue)
        {
            trackedPlant.ConsumptionRate = consumptionValue / SLIDER_STEPS;
            UpdateConsumptionText();
        }

        void UpdateConsumptionText()
        {
            ConsumptionText.text = string.Format("{0}%", Mathf.RoundToInt(trackedPlant.ConsumptionRate * 100f));
        }
    }
}
