using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Models;
using PersonalBankRepositories.Data.Map;

namespace Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DepositModel> Deposits { get; set; }

        public DbSet<TransferModel> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepositMap());
            modelBuilder.ApplyConfiguration(new DepositMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
