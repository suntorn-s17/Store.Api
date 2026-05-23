namespace Store.Api.Exceptions
{
    public class UnauthorizeException : Exception
    {
        public UnauthorizeException()
        {
        }

        public UnauthorizeException(string message) : base(message)
        {
        }

        public UnauthorizeException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}