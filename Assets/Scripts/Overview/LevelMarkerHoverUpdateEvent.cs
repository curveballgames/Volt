using Curveball;

namespace Volt
{
    public struct LevelMarkerHoverUpdateEvent : IEvent
    {
        public LevelMarker levelMarker;

        public LevelMarkerHoverUpdateEvent(LevelMarker levelMarker)
        {
            this.levelMarker = levelMarker;
        }
    }
}