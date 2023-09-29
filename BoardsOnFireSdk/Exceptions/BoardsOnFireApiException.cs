using System.Net;

namespace BoardsOnFireSdk.Exceptions;

public class BoardsOnFireApiException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }

    public BoardsOnFireApiException(HttpStatusCode statusCode, string message, string errorMessage, Exception? innerException = null) : base(message, innerException)
    {
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }
}
