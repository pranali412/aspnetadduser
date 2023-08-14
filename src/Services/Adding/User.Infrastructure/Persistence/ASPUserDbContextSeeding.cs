using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using User.Domain.Entities;

namespace User.Infrastructure.Persistence
{
    public class ASPUserDbContextSeeding
    {
        private ILogger<ASPUserDbContextSeeding> _logger;
        private ASPUserDbContext _dbContext;
        private Microsoft.Extensions.Hosting.IHostingEnvironment _env;
        public async Task SeedAsync(Microsoft.Extensions.Hosting.IHostingEnvironment env, ASPUserDbContext dbContext, ILogger<ASPUserDbContextSeeding> logger, int retry = 0)
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.AddRange(GetPreconfiguredUsers());
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ASPUserDbContext).Name);
            }
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _env = env ?? throw new ArgumentNullException(nameof(env));
            int retryForAvailablity = retry;



            //Create Stored Procedure
            CreateStoreProcedure();
        }



        private void CreateStoreProcedure()
        {
            DataTable dtUpdateQuery = new();
            dtUpdateQuery.Columns.Add("Query");
            dtUpdateQuery.Columns.Add("QueryFileName");
            string line;
            string dataLine = "";
            //Console.Write($"--> Web Root Path: {Path.Combine(_env.WebRootPath, "SPs")}");
            Console.Write($"--> Content Root Path: {Path.Combine(_env.ContentRootPath, "SPs")}");
            //string[] files = Directory.GetFiles(Path.Combine(_env.WebRootPath, "SPs"));
            string[] files = Directory.GetFiles(Path.Combine(_env.ContentRootPath, "StoredProcedure"));
            for (int i = 0; i < files.Length; i++)
            {
                Console.Write($"\n--> Creating SPs: {files[i]}\n");
                dataLine = "";
                StreamReader file = new(files[i]);
                while ((line = file.ReadLine()) != null)
                {
                    dataLine = dataLine + "\n" + line;
                }
                dtUpdateQuery.Rows.Add(dataLine, files[i]);
                file.Close();
            }
            for (int i = 0; i < dtUpdateQuery.Rows.Count; i++)
            {
                try
                {
                    string? query = dtUpdateQuery.Rows[i]["Query"].ToString();
                    DbSpFunction(query);
                }
                catch (Exception ex)
                {
                    string? query = dtUpdateQuery.Rows[i]["Query"].ToString();
                    _logger.LogError(ex, $"\nEXCEPTION ERROR while creating store procedure: {query}\n");
                }
            }
        }
        private void DbSpFunction(string? query)
        {
            using var command = _dbContext?.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            _dbContext?.Database.OpenConnection();
            _ = command.ExecuteNonQuery();
        }

        private static IEnumerable<Userr> GetPreconfiguredUsers()
        {
            return new List<Userr>
            {
                new Userr() {


                        LastModifiedDate = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        CreatedBy = "",
                        LastModifiedBy = ""

                }
            };
        }
    }

}

