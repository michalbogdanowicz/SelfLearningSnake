using System;

namespace SelfLearningProject
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location()
        {

        }

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public double DistanceFrom(Location loc)
        {
            int xDiff = this.X - loc.X;
            int yDiff = this.Y - loc.Y;
            double square = Math.Sqrt( Math.Pow(xDiff,2) + Math.Pow(yDiff, 2));


            return square;
        }
    }
}