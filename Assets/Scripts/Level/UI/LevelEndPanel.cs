using Curveball;
using UnityEngine;
using UnityEngine.UI;

namespace Volt
{
    public class LevelEndPanel : CBGGameObject
    {
        public Button RestartButton;
        public Button ToOverviewButton;
        public CanvasGroup CanvasGroup;

        private void Awake()
        {
            RestartButton.onClick.AddListener(Restart);
            ToOverviewButton.onClick.AddListener(ToOverview);

            EventSystem.Subscribe<FinishLevelEvent>(OnFinishLevel, this);
            Hide();
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<FinishLevelEvent>(OnFinishLevel, this);
        }

        void OnFinishLevel(FinishLevelEvent e)
        {
            Show();
        }

        void Restart()
        {
            EventSystem.Publish(new LoadLevelEvent(LevelStore.CurrentLevelIndex));
        }

        void ToOverview()
        {
            EventSystem.Publish(new ReturnToOverviewEvent());
        }

        void Hide()
        {
            CanvasGroup.alpha = 0f;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }

        void Show()
        {
            CanvasGroup.alpha = 1f;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
        }
    }
}
