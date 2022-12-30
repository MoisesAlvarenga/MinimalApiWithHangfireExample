using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.OpenApi.Models;
using MinimalApi.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();


//#region swagger
    builder.Services.AddSwaggerGen();

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Estudos Gerais",
                Description = "Estudos gerais sobre diversos temas do Dot.Net",
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Name = "Moises Alvarenga",
                    Url = new Uri("https://github.com/MoisesAlvarenga"),
                }
            });
    });

//#endregion

//#region hangfire
    builder.Services.AddHangfire( op => {
        op.UseMemoryStorage();
    });
    builder.Services.AddHangfireServer();
//#endregion

var app = builder.Build();
app.UseHangfireDashboard();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estudos Gerais v1");
});
 

 app.MapMinimalApiEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
