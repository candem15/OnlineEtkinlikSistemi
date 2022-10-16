namespace OES.API.Application.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("Hatalı şifre girdiniz. Lütfen tekrar deneyiniz.")
        {
        }

        public WrongPasswordException(string? message) : base(message)
        {
        }

        public WrongPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
