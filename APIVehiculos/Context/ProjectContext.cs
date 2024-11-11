using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculo");

            entity.Property(v => v.Marca).IsRequired();
            entity.Property(v => v.Modelo).IsRequired();
            entity.Property(v => v.PrecioPorDia).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(v => v.EstaDisponible).IsRequired();
        });

        modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(r => r.Estado).IsRequired();
                entity.HasOne(r => r.Vehiculo).WithMany(v => v.reservas).HasForeignKey(r => r.VehiculoId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.Usuario).WithMany(u => u.reserva).HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

                // Restricción de fecha para evitar reservas en fechas pasadas
                entity.ToTable(t => t.HasCheckConstraint("CK_Reserva_Fecha", "FechaInicio >= GETDATE()"));
            });

    }
}
