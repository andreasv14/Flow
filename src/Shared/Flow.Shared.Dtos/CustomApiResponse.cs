namespace Flow.Shared.Dtos;

public class CustomApiResponse
{
    public int StatusCode { get; set; }

    public string ErrorMessage { get; set; }
}

public class CustomApiResponse<TData> : CustomApiResponse
{
    public TData Data { get; set; }

    public CustomApiResponse() { }

    public CustomApiResponse(TData data)
    {
        Data = data;
    }

    public static CustomApiResponse<T> Ok<T>(T data)
    {
        return new CustomApiResponse<T>(data)
        {
            StatusCode = 200,
            Data = data
        };
    }

    public static CustomApiResponse<T> Failed<T>(T data, int statusCode)
    {
        return new CustomApiResponse<T>(data)
        {
            StatusCode = statusCode,
            Data = data
        };
    }
}