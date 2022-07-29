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
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnName("Value")
                .HasColumnType("DECIMAL(18,2)")
                .HasPrecision(18,2);

            builder.Property(x => x.PaymentType)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("PaymentType")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.InvoiceId)
                .IsRequired()
                .HasColumnName("InvoiceId")
                .HasColumnType("BIGINT");
        }
    }
}
