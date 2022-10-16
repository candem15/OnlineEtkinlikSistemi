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
