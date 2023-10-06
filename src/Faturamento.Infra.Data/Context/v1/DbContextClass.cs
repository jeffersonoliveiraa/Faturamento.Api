using Faturamento.Domain.Entities.v1;
using Faturamento.Infra.Data.Mapping.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Faturamento.Infra.Data.Context.v1;

public class DbContextClass : DbContext
{
    protected readonly IConfiguration _configuration;

    public DbContextClass(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Faturamentos>? Faturamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FaturamentosMap());

        base.OnModelCreating(modelBuilder);
    }
}
