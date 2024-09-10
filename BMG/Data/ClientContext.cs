using Microsoft.EntityFrameworkCore;
using BMG.Models;

namespace BMG.Data
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}