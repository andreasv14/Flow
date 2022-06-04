using CleanArchitecture.WebUI.Filters;
using Flow.WebAPI.Filters;
using FluentValidation.AspNetCore;

namespace Flow.WebAPI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        //services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddControllers(options =>
        {
            options.Filters.Add<ApiExceptionFilterAttribute>();
            options.Filters.Add<ApiResponseWrapperAttribute>();
        }).AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        //services.AddControllers(options =>
        //{
        //    options.Filters.Add<ApiExceptionFilterAttribute>();
        //}).AddFluentValidation(fv =>
        //{
        //    fv.RegisterValidatorsFromAssemblyContaining<CreateItemCommandValidator>();
        //    fv.RegisterValidatorsFromAssemblyContaining<CreateTraderCommandValidator>();
        //    fv.RegisterValidatorsFromAssemblyContaining<CreateCompanyCommandValidator>();
        //});

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  //builder.WithOrigins("http://localhost:4200");
                                  builder.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                              });
        });

        return services;
    }
}
