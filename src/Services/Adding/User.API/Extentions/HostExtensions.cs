using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace User.API.Extentions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
            where TContext : DbContext
        {
            int retryForAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                try
                {
                    context.Database.Migrate();
                }
                catch (SqlException ex)
                {
                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }
                    else
                    {

                        throw;
                    }
                }
            }

            return host;
        }
        private static void InvokeSeeder<TContext>(TContext context)
    where TContext : DbContext
        {
            context.Database.Migrate();
        }
    }
}

