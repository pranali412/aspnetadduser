using User.API;
using User.API.Extentions;
using User.Infrastructure.Persistence;

public class Program
{
    public static void Main(string[] args)
    {


        CreateHostBuilder(args)
       .Build()
        .MigrateDatabase<UserDbContext>()
       .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
    // .UseSerilog(SeriLogger.Configure)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
