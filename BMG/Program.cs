using Microsoft.EntityFrameworkCore;
using BMG.Data;
using BMG.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Adiciona o serviço do Swagger
builder.Services.AddAuthorization(); // Adiciona o serviço de autorização

// Adiciona o serviço de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Registra o ClientContext no contêiner de serviços
builder.Services.AddDbContext<ClientContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 7, 3)), // Atualize a versão aqui
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);

// Registra a interface e a implementação do ClientService no contêiner de serviços
builder.Services.AddScoped<IClientService, ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Adiciona o middleware do Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Define a UI do Swagger na raiz (opcional)
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();  

app.UseRouting(); // Configura o roteamento

app.UseCors("AllowAllOrigins"); // Adiciona o middleware de CORS

app.UseAuthorization(); // Certifique-se de que o middleware de autorização está registrado

app.MapControllers(); // Mapeia os controladores para o pipeline de requisição

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.UseMiddleware<RequestLoggingMiddleware>();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}