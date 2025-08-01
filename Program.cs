using System.Text.Json.Serialization;
using LaboratorioRestApi.Repository;
using LaboratorioRestApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions
                        .ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
                        
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

