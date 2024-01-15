namespace EmprestimoLivrosNovo.API.Errors
{
    public class ApiException
    {
        public ApiException(string statusCode, string message, string details)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
