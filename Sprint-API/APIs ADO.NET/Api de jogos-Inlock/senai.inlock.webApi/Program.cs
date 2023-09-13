using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servico de controllers
builder.Services.AddControllers();

//Adiciona servicos de autenticacao JWT Bears
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";

})

//Define os parametros de validacao do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem esta solicitando
        ValidateIssuer = true,

        //Valida quem esta recebendo
        ValidateAudience = true,

        //Define se o tempo de expiracao do token sera validado
        ValidateLifetime = true,

        //Forma de criptografia e ainda validacao da chave de autenticacao
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expiracao do token 
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde esta vindo (issuer)
        ValidIssuer = "Webapi.jogo",

        //Para onde esta indo (audience)
        ValidAudience = "Webapi.jogo"
    };
});

//Adiciona o gerador do swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filme",
        Description = "API para gerenciamento de jogo - inicio sprint 2 API",
        Contact = new OpenApiContact
        {
            Name = "Fernando",
            Url = new Uri("https://github.com/FernandinnnQ145")
        }
    });

    //Configura o swagger para utilizar um arquivo XML gerado
   // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    //Usando a autenticacao do swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }

            },
            new string[]{}
        }

    });
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

//Usar autenticao
app.UseAuthentication();

//Usar autorizacao
app.UseAuthorization();


//Mapear os controllers
app.MapControllers();

app.Run();
