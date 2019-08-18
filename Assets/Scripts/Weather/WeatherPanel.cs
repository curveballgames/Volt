using Curveball;
using TMPro;

namespace Volt
{
    public class WeatherPanel : CBGGameObject
    {
        public TextMeshProUGUI WeatherText;

        private void Update()
        {
            WeatherText.text = WeatherManager.CurrentWeatherType.ToString();
        }
    }
}
