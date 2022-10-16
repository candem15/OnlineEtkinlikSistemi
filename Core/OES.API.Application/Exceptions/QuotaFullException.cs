namespace OES.API.Application.Exceptions
{
    public class QuotaFullException : Exception
    {
        public QuotaFullException() : base("Bu etkinliğin kontenjanı dolmuştur! Katılım sağlayamazsınız.")
        {
        }

        public QuotaFullException(string? message) : base(message)
        {
        }

        public QuotaFullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
