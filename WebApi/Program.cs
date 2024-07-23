using System.Reflection;
using Core;
using Core.Actions.Task.Create;
using Core.DomainRules.Validation;
using Core.DTO.Task;
using DataAccess;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using FluentValidation;
using WebApi.Controllers;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ErrorResponseFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowFrontedPolicy",
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000");
            policy.AllowAnyHeader();
        });
});

var assemblies = new[]
{
    Assembly.GetAssembly(typeof(TaskController)),
    Assembly.GetAssembly(typeof(CreateTaskCommand)),
    Assembly.GetAssembly(typeof(TaskRepository))
};

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IValidator<CreateOrModifyTaskDto>, TaskValidator>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allowFrontedPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();