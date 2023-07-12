using System.Net;

namespace Lemmy.Net;

public class ApiException : Exception
{
    public string? Error { get; }
    
    public HttpStatusCode StatusCode { get; }
    
    public ApiException(string message, string? error, HttpStatusCode statusCode) 
        : base(message)
    {
        StatusCode = statusCode;
        Error = error;
    }
}