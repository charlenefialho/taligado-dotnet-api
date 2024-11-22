using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taligado.Models;

namespace Taligado.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<RegulacaoEnergia> RegulacoesEnergia { get; set; }
        public DbSet<Historico> Historicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            // Configurar tabelas
            modelBuilder.Entity<Empresa>().ToTable("empresa");
            modelBuilder.Entity<Filial>().ToTable("filial");
            modelBuilder.Entity<Endereco>().ToTable("endereco");
            modelBuilder.Entity<Dispositivo>().ToTable("dispositivo");
            modelBuilder.Entity<Sensor>().ToTable("sensor");
            modelBuilder.Entity<Alerta>().ToTable("alerta");
            modelBuilder.Entity<RegulacaoEnergia>().ToTable("regulacao_energia");
            modelBuilder.Entity<Historico>().ToTable("historico");

            // Configuração de chaves primárias
            modelBuilder.Entity<Empresa>().HasKey(e => e.IdEmpresa);
            modelBuilder.Entity<Filial>().HasKey(f => f.IdFilial);
            modelBuilder.Entity<Endereco>().HasKey(e => e.IdEndereco);
            modelBuilder.Entity<Dispositivo>().HasKey(d => d.IdDispositivo);
            modelBuilder.Entity<Sensor>().HasKey(s => s.IdSensor);
            modelBuilder.Entity<Alerta>().HasKey(a => a.IdAlerta);
            modelBuilder.Entity<RegulacaoEnergia>().HasKey(r => r.IdRegulacao);
            modelBuilder.Entity<Historico>().HasKey(h => h.IdHistorico);

            // Relacionamentos 1:N
            modelBuilder.Entity<Filial>()
                .HasOne(f => f.Empresa)
                .WithMany(e => e.Filiais)
                .HasForeignKey(f => f.Empresa_IdEmpresa);

            modelBuilder.Entity<Filial>()
                .HasOne(f => f.Endereco)
                .WithMany()
                .HasForeignKey(f => f.Endereco_IdEndereco);

            modelBuilder.Entity<Dispositivo>()
                .HasOne(d => d.Filial)
                .WithMany(f => f.Dispositivos)
                .HasForeignKey(d => d.Filial_IdFilial);

            modelBuilder.Entity<Alerta>()
                .HasOne(a => a.Sensor)
                .WithMany(s => s.Alertas)
                .HasForeignKey(a => a.Sensor_IdSensor);

            modelBuilder.Entity<Historico>()
                .HasOne(h => h.RegulacaoEnergia)
                .WithMany()
                .HasForeignKey(h => h.RegulacaoEnergia_IdRegulacao);

            // Relacionamento muitos-para-muitos: Dispositivo-Sensor
            modelBuilder.Entity<DispositivoSensor>()
                .HasKey(ds => new { ds.DispositivoId, ds.SensorId });

            modelBuilder.Entity<DispositivoSensor>()
                .HasOne(ds => ds.Dispositivo)
                .WithMany(d => d.DispositivoSensores)
                .HasForeignKey(ds => ds.DispositivoId);

            modelBuilder.Entity<DispositivoSensor>()
                .HasOne(ds => ds.Sensor)
                .WithMany(s => s.DispositivoSensores)
                .HasForeignKey(ds => ds.SensorId);

            // Relacionamento muitos-para-muitos: Sensor-Historico
            modelBuilder.Entity<HistoricoSensor>()
                .HasKey(hs => new { hs.HistoricoId, hs.SensorId });

            modelBuilder.Entity<HistoricoSensor>()
                .HasOne(hs => hs.Historico)
                .WithMany(h => h.HistoricoSensores)
                .HasForeignKey(hs => hs.HistoricoId);

            modelBuilder.Entity<HistoricoSensor>()
                .HasOne(hs => hs.Sensor)
                .WithMany(s => s.HistoricoSensores)
                .HasForeignKey(hs => hs.SensorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
