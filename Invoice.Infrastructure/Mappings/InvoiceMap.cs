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
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.ClientId)
                .IsRequired()   
                .HasColumnName("ClientId")
                .HasColumnType("BIGINT");

            builder.Property(x => x.SerialNumber)
                .IsRequired()
                .HasColumnName("SerialNumber")
                .HasColumnType("INT");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasColumnType("INT");

            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnName("Total")
                .HasColumnType("DECIMAL(18,2)")
                .HasPrecision(18,2);
        }
    }
}
