using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Exceptions
{
    public class AlreadyJoinedToEventException : Exception
    {
        public AlreadyJoinedToEventException() : base("Bu etkinliğe zaten katıldınız!")
        {
        }

        public AlreadyJoinedToEventException(string? message) : base(message)
        {
        }

        public AlreadyJoinedToEventException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
