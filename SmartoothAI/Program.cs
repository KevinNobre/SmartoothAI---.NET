using Microsoft.EntityFrameworkCore;
using SmartoothAI.Infrastructure.Data;
using SmartoothAI.Infrastructure.Repositories;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Application.Services;
using SmartoothAI.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados Oracle
builder.Services.AddDbContext<SmartoothDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Registra o ConfigurationManager como Singleton
builder.Services.AddSingleton(provider =>
    AppConfigurationManager.GetInstance(provider.GetRequiredService<IConfiguration>()));


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

//Testando Singleton 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var appConfig1 = services.GetRequiredService<AppConfigurationManager>();
    var appConfig2 = services.GetRequiredService<AppConfigurationManager>();

    if (ReferenceEquals(appConfig1, appConfig2))
    {
        Console.WriteLine(" O Singleton está funcionando corretamente: ambas as instâncias são iguais.");
    }
    else
    {
        Console.WriteLine(" O Singleton NÃO está funcionando: foram criadas instâncias diferentes.");
    }
}

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
