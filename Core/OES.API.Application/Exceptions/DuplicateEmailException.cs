namespace OES.API.Application.Exceptions
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException() : base("Bu email ile oluşturulmuş hali hazırda bir firma bulunmaktadır!")
        {
        }

        public DuplicateEmailException(string? message) : base(message)
        {
        }

        public DuplicateEmailException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
