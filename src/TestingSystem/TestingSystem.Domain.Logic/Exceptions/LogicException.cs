using System;

namespace TestingSystem.Domain.Logic.Exceptions
{
    public class LogicException : Exception
    {
        public LogicException(string message) : base(message) { }
    }
}
