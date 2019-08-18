using Curveball;
using UnityEngine;

namespace Volt
{
    public class WeatherManager : CBGGameObject
    {
        private const float WEATHER_CHANGE_TIMEOUT = 20f;

        public static WeatherDefinition CurrentWeather { get => WeatherStore.GetDefinitionForType(CurrentWeatherType); }
        public static WeatherType CurrentWeatherType { get; private set; }

        private static float nextWeatherTimer;

        private void Awake()
        {
            GenerateNewWeather();
            nextWeatherTimer = WEATHER_CHANGE_TIMEOUT;
        }

        private void Update()
        {
            if (LevelStateManager.LevelFinished || LevelStateManager.Paused)
            {
                return;
            }

            nextWeatherTimer -= Time.deltaTime;

            if (nextWeatherTimer <= 0f)
            {
                GenerateNewWeather();
                nextWeatherTimer += WEATHER_CHANGE_TIMEOUT;
            }
        }

        void GenerateNewWeather()
        {
            CurrentWeatherType = Curveball.Utilities.SelectRandomlyFromArray(LevelStore.CurrentLevel.WeatherConditions);
        }

        public static float GetModifierForEnergyType(RenewableEnergyType energyType)
        {
            switch (energyType)
            {
                case RenewableEnergyType.Solar:
                    return CurrentWeather.SunlightModifier;
                case RenewableEnergyType.Wind:
                    return CurrentWeather.WindSpeedModifier;
                case RenewableEnergyType.Tidal:
                    return CurrentWeather.RainModifier; // TODO: should have a minimum, as rain can not be present and tides are legit, or use something else
                default:
                    return 1f;
            }
        }
    }
}
