namespace Volt
{
    public struct BuildGridReference
    {
        public int X;
        public int Z;

        public BuildGridReference(int x, int z)
        {
            X = x;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BuildGridReference))
            {
                return false;
            }

            BuildGridReference reference = (BuildGridReference)obj;
            return X == reference.X &&
                   Z == reference.Z;
        }

        public override int GetHashCode()
        {
            return X * 512 + Z;
        }

        public override string ToString()
        {
            return string.Format("[x: {0}, z: {1}]", X, Z);
        }
    }
}
