using UnityEngine;

namespace Volt
{
    [CreateAssetMenu(fileName = "Weather", menuName = "Volt/Weather Definition")]
    public class WeatherDefinition : ScriptableObject
    {
        public WeatherType Type;
        public float WindSpeedModifier;
        public float RainModifier;
        public float SunlightModifier;
    }
}
