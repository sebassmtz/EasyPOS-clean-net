using EasyPOS.Application.DependencyInjection;
using EasyPOS.Infrastructure.DependencyInjection;
using Web.API.DependencyInjection;
using Web.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddAplicattion();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
