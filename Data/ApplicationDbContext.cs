using Microsoft.EntityFrameworkCore;
using ProjectPessoa.Models;

namespace ProjectPessoa.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {        
    }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Endereco>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Pessoa>()
            .HasOne(p => p.Endereco)
            .WithMany()
            .HasForeignKey(p => p.EnderecoId);
    }
}
