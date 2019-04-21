using System;
using System.Collections.Generic;
using System.Text;

namespace SelfLearningProject
{
    public class World
    {
        public int[,] space;
        public int[,] lastSpace;
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
            this.space = new int[maxX, maxY];
            lastSpace = new int[maxX, maxY];
            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    this.space[i, j] = (int)Thing.Empty;
                    this.lastSpace[i, j] = (int)Thing.Empty;
                }
            }
        }

        public void CopyCurrentSpace()
        {
            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    this.lastSpace[i, j] = this.space[i, j];
                }
            }
        }

        public void GenerateFood()
        {

            var cords = GetTwoRandomNumbers();
            CopyCurrentSpace();
            this.space[cords[0], cords[1]] = (int)Thing.Food;

        }

        public void StartSnakeSomewhere()
        {

        }

        private int[] GetTwoRandomNumbers()
        {
            int[] array = new int[2];
            Random r = new Random();
            int x = r.Next(0, 64);
            //r = new Random();
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
            Food,

        }
    }
}
