namespace ATM.Utility
{
    public class Vector3D : Vector2D
    {
        public int Z { get; set; }

        public Vector3D(int x = 0, int y = 0, int z = 0) : base(x, y)
        {
            Z = z;
        }

        public override bool IsPositive()
        {
            return base.IsPositive() && Z >= 0;
        }
    }
}