using Curveball;
using UnityEngine;

namespace Volt
{
    public class OverviewCamera : TrackballCamera
    {
        public static Camera Camera;

        private void Awake()
        {
            Camera = GetComponentInChildren<Camera>();
        }
    }
}
