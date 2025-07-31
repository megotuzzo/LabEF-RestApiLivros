using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions
                        .ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/api/v1.json", "Laboratorio REST API V1");
                    options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
                });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

