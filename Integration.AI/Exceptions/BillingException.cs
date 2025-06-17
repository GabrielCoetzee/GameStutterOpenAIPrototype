namespace Integration.AI.Exceptions
{
    public class BillingException : Exception
    {
        public BillingException()
        {
        }

        public BillingException(string message)
            :base(message)
        {
        }

        public BillingException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}
