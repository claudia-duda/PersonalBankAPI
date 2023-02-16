using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBankModels.Models;


namespace PersonalBankRepositories.Data.Map
{
    public class DepositMap : IEntityTypeConfiguration<DepositModel>
    {
        public void Configure(EntityTypeBuilder<DepositModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.AccountNumber).IsRequired();
            builder.Property(x => x.dateTransaction).IsRequired();
        }
    }
}
