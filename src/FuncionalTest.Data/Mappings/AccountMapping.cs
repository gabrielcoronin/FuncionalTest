using FuncionalTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuncionalTest.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(c => c.Saldo)
                .IsRequired();

            builder.Ignore(c => c.Message);           

        }
    }
}
