using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static void ConfigureWebApp(WebApplicationBuilder builder)
    {
        // Adicionando servi�os relacionados � Web
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer(); // Para expor as APIs, se necess�rio
    }

    public static void UseWebApp(WebApplication app)
    {
        // Configura��o do pipeline para requisi��es HTTP
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        // Mapeando as rotas dos controladores
        app.MapControllers();
    }
}
