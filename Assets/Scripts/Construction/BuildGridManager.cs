using System.Collections.Generic;
using Curveball;

namespace Volt
{
    public class BuildGridManager : CBGGameObject
    {
        private static HashSet<BuildGridReference> occupiedTiles;

        private void Awake()
        {
            occupiedTiles = new HashSet<BuildGridReference>();
        }

        private void OnDestroy()
        {
            occupiedTiles.Clear();
            occupiedTiles = null;
        }

        public static bool CanBuildAt(int x, int z)
        {
            return !occupiedTiles.Contains(new BuildGridReference(x, z));
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

        public static bool CanBuildAt(BuildGridReference gridRef, int size)
        {
            return CanBuildAt(gridRef.X, gridRef.Z, size);
        }

        public static void OccupyTile(int x, int z)
        {
            occupiedTiles.Add(new BuildGridReference(x, z));
        }

        public static void OccupyTiles(int x, int z, int size)
        {
            foreach (BuildGridReference gr in GetGridReferences(x, z, size))
            {
                occupiedTiles.Add(gr);
            }
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
