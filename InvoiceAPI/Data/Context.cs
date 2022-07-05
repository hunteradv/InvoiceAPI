using InvoiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options ) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(address => address.Client)
                .WithOne(client => client.Address)
                .HasForeignKey<Client>(c => c.AddressId);

            modelBuilder.Entity<Contact>()
                .HasOne(contact => contact.Client)
                .WithMany(client => client.Contacts)
                .HasForeignKey(contact => contact.ClientId);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
