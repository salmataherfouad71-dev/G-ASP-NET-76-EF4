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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FullName)
                  .HasColumnType("varchar(200)");
            builder.Property(c => c.PhoneNumber)
                   .HasColumnType("varchar(50)");
            builder.Property(c => c.Address)
                   .HasColumnType("varchar(200)");
            builder.Property(c => c.Email)
                   .HasColumnType("varchar(150)");
            builder.Property(c => c.CustomerType)
                   .HasColumnType("varchar(50)");
            builder.Property(c => c.NationalId)
                   .HasColumnType("varchar(150)");
        }
    }
}
