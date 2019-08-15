using Curveball;
using UnityEngine.UI;

namespace Volt
{
    public class BuildButton : CBGUIComponent
    {
        public BuildingIdentifier BuildingType;
        public Button Button;

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
