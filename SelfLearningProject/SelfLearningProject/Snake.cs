using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SelfLearningProject
{
    public class Snake
    {
        public bool IsAlive = true;
        public Location HeadPosition { get; set; } = new Location();
        public SnakeBehaviourDecider decider = new SnakeBehaviourDecider();
        public double DistanceFromFood { get; set; }

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

        public Snake Clone()
        {
            Snake snake = new Snake
            {
                IsAlive = this.IsAlive,

            };
            snake.decider = this.decider.Clone();
            return snake;
        }
        /// <summary>
        /// genarate an offspring and mutates it
        /// </summary>
        /// <returns></returns>
        public Snake GenerateOffspring()
        {
            Snake snake = new Snake
            {
                IsAlive = this.IsAlive,

            };
            snake.decider = this.decider.Clone();
            snake.decider.Mutate();
            return snake;
        }
    }
}
