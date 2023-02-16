using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBankModels.Models;


namespace PersonalBankRepositories.Data.Map
{
    public class TransferMap : IEntityTypeConfiguration<TransferModel>
    {
        public void Configure(EntityTypeBuilder<TransferModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.AccountNumber).IsRequired();
        }
    }
}
