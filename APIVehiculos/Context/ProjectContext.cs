
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
                modelBuilder.Entity<Reserva>().ToTable("Reserves");

                entity.Property(r => r.FechaInicio).IsRequired();
                entity.Property(r => r.FechaFin).IsRequired();
                entity.Property(r => r.Estado).IsRequired();

                //Relaciones
                entity.HasOne(r => r.Usuario).WithMany().OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.vehiculo).WithMany().HasForeignKey(r => r.VehiculoId).OnDelete(DeleteBehavior.Restrict);


            }
        );
    }
}