using Curveball;
using UnityEngine;

namespace Volt
{
    public class LevelMarkerClickHandler : CBGGameObject
    {
        private LevelMarker hoveredMarker;

        private void Awake()
        {
            EventSystem.Subscribe<LevelMarkerHoverUpdateEvent>(OnLevelMarkerHoverUpdated, this);
        }

        private void Update()
        {
            if (hoveredMarker != null && Input.GetButton("Select"))
            {
                EventSystem.Publish(new LoadLevelEvent(hoveredMarker.LinkedLevelIndex));
            }
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<LevelMarkerHoverUpdateEvent>(OnLevelMarkerHoverUpdated, this);
        }

        void OnLevelMarkerHoverUpdated(LevelMarkerHoverUpdateEvent e)
        {
            hoveredMarker = e.levelMarker;
        }
    }
}
