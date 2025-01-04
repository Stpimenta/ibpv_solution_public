/*estudar parte a parte depois*/
using System.Text;
using c___Api_Example;
using c___Api_Example.Application.Mapper;
using c___Api_Example.Application.Services.GeneratedUserToken;
using c___Api_Example.Application.Services.UserCryptography;
using c___Api_Example.data;
using c___Api_Example.repository;
using c___Api_Example.repository.Interfaces;
using c___Api_Example.Repository;
using c___Api_Example.Repository.Interfaces;
using c___Api_Example.Services;
using FluentValidation;
using IbpvDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// serviços para detectar as classes controllers e fazer endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//adicionar log de console
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

//buildar o configuration para acessar o settings
var configuration = builder.Configuration;

//a func dentro adicione a autorizaçao para o swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Adiciona um campo de entrada para inserir o JWT no Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});

//criptografia das senhas
builder.Services.AddTransient<IServiceUserPassCryptography,ServiceUserPassCryptography>();
//inejtando a criptografia
builder.Services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(configuration.GetValue<string>("AmbienteVar:pathdataprotection")!));
      
//injetando o mappgind dto
builder.Services.AddAutoMapper(typeof(DomainToDtosMapping));
// Configuração do banco de dados em memória /* refatorar */
builder.Services.AddDbContext<IbpvDataBaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("database");
    options.UseNpgsql(connectionString);
});


//injecao do servico de codigos de dizimista
builder.Services.AddTransient<IServiceGeneratedUserToken,ServiceGeneratedUserToken>();
//in jeçao de tokens jwt
builder.Services.AddTransient<ServiceGenerateToken>();
//Addscoped serve para injeçao de dependencia, aqui estou dizendo que onde tiver um Iusuario deve se instanciar um UsuarioRepositorio;
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IGastoRepositorio, GastoRepositorio>();
builder.Services.AddScoped<ICaixaRepositorio, CaixaRepositorio>();
builder.Services.AddScoped<IContribuicaoRepositorio, ContribuicaoRepositorio>();


//configura a autenticaçao na aplicação /refatorar/
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AmbienteVar:jwt")!)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});




var app = builder.Build();

// redirecionando caso ocorra error sem captura
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}else{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
