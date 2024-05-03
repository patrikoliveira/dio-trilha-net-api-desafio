namespace TrilhaApiDesafio.Shared.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : TrilhaApiDesafioException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}

