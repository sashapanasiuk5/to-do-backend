using System.Reflection;
using Core.Actions.Task.Create;
using WebApi.Controllers;
using Task = DataAccess.Entities.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assemblies = new[]
{
    Assembly.GetAssembly(typeof(TaskController)),
    Assembly.GetAssembly(typeof(CreateTaskCommand)),
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies!));

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

app.Run();