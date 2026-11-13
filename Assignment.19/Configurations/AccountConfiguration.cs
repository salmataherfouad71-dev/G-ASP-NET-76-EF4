using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment._19.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment._19.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a=>a.AccountNumber);
            builder.Property(a=>a.AccountType)
                   .HasColumnType("varchar(50)");
            builder.Property(a => a.CurrentBalance)
                   .HasColumnType("decimal(18,2)");
            builder.Property(a => a.OpeningDate)
                   .HasDefaultValueSql("GETDATE()");

        }
    }
}
