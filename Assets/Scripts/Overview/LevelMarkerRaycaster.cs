using Curveball;
using UnityEngine;

namespace Volt
{
    public class LevelMarkerRaycaster : CBGGameObject
    {
        private static int levelMarkerLayerMask;

        private void Awake()
        {
            levelMarkerLayerMask = Utilities.GetLayerMaskForAllExcept("Level Marker");
        }

        private void Update()
        {
            RaycastHit hitInfo;

            if (Utilities.RaycastMousePosition(out hitInfo, levelMarkerLayerMask, OverviewCamera.Camera))
            {
                EventSystem.Publish(new LevelMarkerHoverUpdateEvent(hitInfo.collider.GetComponentInChildren<LevelMarker>()));
            }
            else
            {
                EventSystem.Publish(new LevelMarkerHoverUpdateEvent(null));
            }
        }
    }
}
