using System;
using System.Collections.Generic;
using System.Text;

namespace SelfLearningProject
{
    public class SnakeBehaviourDecider
    {

        Random random = Randomizer.GetInstance();
        int chanceLeft = 25;
        int chanceTop = 50;
        int chanceRight = 75;
        public SnakeBehaviourDecider()
        {

        }

        public SnakeBehaviourDecider(int chanceLeft, int chanceTop, int chanceRight)
        {
            this.chanceLeft = chanceLeft;
            this.chanceTop = chanceTop;
            this.chanceRight = chanceRight;
        }

        public void Mutate()
        {
            chanceLeft += GetAmount();
            chanceTop += GetAmount();
            chanceRight += GetAmount();
        }

        private int GetAmount()
        {
            int amount = Randomizer.TossACoin() ? 0 : 1;
            amount = Randomizer.TossACoin() ? amount * -1 : amount;
            return amount;
        }

        public Direction DecideNextStep(int size)
        {
            // take in consideration the fact there is food
            // take in consdieration that there are borders

            int x = random.Next(0, 99);

            if (x < chanceLeft)
            {
                return Direction.Left;
            }
            else if (x < chanceTop)
            {
                return Direction.Top;
            }
            else if (x < chanceRight)
            {
                return Direction.Right;
            }
            else
            {
                return Direction.Down;
            }

            //switch (x)
            //{
            //    case (int)Direction.Left: return Direction.Left; break;
            //    case (int)Direction.Top: return Direction.Top; break;
            //    case (int)Direction.Right: return Direction.Right; break;
            //    case (int)Direction.Down: return Direction.Down; break;
            //    default: throw new ArgumentException();
            //}
        }

        internal SnakeBehaviourDecider Clone()
        {
            SnakeBehaviourDecider clone = new SnakeBehaviourDecider(this.chanceLeft, this.chanceTop, this.chanceRight);

            return clone;
        }

        // to see if something was positive
        // check what is the distance from the objective

    }
}
