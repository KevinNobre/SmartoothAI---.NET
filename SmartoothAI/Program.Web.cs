using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static void ConfigureWebApp(WebApplicationBuilder builder)
    {
        // Adicionando serviços relacionados à Web
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer(); // Para expor as APIs, se necessário
    }

    public static void UseWebApp(WebApplication app)
    {
        // Configuração do pipeline para requisições HTTP
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        // Mapeando as rotas dos controladores
        app.MapControllers();
    }
}
