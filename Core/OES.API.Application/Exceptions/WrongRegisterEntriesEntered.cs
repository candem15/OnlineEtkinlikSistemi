namespace OES.API.Application.Exceptions
{
    public class WrongRegisterEntriesEnteredException : Exception
    {
        public WrongRegisterEntriesEnteredException() : base("Hatalı kayıt değerleri girdiniz!")
        {
        }

        public WrongRegisterEntriesEnteredException(string? message) : base(message)
        {
        }

        public WrongRegisterEntriesEnteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
