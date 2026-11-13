using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment._19.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment._19.Configurations
{
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(ca => new{ ca.AccountId,ca.CustomerId});
            builder.Property(ca => ca.AccountStatus)
                   .HasColumnType("varchar(50)");
            builder.Property(ca => ca.OwnerShipType)
                   .HasColumnType("varchar(50)");
            builder.Property(ca => ca.OwnerShipStartDate)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
