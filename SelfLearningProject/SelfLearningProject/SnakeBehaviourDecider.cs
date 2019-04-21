using System;
using System.Collections.Generic;
using System.Text;

namespace SelfLearningProject
{
    public class SnakeBehaviourDecider
    {
        Random r = new Random();
      
        public SnakeBehaviourDecider()
        {

        }

        public Direction DecideNextStep(int[,] board, int size)
        {
            int x = r.Next(0, 3);

            switch (x)
            {
                case (int)Direction.Left: return Direction.Left; break;
                case (int)Direction.Top: return Direction.Top; break;
                case (int)Direction.Right: return Direction.Right; break;
                case (int)Direction.Down: return Direction.Down; break;
                default: throw new ArgumentException();
            }
        }

    }
}
