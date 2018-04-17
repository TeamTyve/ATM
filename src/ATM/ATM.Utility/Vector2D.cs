namespace ATM.Utility
{
    public class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2D(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public virtual bool IsPositive()
        {
            return X >= 0 && Y >= 0;
        }
    }
}