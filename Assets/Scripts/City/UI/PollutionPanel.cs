using Curveball;
using TMPro;

namespace Volt
{
    public class PollutionPanel : CBGGameObject
    {
        public TextMeshProUGUI PollutionText;

        private void Update()
        {
            PollutionText.text = string.Format("Pollution \t{0}", PollutionManager.GetTotalPollution());
        }
    }
}
