using Curveball;

namespace Volt
{
    public struct CityBuildingPlacedEvent : IEvent
    {
        public CityBuildingModel PlacedModel;

        public CityBuildingPlacedEvent(CityBuildingModel placedModel)
        {
            PlacedModel = placedModel;
        }
    }
}