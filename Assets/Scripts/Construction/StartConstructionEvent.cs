using Curveball;

namespace Volt
{
    public struct StartConstructionEvent : IEvent
    {
        public BuildingIdentifier BuildingIdentifier;

        public StartConstructionEvent(BuildingIdentifier buildingIdentifier)
        {
            BuildingIdentifier = buildingIdentifier;
        }
    }
}