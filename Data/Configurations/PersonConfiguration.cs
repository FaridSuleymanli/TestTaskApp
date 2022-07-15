using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskApp.Models;

namespace TestTaskApp.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .HasPrincipalKey(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
