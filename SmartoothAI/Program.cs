using Microsoft.EntityFrameworkCore;
using SmartoothAI.Infrastructure.Data;
using SmartoothAI.Infrastructure.Repositories;
using SmartoothAI.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<SmartoothDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionando serviços ao contêiner
builder.Services.AddScoped<IUsuarioPacienteRepository, UsuarioPacienteRepository>();
builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();

// Chamando configuração da camada web
WebConfiguration.ConfigureWebApp(builder);

var app = builder.Build();

// Usando o pipeline da camada web
WebConfiguration.UseWebApp(app);

app.Run();
