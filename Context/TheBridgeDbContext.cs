using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TheBridge.Data.Entities;

namespace TheBridge.Context
{
    public class TheBridgeDbContext: DbContext
    {
    public TheBridgeDbContext(DbContextOptions<TheBridgeDbContext> options)
        : base(options)
        {
        }

    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<City>()
            .HasOne(c => c.Country)
            .WithMany(cn => cn.Cities)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
}
