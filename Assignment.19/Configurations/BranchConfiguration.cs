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
            builder.HasData(new Branch[]
            { 
                new Branch{Code="CAI-01",Name="Cairo Main Branch",PhoneNumber="+201173801193",Address="Nasr City",ManagerId=1 },
                new Branch{Code="CAI-02",Name="Alexandria Branch",PhoneNumber="+201029120765",Address="Burj Al Arab",ManagerId=2 }
            });
        }
    }
}
