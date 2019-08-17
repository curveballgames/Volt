using Curveball;

namespace Volt
{
    public class ChallengePanelManager : CBGUIComponent
    {
        public ChallengePanel[] Panels;

        private void Awake()
        {
            EventSystem.Subscribe<FinishLevelEvent>(OnFinishLevel, this);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<FinishLevelEvent>(OnFinishLevel, this);
        }

        private void Start()
        {
            UpdatePanels();
        }

        private void LateUpdate()
        {
            if (LevelStateManager.LevelFinished || LevelStateManager.Paused)
            {
                return;
            }

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

        void OnFinishLevel(FinishLevelEvent e)
        {
            SetActive(false);
        }
    }
}
