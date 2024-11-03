using Microsoft.AspNetCore.Mvc;
using OA.Infrastructure;
using OA.Persistence;
using Onion_Architecture.Responese;
using OA.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errorMessage = context.ModelState
                .Where(e => e.Value?.Errors.Count > 0)
                .Select(e => e.Value?.Errors.FirstOrDefault()?.ErrorMessage ?? "Unknown error")
                .FirstOrDefault() ?? "Unknown error";

            var response = new ApiResponse<object>(false, errorMessage);
            return new BadRequestObjectResult(response);
        };
    });


builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
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

app.UseHttpsRedirection();
app.UseCors("AllowAll");


app.UseAuthorization();
app.MapControllers();

app.Run();