using Curveball;

namespace Volt
{
    public class CycleManager : CBGGameObject
    {
        private const float CYCLE_TIME = 20f;

        private Timer cycleTimer;

        private void Start()
        {
            cycleTimer = Timer.CreateTimer(gameObject, Utilities.GetInGameTimerConfig(CYCLE_TIME, OnCycleComplete));
            cycleTimer.Config.Loop = true;
            cycleTimer.Config.AutoDestroy = false;
        }

        void OnCycleComplete()
        {
            EventSystem.Publish(new CycleFinishedEvent());
        }
    }
}
