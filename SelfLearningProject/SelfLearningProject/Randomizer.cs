using System;
using System.Collections.Generic;
using System.Text;

namespace SelfLearningProject
{
    public class Randomizer
    {
        private static Random random;
        public static Random GetInstance()
        {
            if (random == null)
            {
                random = new Random();
            }
            return random;
        }

        public static bool TossACoin()
        {
            return GetInstance().Next(0, 99) < 50;
        }
    }
}
