using Curveball;
using UnityEngine;

namespace Volt
{
    public class LevelStateManager : CBGGameObject
    {
        public static bool Paused { get; private set; }
        public static bool LevelFinished { get; private set; }

        private void Awake()
        {
            EventSystem.Subscribe<FinishLevelEvent>(OnFinishLevel, this);

            Paused = false;
            LevelFinished = false;
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<FinishLevelEvent>(OnFinishLevel, this);
        }

        void OnFinishLevel(FinishLevelEvent e)
        {
            LevelFinished = true;
        }

        // TODO: remove
        public void ForceEnd()
        {
            if (Application.isEditor)
            {
                EventSystem.Publish(new FinishLevelEvent());
            }
        }
    }
}
