using Curveball;
using UnityEngine;

namespace Volt
{
    public class InGameCamera : CBGGameObject
    {
        public static Camera Camera;

        private void Awake()
        {
            Camera = GetComponentInChildren<Camera>();
        }
    }
}
