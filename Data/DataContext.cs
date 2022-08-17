using Microsoft.EntityFrameworkCore;
using OpenBanking.Data.Models;

namespace OpenBanking.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Participant> Participant { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}
