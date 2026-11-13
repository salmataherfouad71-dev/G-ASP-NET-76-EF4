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
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b=>b.Code);
            builder.Property(b => b.Name)
                   .HasColumnType("varchar(150)");
            builder.Property(b => b.PhoneNumber)
                   .HasColumnType("varchar(50)");
            builder.Property(b => b.Address)
                   .HasColumnType("varchar(200)");
        }
    }
}
