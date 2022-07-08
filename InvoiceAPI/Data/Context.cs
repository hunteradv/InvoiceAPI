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

            //1:n Item e Product
            modelBuilder.Entity<Item>()
                .HasOne(item => item.Product)
                .WithMany(product => product.Items)
                .HasForeignKey(item => item.ProductId);


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

            //precision
            modelBuilder.Entity<Item>().Property(item => item.TotalItem).HasPrecision(18, 2);
            modelBuilder.Entity<Item>().Property(item => item.UnitValue).HasPrecision(18, 2);
            modelBuilder.Entity<Payment>().Property(payment=> payment.Value).HasPrecision(18, 2);
            modelBuilder.Entity<Invoice>().Property(invoice => invoice.Total).HasPrecision(18, 2);
            modelBuilder.Entity<Product>().Property(product => product.UnitValue).HasPrecision(18, 2);            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public object Where { get; internal set; }
    }
}
