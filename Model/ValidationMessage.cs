namespace Model
{
    public class ValidationMessage
    {
        public ValidationMessage(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ValidationMessage(bool success)
        {
            Success = success;
            Message = string.Empty;
        }

        public bool Success { get; private set; }

        public string Message { get; private set; }
    }
}