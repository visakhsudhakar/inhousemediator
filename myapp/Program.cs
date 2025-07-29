using MediatR;
using System.Reflection;
using Infrastructure.DependencyInjection;
using FluentValidation.AspNetCore;
using Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR and Validation Behavior
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.Load("Application"));
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

// Add FluentValidation with validators from Application assembly
builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.Load("Application"));

// Register Infrastructure services using the extension method
builder.Services.AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
