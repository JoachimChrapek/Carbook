using Carbook.API.Cars;
using Carbook.API.ScrutorTest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCarServices();
builder.Services.AddTestServices();

var app = builder.Build();

Console.WriteLine($"{nameof(IdProvider)} ID: {app.Services.GetRequiredService<IdProvider>().Id}");
Console.WriteLine($"{nameof(IGuidProvider)} ID: {app.Services.GetRequiredService<IGuidProvider>().GetID()}");
Console.WriteLine($"{nameof(IStringIdProvider)} ID: {app.Services.GetRequiredService<IStringIdProvider>().GetId()}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();