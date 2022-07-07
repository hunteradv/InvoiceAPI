using InvoiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options ) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1:1 Address e Client
            modelBuilder.Entity<Address>()
                .HasOne(address => address.Client)
                .WithOne(client => client.Address)
                .HasForeignKey<Client>(c => c.AddressId);

            //1:n Contact e CLient
            modelBuilder.Entity<Contact>()
                .HasOne(contact => contact.Client)
                .WithMany(client => client.Contacts)
                .HasForeignKey(contact => contact.ClientId);

            //Invoice

            //1:n Payment e Invoice
            modelBuilder.Entity<Payment>()
                .HasOne(payment => payment.Invoice)
                .WithMany(invoice => invoice.Payments)
                .HasForeignKey(payment => payment.InvoiceId);

            //1:n Invoice e Client
            modelBuilder.Entity<Invoice>()
                .HasOne(invoice => invoice.Client)
                .WithMany(client => client.Invoices)
                .HasForeignKey(invoice => invoice.ClientId);

            //1:n Invoice e Item
            modelBuilder.Entity<Item>()
                .HasOne(item => item.Invoice)
                .WithMany(invoice => invoice.Items)
                .HasForeignKey(item => item.InvoiceId);

            //1:n Item e Product
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
