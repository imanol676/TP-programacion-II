
using Microsoft.EntityFrameworkCore;

public class ProjectContext : DbContext
{

    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {

    }



    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {




        modelBuilder.Entity<Vehiculo>(entity =>
        {
            modelBuilder.Entity<Vehiculo>().ToTable("Vehicles");

            entity.Property(v => v.Marca).IsRequired();
            entity.Property(v => v.Modelo).IsRequired();
            entity.Property(v => v.PrecioPorDia).IsRequired();
            entity.Property(v => v.EstaDisponible).IsRequired();
        });

        modelBuilder.Entity<Reserva>(entity =>
            {
            entity.HasKey(r => r.IdReserva);
            // Configurar IdReserva como identidad
            entity.Property(r => r.IdReserva).ValueGeneratedOnAdd();

            entity.Property(r => r.Estado).IsRequired();

            entity.HasOne(r => r.vehiculo).WithMany(v => v.Reservas).HasForeignKey(r => r.VehiculoId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Usuario).WithMany(u => u.Reservas).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);

            // Restricción de fecha para evitar reservas en fechas pasadas
            entity.ToTable(t => t.HasCheckConstraint("CK_Reserva_Fecha", "FechaInicio >= GETDATE()"));
        });

    }
}