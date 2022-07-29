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
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.UnitValue)
                .IsRequired()
                .HasColumnName("UnitValue")
                .HasColumnType("DECIMAL(18,2)");

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnName("Quantity")
                .HasColumnType("INT");

            builder.Property(x => x.InvoiceId)
                .IsRequired()
                .HasColumnName("InvoiceId")
                .HasColumnType("BIGINT");

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("ProductId")
                .HasColumnType("BIGINT");
        }
    }
}
