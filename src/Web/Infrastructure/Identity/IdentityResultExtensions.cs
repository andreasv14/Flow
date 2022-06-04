using Flow.WebAPI.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Flow.WebAPI.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
