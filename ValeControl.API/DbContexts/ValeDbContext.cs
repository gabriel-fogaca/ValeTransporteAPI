using Microsoft.EntityFrameworkCore;
using ValeControl.API.Entities;

namespace ValeControl.API.DbContexts;

public class ValeDbContext(DbContextOptions<ValeDbContext> options) : DbContext(options)
{
    public DbSet<Funcionario> Funcionarios { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura a entidade Funcionario
        modelBuilder.Entity<Funcionario>()
            .Property(f => f.CustoDiario)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario { Id = 1, Nome = "João Silva", Escala = EscalaTrabalho.CincoxDois, CustoDiario = 50.00m, Ativo = true },
            new Funcionario { Id = 2, Nome = "Maria Santos", Escala = EscalaTrabalho.SeisxUm, CustoDiario = 60.00m, Ativo = true },
            new Funcionario { Id = 3, Nome = "Pedro Oliveira", Escala = EscalaTrabalho.SeisxDois, CustoDiario = 70.00m, Ativo = false },
            new Funcionario { Id = 4, Nome = "Ana Costa", Escala = EscalaTrabalho.DozeTrintaSeis, CustoDiario = 80.00m, Ativo = true }
        );

        base.OnModelCreating(modelBuilder); 
    }
}
