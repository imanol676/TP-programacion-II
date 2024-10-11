
using Microsoft.EntityFrameworkCore;

public class ProjectContext : DbContext
{

    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {

    }


    public DbSet<User> Users { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            modelBuilder.Entity<User>().ToTable("Users");

            entity.Property(u => u.Username).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Password).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<User>().HasDiscriminator<string>("UserType").HasValue<Admin>("Admin");
        });

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

                //Una reserva tiene solo un usario, pero un usuario hace muchas reservas
                entity.HasOne(r => r.Usuario).WithMany(u => u.Reservas).HasForeignKey(r => r.UsuarioId).IsRequired();

                //Una reserva tiene un vehiculo, pero un vehiculo puede estar en ninguna o muchas reservas.
                entity.HasOne(r => r.vehiculo).WithMany(v => v.Reservas).HasForeignKey(r => r.VehiculoId).IsRequired();

            }
        );
    }
}