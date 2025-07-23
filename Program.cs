using AuthService.Data;
using Microsoft.EntityFrameworkCore;
using AuthService.Services;
using AuthService.Middleware;  // ExceptionMiddleware için ekle
using FluentValidation.AspNetCore; // FluentValidation için ekle

var builder = WebApplication.CreateBuilder(args);

// Services (Bağımlılıkları ekle)
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MSSQL DbContext bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Servisleri IOC container'a ekle
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Global Exception Middleware'i en başta ekle
app.UseMiddleware<ExceptionMiddleware>();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Controller'ları map'le
app.MapControllers();

app.Run();
