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
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("FirstName")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("LastName")
                .HasColumnType("VARCHAR(80)");
        }
    }
}
