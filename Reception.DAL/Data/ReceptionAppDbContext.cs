using Microsoft.EntityFrameworkCore;
using ReceptionApp.Models;

namespace ReceptionApp.Data
{
    public class ReceptionAppDbContext: DbContext
    {
        public ReceptionAppDbContext(DbContextOptions<ReceptionAppDbContext> options) : base(options) { }

        public DbSet<Recept> Receptions { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
