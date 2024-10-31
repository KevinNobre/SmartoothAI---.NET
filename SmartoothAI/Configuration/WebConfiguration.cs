namespace SmartoothAI.WebAPI.Configurations
{
    public static class WebConfiguration
    {
        public static void ConfigureWebApp(WebApplicationBuilder builder)
        {// Configuração para MVC
            builder.Services.AddHttpsRedirection(options => options.HttpsPort = 5001); 
        }

        public static void UseWebApp(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); 
        }
    }
}
