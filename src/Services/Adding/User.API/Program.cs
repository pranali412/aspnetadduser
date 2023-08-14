using User.API;
using User.API.Extentions;
using User.Infrastructure.Persistence;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
               .Build()
               .MigrateDatabase<ASPUserDbContext>((context, services) =>
               {
                   IHostEnvironment? env = services.GetService<IHostEnvironment>();
                   // var logger = services.GetService<ILogger<ASPUserDbContextSeeding>>();
                   ILogger<ASPUserDbContextSeeding>? logger = services.GetService<ILogger<ASPUserDbContextSeeding>>();
                   new ASPUserDbContextSeeding()
                  .SeedAsync((Microsoft.Extensions.Hosting.IHostingEnvironment)env, context, logger)
                       .Wait();
               })
               .Run();

        // CreateHostBuilder(args)
        //.Build()
        // .MigrateDatabase<User.Infrastructure.Persistence.ASPUserDbContext>()
        //.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
    // .UseSerilog(SeriLogger.Configure)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
