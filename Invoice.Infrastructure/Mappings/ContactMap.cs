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
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.ContactInfo)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("ContactInfo")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.ContactType)
                .IsRequired()
                .HasColumnName("ContactType")
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.ClientId)
                .IsRequired()
                .HasColumnName("ClientId")
                .HasColumnType("BIGINT");
        }
    }
}
