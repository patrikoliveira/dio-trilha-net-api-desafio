namespace TrilhaApiDesafio.Shared.Messages
{
    public static class ResourceMessages
    {
        public static int TITULO_MAX { get; } = 50;
        public static int DESCRICAO_MAX { get; } = 500;
        public static string TITULO_EMPTY { get; } = "O titulo não pode ser vazio.";
        public static string TITULO_MAX_MESSAGE { get; } = $"O titulo não pode ser maior que {TITULO_MAX} caracteres.";
        public static string DESCRICAO_EMPTY { get; } = "A descrição não pode ser vazia.";
        public static string DESCRICAO_MAX_MESSAGE { get; } = $"O titulo não pode ser maior que {DESCRICAO_MAX} caracteres.";
        public static string DATE_INVALID { get; } = "A data está invalida.";
        public static string UNKNOWN_ERROR { get; } = "Erro desconhecido.";
    }
}

