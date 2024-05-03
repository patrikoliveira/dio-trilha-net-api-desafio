namespace TrilhaApiDesafio.Shared.Exceptions.ExceptionsBase
{
    public class EntityNotFoundException : TrilhaApiDesafioException
    {
        public IList<string> ErrorMessages { get; set; }

        public EntityNotFoundException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}

