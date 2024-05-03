namespace TrilhaApiDesafio.Shared
{
    public static class Utils
    {
        public static bool BeAValidDate(DateTime date) => !date.Equals(default);
    }
}

