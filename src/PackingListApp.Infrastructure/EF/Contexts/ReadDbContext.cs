using Microsoft.EntityFrameworkCore;
using PackingListApp.Infrastructure.EF.Config;
using PackingListApp.Infrastructure.EF.Models;

namespace PackingListApp.Infrastructure.EF.Contexts;
internal sealed class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
        
    }

    public DbSet<PackingListReadModel> PackingLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("packing");

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
    }
}
