using Curveball;
using TMPro;
using UnityEngine;

namespace Volt
{
    public class TooltipPanel : CBGUIComponent
    {
        public CanvasGroupFader CanvasFader;
        public TextMeshProUGUI Tooltip;

        private Transform trackedObject;

        private void Awake()
        {
            EventSystem.Subscribe<HighlightedBuildingUpdatedEvent>(OnHighlightedBuildingUpdated, this);
        }

        private void LateUpdate()
        {
            if (trackedObject != null)
            {
                RectTransform.position = InGameCamera.Camera.WorldToScreenPoint(trackedObject.position);
            }
        }

        private void OnDestroy()
        {
            trackedObject = null;
            EventSystem.Unsubscribe<HighlightedBuildingUpdatedEvent>(OnHighlightedBuildingUpdated, this);
        }

        void OnHighlightedBuildingUpdated(HighlightedBuildingUpdatedEvent e)
        {
            if (e.Highlighted != null)
            {
                Tooltip.text = Curveball.Utilities.GetNameWithoutClone(e.Highlighted);
                CanvasFader.FadeIn();
                trackedObject = e.Highlighted.transform;
            }
            else
            {
                CanvasFader.FadeOut();
            }
        }
    }
}
