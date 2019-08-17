using Curveball;
using TMPro;

namespace Volt
{
    public class ChallengePanel : CBGUIComponent
    {
        public TextMeshProUGUI Label;
        public TextMeshProUGUI Progress;

        public void UpdateForChallenge(ChallengeModel model)
        {
            Label.text = model.Type.ToString();
            Progress.text = string.Format("{0}/{1}", model.Progress, model.Target);
        }
    }
}
