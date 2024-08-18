using Microsoft.EntityFrameworkCore;
using PackingListApp.Domain.Entities;
using PackingListApp.Domain.ValueObjects;
using PackingListApp.Infrastructure.EF.Config;

namespace PackingListApp.Infrastructure.EF.Contexts;
internal sealed class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
        
    }

    public DbSet<PackingList> PackingLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("packing");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<PackingList>(configuration);
        modelBuilder.ApplyConfiguration<PackingItem>(configuration);
        
    }
}
