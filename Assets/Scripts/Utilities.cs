using Curveball;
using UnityEngine;

namespace Volt
{
    public class Utilities : CBGGameObject
    {
        public static BuildGridReference GetGridReference(Vector3 location)
        {
            return new BuildGridReference(
                Mathf.FloorToInt(location.x),
                Mathf.FloorToInt(location.z)
            );
        }
    }
}
