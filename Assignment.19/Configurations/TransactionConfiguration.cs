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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionNumber);
            builder.Property(t => t.TransactionDate)
                   .HasDefaultValueSql("GETDATE()");
            builder.Property(t => t.TransactionType)
                   .HasColumnType("varchar(50)");
            builder.Property(t => t.Amount)
                   .HasColumnType("decimal(18,2)");
            builder.Property(t => t.Note)
                   .HasColumnType("varchar(200)");
        }
    }
}
