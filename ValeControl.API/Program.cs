using Microsoft.EntityFrameworkCore;
using ValeControl.API.DbContexts;
using ValeControl.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ValeDbContext>(
    o => o.UseSqlServer(builder.Configuration["ConnectionStrings:ValeDbConStr"])
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Usando a política CORS configurada
app.UseCors("AllowAllOrigins");

app.RegisterFuncionariosEndpoints();

app.CalcularGastosEndpoints();

app.Run();