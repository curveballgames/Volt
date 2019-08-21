using Curveball;
using UnityEngine;

namespace Volt
{
    public class InGameCamera : TrackballCamera
    {
        public static Camera Camera;

        private void Awake()
        {
            Camera = GetComponentInChildren<Camera>();
        }
    }
}
