using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIDonChamba.Models
{
    public partial class DBDonChambaContext : DbContext
    {
        public DBDonChambaContext()
        {
        }

        public DBDonChambaContext(DbContextOptions<DBDonChambaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Ordene> Ordenes { get; set; } = null!;
        public virtual DbSet<OrdenesDetalle> OrdenesDetalles { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Sucursale> Sucursales { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DERFDEFULL;Database=DBDonChamba; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.PkIdCategoria);

                entity.Property(e => e.PkIdCategoria).HasColumnName("pk_idCategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Ordene>(entity =>
            {
                entity.HasKey(e => e.PkIdOrden);

                entity.Property(e => e.PkIdOrden).HasColumnName("pk_idOrden");

                entity.Property(e => e.Comentario).HasColumnName("comentario");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FkIdUsuario).HasColumnName("fk_idUsuario");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(20, 8)")
                    .HasColumnName("total");

                
            });

            modelBuilder.Entity<OrdenesDetalle>(entity =>
            {
                entity.HasKey(e => e.PkIdDetalle);

                entity.Property(e => e.PkIdDetalle).HasColumnName("pk_idDetalle");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(20, 8)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.FkIdOrden).HasColumnName("fk_idOrden");

                entity.Property(e => e.FkIdProducto).HasColumnName("fk_idProducto");

                entity.Property(e => e.Preciounidad)
                    .HasColumnType("decimal(20, 8)")
                    .HasColumnName("preciounidad");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(20, 8)")
                    .HasColumnName("subtotal");

                 
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.PkIdProducto);

                entity.Property(e => e.PkIdProducto).HasColumnName("pk_idProducto");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FkIdCategoria).HasColumnName("fk_idCategoria");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(20, 8)")
                    .HasColumnName("precio");


            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.PkIdSucursal);

                entity.Property(e => e.PkIdSucursal).HasColumnName("pk_idSucursal");

                entity.Property(e => e.Direccion).HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.PkIdUsuario);

                entity.Property(e => e.PkIdUsuario).HasColumnName("pk_idUsuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Celular)
                    .HasMaxLength(25)
                    .HasColumnName("celular");

                entity.Property(e => e.Contrasena).HasColumnName("contrasena");

                entity.Property(e => e.FkIdSucursal).HasColumnName("fk_idSucursal");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .HasColumnName("telefono");
                
                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(18)
                    .HasColumnName("usuario");

                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
