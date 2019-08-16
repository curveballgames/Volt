using Curveball;
using UnityEngine;

namespace Volt
{
    public class LevelMarkerRaycaster : CBGGameObject
    {
        private static int levelMarkerLayerMask;

        private void Awake()
        {
            levelMarkerLayerMask = Curveball.Utilities.GetLayerMaskForAllExcept("Level Marker");
        }

        private void Update()
        {
            RaycastHit hitInfo;

            if (Curveball.Utilities.RaycastMousePosition(out hitInfo, levelMarkerLayerMask, OverviewCamera.Camera))
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
