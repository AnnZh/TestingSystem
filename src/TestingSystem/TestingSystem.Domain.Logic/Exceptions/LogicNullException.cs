using System;

namespace TestingSystem.Domain.Logic.Exceptions
{
    class LogicNullException : Exception
    {
        public LogicNullException(string message) : base(message) { }
    }
}
