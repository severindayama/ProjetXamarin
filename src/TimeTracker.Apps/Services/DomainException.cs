using System;
using System.Runtime.Serialization;

namespace TimeTracker.Apps.Services
{
    [Serializable]
    internal class DomainException : Exception
    {
        private string eMAIL_ALREADY_EXISTS;
        private string v;

        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string eMAIL_ALREADY_EXISTS, string v)
        {
            this.eMAIL_ALREADY_EXISTS = eMAIL_ALREADY_EXISTS;
            this.v = v;
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}