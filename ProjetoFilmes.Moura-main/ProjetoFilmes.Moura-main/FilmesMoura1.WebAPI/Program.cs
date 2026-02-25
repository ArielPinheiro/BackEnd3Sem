using FilmesMoura1.WebAPI.BdContextFilme;
using FilmesMoura1.WebAPI.Interfaces;
using FilmesMoura1.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o repositório ao container de injeção de dependência
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

// Adiciona serviço de Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Adiciona o mapeamento de Controllers
app.MapControllers();

app.Run();
