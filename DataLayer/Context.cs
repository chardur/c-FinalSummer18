using System.Data.Entity;
using DataLayer.Models;

namespace DataLayer
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}