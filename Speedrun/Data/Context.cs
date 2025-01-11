using Microsoft.EntityFrameworkCore;
using Speedrun.Models;

namespace Speedrun.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)  { }

        public DbSet<Oras> Orase {  get; set; }
        public DbSet<Tara> Tari {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oras>().ToTable("Oras");
            modelBuilder.Entity<Tara>().ToTable("Tara");
        }
    }
}
