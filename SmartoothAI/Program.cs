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
builder.Services.AddScoped<IProntuarioRepository, ProntuarioRepository>();

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

// Rota padrão, para qualquer URL que não se encaixe nas rotas personalizadas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // URL padrão, Home/Index é o padrão



app.Run();
