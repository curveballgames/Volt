using Curveball;

namespace Volt
{
    public struct LoadLevelEvent : IEvent
    {
        public int LevelIndex;

        public LoadLevelEvent(int levelIndex)
        {
            LevelIndex = levelIndex;
        }
    }
}