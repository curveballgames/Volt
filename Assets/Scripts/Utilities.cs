using System.Collections.Generic;
using Curveball;
using UnityEngine;

namespace Volt
{
    public class Utilities : CBGGameObject
    {
        public static BuildGridReference GetGridReference(Vector3 location)
        {
            return new BuildGridReference(
                Mathf.FloorToInt(location.x),
                Mathf.FloorToInt(location.z)
            );
        }

        public static BuildGridArea GetArea(BuildGridReference from, int size)
        {
            return GetArea(from.X, from.Z, size);
        }

        public static BuildGridArea GetArea(int fromX, int fromZ, int size)
        {
            BuildGridArea gridArea = new BuildGridArea
            {
                MinX = fromX,
                MaxX = fromX + size - 1,
                MinZ = fromZ,
                MaxZ = fromZ + size - 1
            };

            return gridArea;
        }

        public static List<BuildGridReference> GetGridReferences(int x, int z, int size)
        {
            List<BuildGridReference> gridReferences = new List<BuildGridReference>();

            BuildGridArea gridArea = GetArea(x, z, size);

            for (int ax = gridArea.MinX; ax <= gridArea.MaxX; ax++)
            {
                for (int az = gridArea.MinZ; az <= gridArea.MaxZ; az++)
                {
                    gridReferences.Add(new BuildGridReference(ax, az));
                }
            }

            return gridReferences;
        }
    }
}
