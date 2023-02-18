using Application.Interfaces;
using CrossCuting.Native_Injector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();

// Dependency Injector
NativeInjector.AddServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var serviceScope = app.Services.CreateScope();
var messageConsumerService = serviceScope.ServiceProvider.GetRequiredService<IRabbitMqConfig>();

messageConsumerService.OnReceived += data =>
{
    Console.WriteLine($"Foi solicitado um relatório das últimas {data.QtdLinhas} linhas");
};

messageConsumerService.Listen();

app.Run();
