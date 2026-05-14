using System.Text;
using BotRemesas.Application.DependencyInjection;
using BotRemesas.Db;
using BotRemesas.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuración de Swagger con soporte para JWT (opcional)
builder.Services.AddSwaggerGen();



// Agregar capas de Clean Architecture
builder.Services.AddApplication();
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddInfrastructure(builder.Configuration);



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BotRemesasDbContext>();
    await dbContext.Database.MigrateAsync(); // Esto aplica todas las migraciones pendientes
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BotRemesas API V1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();