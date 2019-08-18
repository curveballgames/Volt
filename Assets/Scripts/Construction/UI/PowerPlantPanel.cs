using Curveball;
using TMPro;

namespace Volt
{
    public class PowerPlantPanel : CBGUIComponent
    {
        public TextMeshProUGUI PlantNameText;
        public TextMeshProUGUI OutputText;
        public TextMeshProUGUI PollutionText;

        private PowerPlant trackedPlant;

        private void Awake()
        {
            EventSystem.Subscribe<SelectBuildingEvent>(OnSelectBuilding, this);
            Hide();
        }

        private void Update()
        {
            UpdateDetails();
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<SelectBuildingEvent>(OnSelectBuilding, this);
        }

        void UpdateDetails()
        {
            if (trackedPlant == null)
                return;

            PlantNameText.text = Curveball.Utilities.GetNameWithoutClone(trackedPlant.gameObject);
            OutputText.text = string.Format("{0}/{1}", trackedPlant.GetPowerOutput(), trackedPlant.MaxPowerOutput);
            PollutionText.text = string.Format("{0}ppm", trackedPlant.GetPollutionOutput());
        }

        void OnSelectBuilding(SelectBuildingEvent e)
        {
            if (e.Selected == null)
            {
                Hide();
                return;
            }

            PowerPlant powerPlant = e.Selected.GetComponent<PowerPlant>();

            if (gameObject != null)
            {
                Show(powerPlant);
            }
            else
            {
                Hide();
            }
        }

        void Show(PowerPlant powerPlant)
        {
            trackedPlant = powerPlant;
            UpdateDetails();
            SetActive(true);
        }

        void Hide()
        {
            trackedPlant = null;
            SetActive(false);
        }
    }
}
