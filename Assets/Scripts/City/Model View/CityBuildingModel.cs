using Curveball;
using UnityEngine;

namespace Volt
{
    public class CityBuildingModel : CBGGameObject
    {
        public int Size;
        public int PowerDrain;

        public void Place()
        {
            int x = Mathf.FloorToInt(transform.position.x);
            int z = Mathf.FloorToInt(transform.position.z);

            BuildGridManager.OccupyTiles(x, z, Size, TileOccupant.CityBuilding);
            EventSystem.Publish(new CityBuildingPlacedEvent(this));
        }

        public int GetPowerDrain()
        {
            return PowerDrain;
        }
    }
}
