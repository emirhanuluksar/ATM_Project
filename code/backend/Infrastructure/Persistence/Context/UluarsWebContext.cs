using System.Diagnostics;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class UluarsWebContext : DbContext {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        const string connectionString = "Server=localhost;Database=uluarsite;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Post>? Posts { get; set; }

}
