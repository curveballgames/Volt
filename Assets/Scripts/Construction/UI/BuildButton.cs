using Curveball;
using TMPro;
using UnityEngine.UI;

namespace Volt
{
    public class BuildButton : CBGUIComponent
    {
        public Button Button;
        public TextMeshProUGUI ButtonText;

        public BuildingIdentifier BuildingType
        {
            get => buildingType; set
            {
                buildingType = value;
                ButtonText.text = buildingType.ToString();
            }
        }
        private BuildingIdentifier buildingType;

        private void Awake()
        {
            Button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            EventSystem.Publish(new StartConstructionEvent(BuildingType));
        }
    }
}
