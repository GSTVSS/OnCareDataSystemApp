using System;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Colaborador> Colaboradores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Host=localhost;Database=DbOnCareDataSystem;Password=0v3rl0rd");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Nascimento).IsRequired();
            entity.Property(e => e.Sexo).IsRequired().HasMaxLength(1);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Senha).IsRequired();
            entity.Property(e => e.Admin).IsRequired();
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Nascimento).IsRequired();
            entity.Property(e => e.Sexo).IsRequired().HasMaxLength(1);
            entity.Property(e => e.Ceep).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Uf).IsRequired().HasMaxLength(2);
            entity.Property(e => e.NumeroCasa).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Endereco).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ContatoFamilia1).IsRequired().HasMaxLength(15);
            entity.Property(e => e.ContatoFamilia2).HasMaxLength(15);
            entity.Property(e => e.EmpresaResponsavel).IsRequired().HasMaxLength(100);
            entity.Property(e => e.EscalistaResponsavel).HasMaxLength(100);
            entity.Property(e => e.Valor).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Repasse).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Colaborador>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Nascimento).IsRequired();
            entity.Property(e => e.Sexo).IsRequired().HasMaxLength(1);
            entity.Property(e => e.Contato1).IsRequired().HasMaxLength(15);
            entity.Property(e => e.Contato2).HasMaxLength(15);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Senha).IsRequired();
        });
    }
}

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public string Sexo { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool Admin { get; set; }
}

public class Paciente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public string Sexo { get; set; }
    public string Ceep { get; set; }
    public string Uf { get; set; }
    public string NumeroCasa { get; set; }
    public string Endereco { get; set; }
    public string ContatoFamilia1 { get; set; }
    public string ContatoFamilia2 { get; set; }
    public string EmpresaResponsavel { get; set; }
    public string EscalistaResponsavel { get; set; }
    public decimal? Valor { get; set; }
    public decimal? Repasse { get; set; }
}

public class Colaborador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime Nascimento { get; set; }
    public string Sexo { get; set; }
    public string Contato1 { get; set; }
    public string Contato2 { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}