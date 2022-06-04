using Flow.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Flow.WebAPI.Filters;

public class ApiResponseWrapperAttribute : Attribute, IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context) { }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        var result = context.Result;
        if (result is ObjectResult objectResult)
        {
            if (objectResult.Value is ApiResponse apiResponse)
            {
                // make sure status code is same as in object response
                apiResponse.StatusCode = objectResult.StatusCode ??
                                         (apiResponse.StatusCode == 0 ?
                                             StatusCodes.Status200OK :
                                             apiResponse.StatusCode);
                return;
            }

            // wrap object into api response
            var resp = new ApiResponse<object>
            {
                StatusCode = objectResult.StatusCode ?? StatusCodes.Status200OK,
                Data = objectResult.Value
            };
            context.Result = new ObjectResult(resp)
            {
                StatusCode = resp.StatusCode
            };
            return;
        }

        var response = new ApiResponse
        {
            StatusCode = (result as StatusCodeResult)?.StatusCode ?? StatusCodes.Status200OK
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}