using System;
using System.Collections.Generic;
using System.Text;

namespace SelfLearningProject
{
    public class World
    {
        public int[,] space;

        private static World instance;
        int maxX = 64;
        int maxY = 64;

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
        public int[] GenerateFood(bool copySpace = false)
        {
            var cords = GetTwoRandomNumbers();
            this.space[cords[0], cords[1]] = (int)Thing.Food;
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
                }
            } while (!foundGoodSpace);
        }

        public void GenerateGame()
        {
            Init();
             GenerateFood();
            GenerateSnake();
        }
    }
}
