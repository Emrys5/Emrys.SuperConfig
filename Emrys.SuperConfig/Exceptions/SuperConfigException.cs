using System;
using System.Runtime.Serialization;

namespace Emrys.SuperConfig.Exceptions
{
    public class SuperConfigException : Exception
    {
        public SuperConfigException(string message)
            : base(message)
        {
        }

        public SuperConfigException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}