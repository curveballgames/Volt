using Curveball;

namespace Volt
{
    public class ChallengePanelManager : CBGUIComponent
    {
        public ChallengePanel[] Panels;

        private void Start()
        {
            UpdatePanels();
        }

        private void LateUpdate()
        {
            UpdatePanels();
        }

        void UpdatePanels()
        {
            var challenges = LevelStore.CurrentLevel.Challenges;

            for (int i = 0; i < Panels.Length; i++)
            {
                if (i >= challenges.Length)
                {
                    Panels[i].SetActive(false);
                }
                else
                {
                    Panels[i].SetActive(true);
                    Panels[i].UpdateForChallenge(challenges[i]);
                }
            }
        }
    }
}
