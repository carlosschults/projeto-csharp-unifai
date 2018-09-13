namespace carlosschults.ProjetoCSharpUnifai.Aplicacao
{
    public class OperationResult
    {
        public OperationResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; private set; }

        public string ErrorMessage { get; private set; }
    }
}