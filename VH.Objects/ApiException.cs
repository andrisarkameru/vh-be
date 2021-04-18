using System;
using System.Collections.Generic;
using System.Text;

namespace VH.Core
{
    public class ApiException: Exception
    {
        public string UserMessage { get; set; }
        public ApiException(string userMessage, string message) : base(message)
        {
            this.UserMessage = userMessage;
        }

        public ApiException(string userMessage, string message, Exception innerException) : base(message, innerException)
        {
            this.UserMessage = userMessage;
        }

        public ApiException(string userMessage) : base(userMessage)
        {
            this.UserMessage = userMessage;
        }

        public ApiException(string userMessage, Exception innerException) : base(userMessage, innerException)
        {
            this.UserMessage = userMessage;
        }
    }
}
