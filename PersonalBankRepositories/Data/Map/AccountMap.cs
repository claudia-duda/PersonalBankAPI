using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBankModels.Models;


namespace PersonalBankRepositories.Data.Map
{
    public class AccounttMap : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ActualBalance).IsRequired();
        }
    }
}
