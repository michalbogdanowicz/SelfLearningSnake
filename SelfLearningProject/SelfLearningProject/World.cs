using SelfLearningProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;

namespace SelfLearningProject
{
    public class World
    {
        private static World instance;
        int maxX = 64;
        int maxY = 64;
        List<Snake> snakes;
        int numOfSnakes = 100;
        Location fooodLocation;
        int step = 0;
        List<Snake> snakesThatAte;
        int generation = 0;
        double meanDistanceOfGeneration = 0;

        Location snakeStartingLocation = new Location();

        public int[,] GetRepresentation()
        {
            int[,] localSpace = new int[maxX, maxY];
            foreach (var snake in snakes)
            {
                localSpace[snake.HeadPosition.X, snake.HeadPosition.Y] = (int)Thing.Head;
            }

            localSpace[fooodLocation.X, fooodLocation.Y] = (int)Thing.Food;
            return localSpace;
        }

        public SnakeReport GetSnakeReport()
        {
            var s = new SnakeReport
            {
                AliveSnakes = snakes.Count,
                Movements = step,
                SnakesWhoAte = snakesThatAte.Count,
                Generation = this.generation ,
                 MeanDistanceOfGeneration = this.meanDistanceOfGeneration
            };
            return s;
        }

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
            generation = 1;
            snakes = new List<Snake>();
            snakesThatAte = new List<Snake>();
        }


        /// <summary>
        /// returns the cords
        /// </summary>
        /// <param name="copySpace"></param>
        /// <returns></returns>
        public int[] GenerateFood()
        {
            var cords = GetTwoRandomNumbers();
            fooodLocation = new Location(cords[0], cords[1]);
            // this.space[cords[0], cords[1]] = (int)Thing.Food;
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
            fooodLocation = new Location(loc.X, loc.Y);
            // this.space[loc.X, loc.Y] = (int)Thing.Food;
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



        public void GenerateSnakes()
        {
            snakes = new List<Snake>();
            for (int i = 0; i < numOfSnakes; i++)
            {
                var snake = new Snake();
                snake.decider.Mutate();
                snakes.Add(snake);
            }
            bool foundGoodSpace = true;
            do
            {
                var cords = GetTwoRandomNumbers();
                foundGoodSpace = this.fooodLocation.X != cords[0] && this.fooodLocation.Y != cords[1];
                if (foundGoodSpace)
                {
                    foreach (var snake in this.snakes)
                    {
                        snake.HeadPosition.X = cords[0];
                        snake.HeadPosition.Y = cords[1];
                    }
                }
            } while (!foundGoodSpace);
        }

        public void GenerateSnakes(Location location)
        {
            snakes = new List<Snake>();
            for (int i = 0; i < numOfSnakes; i++)
            {
                snakes.Add(new Snake());
            }
            foreach (var snake in this.snakes)
            {
                snake.HeadPosition.X = location.X;
                snake.HeadPosition.Y = location.Y;
            }
        }

        public void GenerateRandomWorld()
        {
            GenerateFood();
            GenerateSnakes();
        }

        public void GenerateSpecificWorld(Location foodLocaiton, Location snakeLocation)
        {
            GenerateFood(foodLocaiton);
            GenerateSnakes(snakeLocation);
            this.snakeStartingLocation.X = snakeLocation.X;
            this.snakeStartingLocation.Y = snakeLocation.Y;
        }

        public void NextStep()
        {
            if (this.step >= 150)
            {
                this.generation++;
                this.step = 0;
                CreateNewGenerationWithDistance();
            }
            List<Snake> toDelete = new List<Snake>();
            foreach (var snake in this.snakes)
            {
                var nextStep = snake.decider.DecideNextStep(this.maxX);

                switch (nextStep)
                {
                    case Direction.Left: snake.HeadPosition.X--; break;
                    case Direction.Top: snake.HeadPosition.Y++; break;
                    case Direction.Right: snake.HeadPosition.X++; break;
                    case Direction.Down: snake.HeadPosition.Y--; break;
                    default: throw new ArgumentException();
                }
                if (snake.IsOutOfBounds(this.maxX, this.maxY))
                {
                    toDelete.Add(snake);
                }
                if (snake.HeadPosition.X == this.fooodLocation.X &&
                     snake.HeadPosition.Y == this.fooodLocation.Y)
                {
                    this.snakesThatAte.Add(snake);
                    toDelete.Add(snake);
                }
            }

            foreach (var snake in toDelete)
            {
                this.snakes.Remove(snake);
            }
            step++;

        }

        private void CreateNewGeneration()
        {
            List<Snake> newSnakes = new List<Snake>();
            // max amount is 100
            foreach (var snake in this.snakesThatAte)
            {
                if (newSnakes.Count < 100)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var newSnake = snake.GenerateOffspring();
                        newSnake.HeadPosition.X = snakeStartingLocation.X;
                        newSnake.HeadPosition.Y = snakeStartingLocation.Y;
                        newSnakes.Add(newSnake);
                    }
                }
            }
            this.snakesThatAte.Clear();
            while (newSnakes.Count < 100)
            {
                if (this.snakes.Count != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var newSnake = this.snakes[0].GenerateOffspring();
                        newSnake.HeadPosition.X = snakeStartingLocation.X;
                        newSnake.HeadPosition.Y = snakeStartingLocation.Y;
                        newSnakes.Add(newSnake);
                    }
                    this.snakes.RemoveAt(0);
                }
                else
                {
                    var newSnake = new Snake();
                    newSnake.HeadPosition.X = snakeStartingLocation.X;
                    newSnake.HeadPosition.Y = snakeStartingLocation.Y;
                    newSnakes.Add(newSnake);
                }
            }

            this.snakes = newSnakes;
        }

        private void CreateNewGenerationWithDistance()
        {
            List<Snake> newSnakes = new List<Snake>();
            foreach (var snake in this.snakes)
            {
                snake.DistanceFromFood = snake.HeadPosition.DistanceFrom(this.fooodLocation);
            }
            this.meanDistanceOfGeneration = this.snakes.Sum(i => i.DistanceFromFood) / this.snakes.Count;
            // max amount is 100
            foreach (var snake in this.snakesThatAte)
            {
                if (newSnakes.Count < 100)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var newSnake = snake.GenerateOffspring();
                        newSnake.HeadPosition.X = snakeStartingLocation.X;
                        newSnake.HeadPosition.Y = snakeStartingLocation.Y;
                        newSnakes.Add(newSnake);
                    }
                }
            }
            this.snakesThatAte.Clear();

      
            this.snakes = this.snakes.OrderBy(i => i.DistanceFromFood).ToList();
         
            while (newSnakes.Count < 100)
            {
                if (this.snakes.Count != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var newSnake = this.snakes[0].GenerateOffspring();
                        newSnake.HeadPosition.X = snakeStartingLocation.X;
                        newSnake.HeadPosition.Y = snakeStartingLocation.Y;
                        newSnakes.Add(newSnake);
                    }
                    this.snakes.RemoveAt(0);
                }
                else
                {
                    var newSnake = new Snake();
                    newSnake.HeadPosition.X = snakeStartingLocation.X;
                    newSnake.HeadPosition.Y = snakeStartingLocation.Y;
                    newSnakes.Add(newSnake);
                }
            }

            this.snakes = newSnakes;
        }
    }
}

