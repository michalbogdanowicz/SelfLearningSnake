using SelfLearningProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SelfLearningProject
{
    public class World
    {
        public int[,] space;

        private static World instance;
        int maxX = 64;
        int maxY = 64;
        Snake snake = new Snake();

        public static World GetInstance()
        {
            if (instance == null)
            {
                instance = new World();
            }
            return instance;
        }
        private World()
        {
            Init();
        }

        private void Init()
        {
            this.space = new int[maxX, maxY];

            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    this.space[i, j] = (int)Thing.Empty;
                }
            }
        }
        /// <summary>
        /// returns the cords
        /// </summary>
        /// <param name="copySpace"></param>
        /// <returns></returns>
        public int[] GenerateFood()
        {
            var cords = GetTwoRandomNumbers();
            this.space[cords[0], cords[1]] = (int)Thing.Food;
            return cords;
        }
        /// <summary>
        /// returns the cords
        /// </summary>
        /// <param name="copySpace"></param>
        /// <returns></returns>
        public int[] GenerateFood(Location loc)
        {
            var cords = GetTwoRandomNumbers();
            this.space[loc.X, loc.Y] = (int)Thing.Food;
            return cords;
        }

        private int[] GetTwoRandomNumbers()
        {
            int[] array = new int[2];
            Random r = new Random();
            int x = r.Next(0, 64);
            int y = r.Next(0, 64);
            array[0] = x;
            array[1] = y;
            return array;
        }

        public enum Thing
        {
            Empty,
            Head,
            SnakePart,
            Food

        }

        public void GenerateSnake()
        {

            bool foundGoodSpace = true;
            do
            {
                var cords = GetTwoRandomNumbers();
                foundGoodSpace = this.space[cords[0], cords[1]] == (int)Thing.Empty;
                if (foundGoodSpace)
                {
                    this.space[cords[0], cords[1]] = (int)Thing.Head;
                    snake.HeadPosition.X = cords[0];
                    snake.HeadPosition.Y = cords[1];
                }
            } while (!foundGoodSpace);
        }

        public void GenerateSnake(Location location)
        {
            this.space[location.X, location.Y] = (int)Thing.Head;
            snake.HeadPosition = location;
        }

        public void GenerateRandomWorld()
        {
            Init();
            GenerateFood();
            GenerateSnake();
        }

        public void GenerateSpecificWorld(Location foodLocaiton, Location snakeLocation)
        {
            Init();
            GenerateFood(foodLocaiton);
            GenerateSnake(snakeLocation);
        }

        public void NextStep()
        {

            SnakeBehaviourDecider decider = new SnakeBehaviourDecider();
            var nextStep = decider.DecideNextStep(this.space, this.maxX);

            this.space[this.snake.HeadPosition.X, this.snake.HeadPosition.Y] = (int)Thing.Empty;
            switch (nextStep)
            {
                case Direction.Left: this.snake.HeadPosition.X--; break;
                case Direction.Top: this.snake.HeadPosition.Y++; break;
                case Direction.Right: this.snake.HeadPosition.X++; break;
                case Direction.Down: this.snake.HeadPosition.Y--; break;
                default: throw new ArgumentException();
            }
            if (this.snake.IsOutOfBounds(this.maxX, this.maxY))
            {
                throw new SnakeIsOutOfBoundsException();
            }
            this.space[this.snake.HeadPosition.X, this.snake.HeadPosition.Y] = (int)Thing.Head;

        }
    }
}

