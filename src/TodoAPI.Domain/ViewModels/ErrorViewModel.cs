﻿using System.Collections.Generic;
using System.Net;

namespace TodoApi.Domain.ViewModels
{
    public class ErrorViewModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public IList<string> ErrorsMessage { get; set; }

        public ErrorViewModel(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorsMessage.Add(errorMessage);
        }

        public ErrorViewModel(HttpStatusCode statusCode, IList<string> errorsMessage)
        {
            StatusCode = statusCode;
            ErrorsMessage = errorsMessage;
        }
    }
}
