using System.Net;

namespace TodoApi.Domain.ViewModels
{
    public class ErrorViewModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorViewModel(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
