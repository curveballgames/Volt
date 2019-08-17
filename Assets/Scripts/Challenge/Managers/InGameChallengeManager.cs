using Curveball;
using UnityEngine;

namespace Volt
{
    public class InGameChallengeManager : CBGGameObject
    {
        private void Awake()
        {
            for (int i = 0; i < LevelStore.CurrentLevel.Challenges.Length; i++)
            {
                LevelStore.CurrentLevel.Challenges[i].SoftReset();
            }
        }

        private void Update()
        {
            if (LevelStateManager.LevelFinished || LevelStateManager.Paused)
            {
                return;
            }

            bool allChallengesCompleted = true;

            for (int i = 0; i < LevelStore.CurrentLevel.Challenges.Length; i++)
            {
                UpdateChallenge(ref LevelStore.CurrentLevel.Challenges[i]);

                if (!LevelStore.CurrentLevel.Challenges[i].Completed)
                {
                    allChallengesCompleted = false;
                }
            }

            if (allChallengesCompleted)
            {
                EventSystem.Publish(new FinishLevelEvent());
            }
        }

        void UpdateChallenge(ref ChallengeModel model)
        {
            if (model.Completed)
            {
                return;
            }

            switch (model.Type)
            {
                case ChallengeType.PopulationTotal:
                    model.Progress = 0; // TODO
                    break;
                case ChallengeType.PowerOutput:
                    model.Progress = Mathf.Min(PlayerBuildingManager.GetTotalPowerOutput(), model.Target);
                    break;
                case ChallengeType.TotalCash:
                    model.Progress = Mathf.Min(FundManager.Funds, model.Target);
                    break;
            }

            if (model.Completed)
            {
                EventSystem.Publish(new ChallengeCompletedEvent(model));
            }
        }
    }
}
