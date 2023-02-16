using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBankModels.Models;


namespace PersonalBankRepositories.Data.Map
{
    public class WithdrawMap : IEntityTypeConfiguration<WithdrawModel>
    {
        public void Configure(EntityTypeBuilder<WithdrawModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.dateTransaction).IsRequired();
        }
    }
}
