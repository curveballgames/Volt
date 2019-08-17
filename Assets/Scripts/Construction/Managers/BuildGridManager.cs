using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class BuildGridManager : CBGGameObject
    {
        private static Dictionary<BuildGridReference, TileOccupant> occupiedTiles;

        private void Awake()
        {
            occupiedTiles = new Dictionary<BuildGridReference, TileOccupant>();
        }

        private void OnDestroy()
        {
            occupiedTiles.Clear();
            occupiedTiles = null;
        }

        public static bool CanBuildAt(int x, int z)
        {
            return !occupiedTiles.ContainsKey(new BuildGridReference(x, z));
        }

        public static bool CanBuildAt(int x, int z, int size)
        {
            foreach (BuildGridReference gr in Utilities.GetGridReferences(x, z, size))
            {
                if (!CanBuildAt(gr.X, gr.Z))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CanBuildAt(BuildGridReference gridRef, int size)
        {
            return CanBuildAt(gridRef.X, gridRef.Z, size);
        }

        public static void OccupyTile(int x, int z, TileOccupant occupantType)
        {
            occupiedTiles.Add(new BuildGridReference(x, z), occupantType);
        }

        public static void OccupyTiles(int x, int z, int size, TileOccupant occupantType)
        {
            foreach (BuildGridReference gr in Utilities.GetGridReferences(x, z, size))
            {
                occupiedTiles.Remove(gr);
                occupiedTiles.Add(gr, occupantType);
            }
        }

        public static void OccupyTiles(BuildGridArea area, TileOccupant occupantType)
        {
            OccupyTiles(area.MinX, area.MinZ, area.Size, occupantType);
        }

        public static TileOccupant GetOccupantAtLocation(BuildGridReference gr)
        {
            if (!occupiedTiles.ContainsKey(gr))
            {
                return TileOccupant.Empty;
            }

            return occupiedTiles[gr];
        }
    }
}
