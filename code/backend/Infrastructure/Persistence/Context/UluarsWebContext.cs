using System.Diagnostics;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class UluarsWebContext : DbContext {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        const string connectionString = "Server=localhost;Port=5432;Database=Uluarsite;User Id=postgres;Password=100220;Integrated Security=true;";
        optionsBuilder.UseNpgsql(connectionString);
    }

    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Post>? Posts { get; set; }

}
