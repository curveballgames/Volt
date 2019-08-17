using Curveball;

namespace Volt
{
    public struct PlayerBuildingPlacedEvent : IEvent
    {
        public PlayerBuildingModel BuildingModel;

        public PlayerBuildingPlacedEvent(PlayerBuildingModel buildingModel)
        {
            BuildingModel = buildingModel;
        }
    }
}