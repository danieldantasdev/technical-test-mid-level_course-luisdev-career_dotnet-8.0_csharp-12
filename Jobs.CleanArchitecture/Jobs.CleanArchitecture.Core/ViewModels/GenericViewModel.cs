using System.Net;

namespace Jobs.CleanArchitecture.Core.ViewModels;

public record GenericViewModel<T>
{
    public HttpStatusCode StatusCode { get; init; }
    public DateTime Date { get; init; }
    public string Message { get; init; }
    public T? Data { get; init; }

    public GenericViewModel()
    {
        StatusCode = HttpStatusCode.OK;
        Date = DateTime.Now;
        Message = string.Empty;
        Data = default;
    }

    public GenericViewModel(HttpStatusCode statusCode, DateTime date, string message, T? data)
    {
        StatusCode = statusCode;
        Date = date;
        Message = message;
        Data = data;
    }

    public static GenericViewModel<T> Create(HttpStatusCode httpStatusCode, string message, T? data)
    {
        return new GenericViewModel<T>
        {
            StatusCode = httpStatusCode,
            Date = DateTime.Now,
            Message = message,
            Data = data
        };
    }
}
