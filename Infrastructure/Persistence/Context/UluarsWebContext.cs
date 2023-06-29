using System.Diagnostics;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class UluarsWebContext : DbContext {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string connectionString = "Server=localhost;Port=5432;Database=Uluarsite;User Id=postgres;Password=100220;Integrated Security=true;";
        optionsBuilder.UseNpgsql(connectionString);
    }

}
