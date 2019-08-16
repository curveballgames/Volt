using UnityEngine;

namespace Volt
{
    public struct BuildGridArea
    {
        public int Width { get => MaxX - MinX + 1; }
        public int Height { get => MaxZ - MinZ + 1; }
        public int Size { get => Mathf.Max(Width, Height); }

        public int MinX;
        public int MaxX;
        public int MinZ;
        public int MaxZ;

        public BuildGridArea(int minX, int maxX, int minZ, int maxZ)
        {
            MinX = minX;
            MaxX = maxX;
            MinZ = minZ;
            MaxZ = maxZ;
        }
    }
}
