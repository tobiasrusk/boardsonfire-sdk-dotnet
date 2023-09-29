namespace BoardsOnFireSdk.Exceptions;

public class BoardsOnFireDeserializationException : Exception
{
    public string ResponseContent { get; }

    public BoardsOnFireDeserializationException(string message, string responseContent, Exception? innerException = null) : base(message, innerException)
    {
        ResponseContent = responseContent;
    }
}