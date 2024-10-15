using Microsoft.EntityFrameworkCore;
using TM.Domain.Entities;

namespace TM.Persistence.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
{
    public DbSet<Ticket> Tickets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .Property(t => t.RowVersion)
            .IsRowVersion();
        base.OnModelCreating(modelBuilder);
    }
}
