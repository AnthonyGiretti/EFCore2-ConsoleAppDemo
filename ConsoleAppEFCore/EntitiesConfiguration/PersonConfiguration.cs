using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEFCore2.EntitiesConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.BusinessEntityID);
            builder.OwnsOne(x => x.Name).Property(c=> c.FirstName).HasColumnName("FirstName");
            builder.OwnsOne(x => x.Name).Property(c => c.MiddleName).HasColumnName("MiddleName");
            builder.OwnsOne(x => x.Name).Property(c => c.LastName).HasColumnName("LastName");
            builder.ToTable("Person", "Person");
        }
    }
}
