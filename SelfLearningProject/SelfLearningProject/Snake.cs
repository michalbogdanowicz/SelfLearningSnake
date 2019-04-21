using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SelfLearningProject
{
    public class Snake
    {
        public Location HeadPosition { get; set; } = new Location();

        internal bool IsOutOfBounds(int maxX, int maxY)
        {
            if (HeadPosition.X < 0 || HeadPosition.X >= maxX)
            {
                return true;
            }

            if (HeadPosition.Y < 0 || HeadPosition.Y >= maxY)
            {
                return true;
            }
            return false;
        }
    }
}
