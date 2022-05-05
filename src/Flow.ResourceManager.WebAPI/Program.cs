using Flow.ResourceManager.Application;
using Flow.ResourceManager.Application.Companies.Validators;
using Flow.ResourceManager.Application.Items.Validators;
using Flow.ResourceManager.Application.Traders.Validators;
using Flow.ResourceManager.Infrastructure;
using Flow.ResourceManager.WebAPI.Filters;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
}).AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<CreateItemCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateTraderCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateCompanyCommandValidator>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
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

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
