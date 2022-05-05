namespace Flow.ResourceManager.WebAPI.Models;

public class ApiResponse
{
    public int StatusCode { get; set; }

    public string ErrorMessage { get; set; }
}

public class ApiResponse<TData> : ApiResponse
{
    public TData Data { get; set; }

    public ApiResponse() { }

    public ApiResponse(TData data)
    {
        Data = data;
    }

    public static ApiResponse<T> Ok<T>(T data)
    {
        return new ApiResponse<T>(data)
        {
            StatusCode = 200,
            Data = data
        };
    }

    public static ApiResponse<T> Failed<T>(T data, int statusCode)
    {
        return new ApiResponse<T>(data)
        {
            StatusCode = statusCode,
            Data = data
        };
    }
}