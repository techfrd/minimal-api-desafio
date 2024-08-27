using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{   
    private readonly IConfiguration _configuracaoAppSettigs;
    public DbContexto(IConfiguration configuracaoAppSettigs)
    {
        _configuracaoAppSettigs = configuracaoAppSettigs;
    }
    public DbSet<Administrador> Administradores {get; set;} = default!;
    public DbSet<Veiculo> Veiculos {get; set;} = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador{
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "12345",
                Perfil = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuracaoAppSettigs.GetConnectionString("ConexaoPadrao")?.ToString();
            if(!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);

            }
        }   
    }
}