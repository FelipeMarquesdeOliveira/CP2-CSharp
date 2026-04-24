using Microsoft.EntityFrameworkCore;
using CP2_CSharp.Models;

namespace CP2_CSharp.Data;

public class ClinicDbContext : DbContext
{
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Consulta> Consultas => Set<Consulta>();
    public DbSet<Prontuario> Prontuarios => Set<Prontuario>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=DB_FIAP_Clinic;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Paciente
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("Paciente");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Cpf).IsRequired().HasMaxLength(14);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Telefone).IsRequired().HasMaxLength(20);
            entity.Property(p => p.DataNascimento).IsRequired();
            entity.Property(p => p.DataCadastro).IsRequired();

            entity.HasIndex(p => p.Cpf).IsUnique();
            entity.HasIndex(p => p.Email).IsUnique();
        });

        // Medico
        modelBuilder.Entity<Medico>(entity =>
        {
            entity.ToTable("Medico");
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Nome).IsRequired().HasMaxLength(100);
            entity.Property(m => m.Crm).IsRequired().HasMaxLength(20);
            entity.Property(m => m.Especialidade).IsRequired().HasMaxLength(50);
            entity.Property(m => m.Email).IsRequired().HasMaxLength(100);
            entity.Property(m => m.Telefone).IsRequired().HasMaxLength(20);

            entity.HasIndex(m => m.Crm).IsUnique();
        });

        // Consulta - Relacionamento 1:N com Paciente e Medico
        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.ToTable("Consulta");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.DataHora).IsRequired();
            entity.Property(c => c.Status).IsRequired().HasMaxLength(20);
            entity.Property(c => c.Observacoes).HasMaxLength(500);
            entity.Property(c => c.DataCadastro).IsRequired();

            entity.HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Medico)
                .WithMany(m => m.Consultas)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Prontuario - Relacionamento 1:1 com Consulta
        modelBuilder.Entity<Prontuario>(entity =>
        {
            entity.ToTable("Prontuario");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Diagnostico).IsRequired().HasMaxLength(500);
            entity.Property(p => p.Prescricao).HasMaxLength(500);
            entity.Property(p => p.Observacoes).HasMaxLength(500);
            entity.Property(p => p.DataProntuario).IsRequired();

            entity.HasOne(p => p.Paciente)
                .WithMany(pac => pac.Prontuarios)
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Consulta)
                .WithOne(c => c.Prontuario)
                .HasForeignKey<Prontuario>(p => p.ConsultaId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
