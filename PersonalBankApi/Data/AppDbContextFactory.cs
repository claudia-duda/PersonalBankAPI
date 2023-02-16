using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories;

namespace PersonalBankApi.Data
{
    //Responsible to create a DbContext based on AppDbContext from other project
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(config.GetConnectionString("DataBase"),
                b => b.MigrationsAssembly("PersonalBank.Repositories"));

            return new AppDbContext(builder.Options);
        }
    }
}
