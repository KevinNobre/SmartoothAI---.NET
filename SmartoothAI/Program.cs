using Microsoft.EntityFrameworkCore;
using SmartoothAI.Infrastructure.Data;
using SmartoothAI.Infrastructure.Repositories;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados Oracle
builder.Services.AddDbContext<SmartoothDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Registra os repositórios
builder.Services.AddScoped<IUsuarioPacienteRepository, UsuarioPacienteRepository>();
builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();

// Registra os serviços de negócios
builder.Services.AddScoped<UsuarioPacienteService>();

builder.Services.AddControllersWithViews();

// Configuração de redirecionamento HTTPS
builder.Services.AddHttpsRedirection(options => options.HttpsPort = 5001);

var app = builder.Build();

// Configuração do pipeline de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
