using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Exceptions
{
    public class ForecastInputException : Exception
    {
        public ForecastInputException() : base() { }
        public ForecastInputException(string message) : base(message) { }
        public ForecastInputException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected ForecastInputException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
