using Curveball;

namespace Volt
{
    public abstract class PlayerBuildingModel : CBGGameObject
    {
        public int Cost;
        public PlayerBuildingView View;

        public virtual void Place()
        {
            var occupiedArea = Utilities.GetGridReference(transform.position);
            BuildGridManager.OccupyTiles(occupiedArea.X, occupiedArea.Z, View.Size, TileOccupant.PlayerBuilding);

            EventSystem.Publish(new PlayerBuildingPlacedEvent(this));
        }

        public virtual bool CanAfford()
        {
            return Cost <= FundManager.Funds;
        }
    }
}
