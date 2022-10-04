using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException():base("Hatalı şifre girdiniz. Lütfen tekrar deneyiniz.")
        {
        }

        public WrongPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
