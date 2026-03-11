using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);


//Configurar o contexto do banco de dados

builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//2. Registrar as repositories (injecao de dependencia)
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
//adiciona o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(Options =>
{
Options.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "API de Eventos",
    Description = "API para gerenciamento de eventos",
    TermsOfService = new Uri("https://drive.google.com/file/d/1VWD-PMIfm1fPuQST_ByhAspS7deVlJkB/view?usp=sharing"),
    Contact = new OpenApiContact
    {
        Name = "Ariel",
        Url = new Uri("https://github.com/ArielPinheiro")
    },
    License = new OpenApiLicense
    {
        Name = "Licensa de exemplo",
        Url = new Uri("https://lh3.googleusercontent.com/pw/AP1GczN5VJ3-9BbzTAsOdd6g4qgUlnQ5Sb-iJXUsZCX8He6WZBftqZjau3bjEzOP9Qe2HhRvEQRltzjxVZWntGCMnMuMDnNyjlDCavcD1KaK3nsIk0ZQQeMMWmgNiJts0Mo3q8fJe4--G0xsu0Tg0-pwUL4T=w408-h408-s-no?authuser=0")
    }
});
Options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    { 
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bota o token ai jão E TEM Q SER JWT:"
    });
    Options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
});


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(options => { });
    app.UseSwaggerUI(options =>
    { 
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Eventos v1");
        options.RoutePrefix = string.Empty;
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
