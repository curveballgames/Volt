using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class WeatherStore : CBGGameObject
    {
        private static WeatherStore singleton;
        private static Dictionary<WeatherType, WeatherDefinition> weatherTypeToDefinitionDictionary;

        public WeatherDefinition[] WeatherDefinitions;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            singleton = this;
            CreateWeatherDictionary();
        }

        private void CreateWeatherDictionary()
        {
            weatherTypeToDefinitionDictionary = new Dictionary<WeatherType, WeatherDefinition>();

            foreach (WeatherDefinition definition in WeatherDefinitions)
            {
                weatherTypeToDefinitionDictionary.Add(definition.Type, definition);
            }
        }

        public static WeatherDefinition GetDefinitionForType(WeatherType type)
        {
            return weatherTypeToDefinitionDictionary[type];
        }
    }
}
