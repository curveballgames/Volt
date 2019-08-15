using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class BuildGridManager : CBGGameObject
    {
        private static HashSet<BuildGridReference> availableTiles;

        private void Awake()
        {
            availableTiles = new HashSet<BuildGridReference>();
        }

        private void OnDestroy()
        {
            availableTiles.Clear();
            availableTiles = null;
        }

        public static bool CanBuildAt(int x, int z)
        {
            return availableTiles.Contains(new BuildGridReference(x, z));
        }

        public static bool CanBuildAt(int x, int z, int size)
        {
            foreach (BuildGridReference gr in GetGridReferences(x, z, size))
            {
                if (!CanBuildAt(gr.X, gr.Z))
                {
                    return false;
                }
            }

            return true;
        }

        public static void OccupyTile(int x, int z)
        {
            availableTiles.Remove(new BuildGridReference(x, z));
        }

        public static void OccupyTiles(int x, int z, int size)
        {
            foreach (BuildGridReference gr in GetGridReferences(x, z, size))
            {
                availableTiles.Remove(gr);
            }
        }

        public static void MakeTileAvailable(int x, int z)
        {
            availableTiles.Add(new BuildGridReference(x, z));
        }

        private static List<BuildGridReference> GetGridReferences(int x, int z, int size)
        {
            List<BuildGridReference> gridReferences = new List<BuildGridReference>();

            int toX = x + size - 1;
            int toZ = z + size - 1;

            for (; x <= toX; x++)
            {
                for (; z <= toZ; z++)
                {
                    gridReferences.Add(new BuildGridReference(x, z));
                }
            }

            return gridReferences;
        }
    }
}
