using Curveball;
using UnityEngine;

namespace Volt
{
    public class BuildButtonPanel : CBGUIComponent
    {
        public BuildButton ButtonPrefab;
        public Transform ButtonParent;

        private void Awake()
        {
            foreach (BuildingIdentifier buildingIdentifier in LevelStore.CurrentLevel.AvailableBuildings)
            {
                CreateButton(buildingIdentifier);
            }
        }

        void CreateButton(BuildingIdentifier buildingIdentifier)
        {
            BuildButton button = Instantiate(ButtonPrefab.gameObject, ButtonParent).GetComponent<BuildButton>();
            button.BuildingType = buildingIdentifier;
        }
    }
}
