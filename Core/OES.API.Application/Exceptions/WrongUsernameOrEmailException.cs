﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Exceptions
{
    public class WrongUsernameOrEmailException : Exception
    {
        public WrongUsernameOrEmailException() : base("Hatalı kullanıcı adı/email girdiniz. Lütfen tekrar deneyiniz.")
        {
        }

        public WrongUsernameOrEmailException(string? message) : base(message)
        {
        }

        public WrongUsernameOrEmailException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
