using Curveball;
using UnityEngine;

namespace Volt
{
    public struct SelectBuildingEvent : IEvent
    {
        public GameObject Selected;

        public SelectBuildingEvent(GameObject selected)
        {
            Selected = selected;
        }
    }
}