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
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.Property(m => m.FullName)
                  .HasColumnType("varchar(200)");
            builder.Property(m => m.PhoneNumber)
                   .HasColumnType("varchar(50)");
            builder.Property(m => m.Email)
                   .HasColumnType("varchar(150)");
            builder.Property(m => m.HireDate)
                   .HasDefaultValueSql("GETDATE()");
            builder.HasData(new Manager[] 
            { 
                new Manager{ Id=1,FullName="Ahmad Mostafa",Email="Ahmad99@gmail.com",PhoneNumber="+201076900876"},
                new Manager{ Id=2,FullName="Omar Waleed",Email="Omar02@gmail.com",PhoneNumber="+201186401832"}
            });
        }
    }
}
