using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Models;
using PersonalBankRepositories.Data.Map;

namespace PersonalBankRepositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DepositModel> Deposits { get; set; }
        public DbSet<TransferModel> Transfers { get; set; }
        public DbSet<WithdrawModel> Withdraws { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepositMap());
            modelBuilder.ApplyConfiguration(new TransferMap());
            modelBuilder.ApplyConfiguration(new WithdrawMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
