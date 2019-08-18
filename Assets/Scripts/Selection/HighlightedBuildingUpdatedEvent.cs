using Curveball;
using UnityEngine;

namespace Volt
{
    public struct HighlightedBuildingUpdatedEvent : IEvent
    {
        public GameObject Highlighted;

        public HighlightedBuildingUpdatedEvent(GameObject highlighted)
        {
            Highlighted = highlighted;
        }
    }
}