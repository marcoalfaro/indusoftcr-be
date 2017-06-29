using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain
{
    public partial class sandboxContext : DbContext
    {
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cotizacion> Cotizacion { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Empresaconfig> Empresaconfig { get; set; }
        public virtual DbSet<Linea> Linea { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Precio> Precio { get; set; }
        public virtual DbSet<Tipocambio> Tipocambio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=sandbox;Username=postgres;Password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.Contactocorreo).HasColumnName("contactocorreo");

                entity.Property(e => e.Contactoextension).HasColumnName("contactoextension");

                entity.Property(e => e.Contactonombre).HasColumnName("contactonombre");

                entity.Property(e => e.Contactotelefono).HasColumnName("contactotelefono");

                entity.Property(e => e.Empresaid).HasColumnName("empresaid");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.Empresaid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("cliente_empresaid_fkey");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.ToTable("cotizacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Altura).HasColumnName("altura");

                entity.Property(e => e.Aplicada).HasColumnName("aplicada");

                entity.Property(e => e.Base).HasColumnName("base");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Cuatricromia).HasColumnName("cuatricromia");

                entity.Property(e => e.Cubrimiento).HasColumnName("cubrimiento");

                entity.Property(e => e.Divancho).HasColumnName("divancho");

                entity.Property(e => e.Divlargo).HasColumnName("divlargo");

                entity.Property(e => e.Doblez).HasColumnName("doblez");

                entity.Property(e => e.Empresaid).HasColumnName("empresaid");

                entity.Property(e => e.Fecaplicada).HasColumnName("fecaplicada");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Fecregistro).HasColumnName("fecregistro");

                entity.Property(e => e.Laminas).HasColumnName("laminas");

                entity.Property(e => e.Lineaid).HasColumnName("lineaid");

                entity.Property(e => e.Materialid).HasColumnName("materialid");

                entity.Property(e => e.Montaje).HasColumnName("montaje");

                entity.Property(e => e.Numpedido).HasColumnName("numpedido");

                entity.Property(e => e.Observacion).HasColumnName("observacion");

                entity.Property(e => e.Otro).HasColumnName("otro");

                entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

                entity.Property(e => e.Porcevento).HasColumnName("porcevento");

                entity.Property(e => e.Precioarte).HasColumnName("precioarte");

                entity.Property(e => e.Preciocorte).HasColumnName("preciocorte");

                entity.Property(e => e.Precioimpresion).HasColumnName("precioimpresion");

                entity.Property(e => e.Preciomaterial).HasColumnName("preciomaterial");

                entity.Property(e => e.Preciomolde).HasColumnName("preciomolde");

                entity.Property(e => e.Preciopositivo).HasColumnName("preciopositivo");

                entity.Property(e => e.Preciosolvente).HasColumnName("preciosolvente");

                entity.Property(e => e.Preciotintas).HasColumnName("preciotintas");

                entity.Property(e => e.Preciounitario).HasColumnName("preciounitario");

                entity.Property(e => e.Rendimiento).HasColumnName("rendimiento");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.Tintas).HasColumnName("tintas");

                entity.Property(e => e.Tipocambioid).HasColumnName("tipocambioid");

                entity.Property(e => e.Totalcol).HasColumnName("totalcol");

                entity.Property(e => e.Totalusd).HasColumnName("totalusd");

                entity.Property(e => e.Troquel).HasColumnName("troquel");

                entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

                entity.Property(e => e.Vendedorid).HasColumnName("vendedorid");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Clienteid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("cotizacion_clienteid_fkey");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Empresaid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("cotizacion_empresaid_fkey");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Materialid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("cotizacion_materialid_fkey");

                entity.HasOne(d => d.Tipocambio)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Tipocambioid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("cotizacion_tipocambioid_fkey");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Usuarioid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("cotizacion_usuarioid_fkey");

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Vendedorid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("cotizacion_vendedorid_fkey");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Empresaconfig>(entity =>
            {
                entity.ToTable("empresaconfig");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.Direccion).HasColumnName("direccion");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.Impuestoventa).HasColumnName("impuestoventa");

                entity.Property(e => e.Precioarte)
                    .HasColumnName("precioarte")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Preciocorte)
                    .HasColumnName("preciocorte")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Preciohoraimpresion)
                    .HasColumnName("preciohoraimpresion")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Preciomolde)
                    .HasColumnName("preciomolde")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Preciopositivo)
                    .HasColumnName("preciopositivo")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Preciosolvente)
                    .HasColumnName("preciosolvente")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Preciotinta)
                    .HasColumnName("preciotinta")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Preciovelocidad)
                    .HasColumnName("preciovelocidad")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Utilidad).HasColumnName("utilidad");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Empresaconfig)
                    .HasForeignKey<Empresaconfig>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("empresaconfig_id_fkey");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.ToTable("linea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Empresaid).HasColumnName("empresaid");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Linea)
                    .HasForeignKey(d => d.Empresaid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("linea_empresaid_fkey");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("material");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Altura).HasColumnName("altura");

                entity.Property(e => e.Base).HasColumnName("base");

                entity.Property(e => e.Codigoinventario).HasColumnName("codigoinventario");

                entity.Property(e => e.Costoinventario).HasColumnName("costoinventario");

                entity.Property(e => e.Empresaid).HasColumnName("empresaid");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.Empresaid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("material_empresaid_fkey");
            });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.ToTable("precio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Arte).HasColumnName("arte");

                entity.Property(e => e.Corte).HasColumnName("corte");

                entity.Property(e => e.Empresaid).HasColumnName("empresaid");

                entity.Property(e => e.Horaimpresion).HasColumnName("horaimpresion");

                entity.Property(e => e.Molde).HasColumnName("molde");

                entity.Property(e => e.Positivo).HasColumnName("positivo");

                entity.Property(e => e.Solvente).HasColumnName("solvente");

                entity.Property(e => e.Tinta).HasColumnName("tinta");

                entity.Property(e => e.Velocidad).HasColumnName("velocidad");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Precio)
                    .HasForeignKey(d => d.Empresaid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("precio_empresaid_fkey");
            });

            modelBuilder.Entity<Tipocambio>(entity =>
            {
                entity.ToTable("tipocambio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Empresaid).HasColumnName("empresaid");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Tipocambio)
                    .HasForeignKey(d => d.Empresaid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("tipocambio_empresaid_fkey");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Borrar).HasColumnName("borrar");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave");

                entity.Property(e => e.Cotizar).HasColumnName("cotizar");

                entity.Property(e => e.Crear).HasColumnName("crear");

                entity.Property(e => e.Empresaid).HasColumnName("empresaid");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.Property(e => e.Nombreusuario)
                    .IsRequired()
                    .HasColumnName("nombreusuario");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Empresaid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("usuario_empresaid_fkey");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("vendedor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Beeper).HasColumnName("beeper");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Empresaid).HasColumnName("empresaid");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Vendedor)
                    .HasForeignKey(d => d.Empresaid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("vendedor_empresaid_fkey");
            });
        }
    }
}