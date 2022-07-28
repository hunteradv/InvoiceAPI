using InvoiceApi.Domain.Entities;
using InvoiceApi.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi.Infrastructure.Context
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext() { }

        public InvoiceContext(DbContextOptions<InvoiceContext> options ) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InvoiceAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactMap());


            ////1:1 Address e Client
            //modelBuilder.Entity<Client>()
            //    .HasOne(client => client.Address)
            //    .WithOne(address => address.Client)
            //    .HasForeignKey<Address>(address => address.ClientId);

            ////1:n Contact e CLient
            //modelBuilder.Entity<Contact>()
            //    .HasOne(contact => contact.Client)
            //    .WithMany(client => client.Contacts)
            //    .HasForeignKey(contact => contact.ClientId);

            ////1:n Item e Product
            //modelBuilder.Entity<Item>()
            //    .HasOne(item => item.Product)
            //    .WithMany(product => product.Items)
            //    .HasForeignKey(item => item.ProductId);


            ////Invoice

            ////1:n Payment e Invoice
            //modelBuilder.Entity<Payment>()
            //    .HasOne(payment => payment.Invoice)
            //    .WithMany(invoice => invoice.Payments)
            //    .HasForeignKey(payment => payment.InvoiceId);

            ////1:n Invoice e Client
            //modelBuilder.Entity<Invoice>()
            //    .HasOne(invoice => invoice.Client)
            //    .WithMany(client => client.Invoices)
            //    .HasForeignKey(invoice => invoice.ClientId);

            ////1:n Invoice e Item
            //modelBuilder.Entity<Item>()
            //    .HasOne(item => item.Invoice)
            //    .WithMany(invoice => invoice.Items)
            //    .HasForeignKey(item => item.InvoiceId);

            ////precision
            //modelBuilder.Entity<Item>().Property(item => item.TotalItem).HasPrecision(18, 2);
            //modelBuilder.Entity<Item>().Property(item => item.UnitValue).HasPrecision(18, 2);
            //modelBuilder.Entity<Payment>().Property(payment=> payment.Value).HasPrecision(18, 2);
            //modelBuilder.Entity<Invoice>().Property(invoice => invoice.Total).HasPrecision(18, 2);
            //modelBuilder.Entity<Product>().Property(product => product.UnitValue).HasPrecision(18, 2);            
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
    }
}
