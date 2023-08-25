using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servico de controllers
builder.Services.AddControllers();

//Adiciona o gerador do swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filme",
        Description = "API para gerenciamento de filme - inicio sprint 2 API",
        Contact = new OpenApiContact
        {
            Name = "Fernando",
            Url = new Uri("https://github.com/FernandinnnQ145")
        }
    });

    //Configura o swagger para utilizar um arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//Mapear os controllers
app.MapControllers();

app.Run();
