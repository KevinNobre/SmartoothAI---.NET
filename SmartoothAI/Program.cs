using Microsoft.EntityFrameworkCore;
using SmartoothAI.Infrastructure.Data;
using SmartoothAI.Infrastructure.Repositories;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Application.Services;
using SmartoothAI.Infrastructure.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados Oracle
builder.Services.AddDbContext<SmartoothDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Registra o ConfigurationManager como Singleton
builder.Services.AddSingleton(provider =>
    AppConfigurationManager.GetInstance(provider.GetRequiredService<IConfiguration>()));

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SmartoothAI API",
        Version = "v1",
        Description = "O SmarTooth AI é um sistema inteligente voltado para otimizar serviços odontológicos.",
        Contact = new OpenApiContact
        {
            Name = "ByteBloom Tech",
            Url = new Uri("https://github.com/KevinNobre/SmartoothAI---.NET.git")
        }
    });

    var xmlFile = "SmartoothAI.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// Registra os repositórios
builder.Services.AddScoped<IUsuarioPacienteRepository, UsuarioPacienteRepository>();
builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
builder.Services.AddScoped<IProntuarioRepository, ProntuarioRepository>();
builder.Services.AddScoped<IDicaRepository, DicaRepository>();
builder.Services.AddScoped<ISistemaPontosRepository, SistemaPontosRepository>();
builder.Services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();

// Registra os serviços de negócios
builder.Services.AddScoped<UsuarioPacienteService>();

builder.Services.AddControllersWithViews();

// Configuração de redirecionamento HTTPS
builder.Services.AddHttpsRedirection(options => options.HttpsPort = 5001);

var app = builder.Build();

// Testando Singleton
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

// Middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Smartooth AI API v1");
    options.RoutePrefix = "swagger";
});

// Rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Detalhes}/{id?}");
});

// Inicia a aplicação
app.Run();
