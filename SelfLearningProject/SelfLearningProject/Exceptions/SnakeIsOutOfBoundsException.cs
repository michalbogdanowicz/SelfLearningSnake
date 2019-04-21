using System;

namespace SelfLearningProject.Exceptions
{
    public class SnakeIsOutOfBoundsException : Exception
    {
        public SnakeIsOutOfBoundsException()
        {
        }

        public SnakeIsOutOfBoundsException(string message) : base(message)
        {
        }

        public SnakeIsOutOfBoundsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}