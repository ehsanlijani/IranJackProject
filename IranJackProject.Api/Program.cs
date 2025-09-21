using IranJackProject.Application;
using IranJackProject.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors();

#region Add Dependecies

builder.Services
    .RegisterInfrastructureConfiguration(builder.Configuration)
    .RegisterApplicationConfigurations(builder.Configuration);

#endregion Add Dependecies


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
