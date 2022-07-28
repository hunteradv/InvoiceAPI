using InvoiceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnName("Number")
                .HasColumnType("INT");

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("State")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("State")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Country")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.ClientId)
                .IsRequired()
                .HasColumnName("ClientId")
                .HasColumnType("BIGINT");
        }
    }
}
