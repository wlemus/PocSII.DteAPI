using Microsoft.EntityFrameworkCore;
using PocSII.DteAPIApplicacion.Models;

namespace PocSII.DteAPIInfrastructure.Context {
    public class PocSIIDbContext : Microsoft.EntityFrameworkCore.DbContext {
        public PocSIIDbContext(DbContextOptions<PocSIIDbContext> options) : base(options) {
        }


        public virtual DbSet<ActividadEconomicaEntity> ActividadEconomicas { get; set; }

        public virtual DbSet<CiudadEntity> Ciudads { get; set; }

        public virtual DbSet<EmpresaEntity> Empresas { get; set; }

        public virtual DbSet<EmpresaActecoEntity> EmpresaActecos { get; set; }

        public virtual DbSet<EmpresaTelefonoEntity> EmpresaTelefonos { get; set; }

        public virtual DbSet<PaisEntity> Pais { get; set; }

        public virtual DbSet<RangoFolioEntity> RangoFolios { get; set; }

        public virtual DbSet<ResolucionDteEntity> ResolucionDtes { get; set; }

        public virtual DbSet<SucursalEntity> Sucursals { get; set; }

        public virtual DbSet<TipoDocumentoEntity> TipoDocumentos { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ActividadEconomicaEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__Activida__3214EC078771ABA5");

                entity.ToTable("ActividadEconomica");

                entity.HasIndex(e => e.Codigo, "IDX_ActividadEconomica_Codigo").IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Categoria).HasMaxLength(100);
                entity.Property(e => e.Codigo).HasMaxLength(10);
                entity.Property(e => e.Descripcion).HasMaxLength(255);
            });

            modelBuilder.Entity<CiudadEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__Ciudad__3214EC0706762CF2");

                entity.ToTable("Ciudad");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.Pais).WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ciudad__PaisId__7C4F7684");
            });

            modelBuilder.Entity<EmpresaEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__Empresa__3214EC075B14E302");

                entity.ToTable("Empresa");

                entity.HasIndex(e => e.Rut, "IX_Empresa").IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.Comuna).HasMaxLength(100);
                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");
                entity.Property(e => e.Direccion).HasMaxLength(200);
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
                entity.Property(e => e.Giro).HasMaxLength(200);
                entity.Property(e => e.ModificadoPor).HasMaxLength(100);
                entity.Property(e => e.RazonSocial).HasMaxLength(200);
                entity.Property(e => e.Rut).HasMaxLength(20);

                entity.HasOne(d => d.Ciudad).WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.CiudadId)
                    .HasConstraintName("FK_Empresa_Ciudad");
            });

            modelBuilder.Entity<EmpresaActecoEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__EmpresaA__3214EC07F9DF54BC");

                entity.ToTable("EmpresaActeco");

                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
                entity.Property(e => e.ModificadoPor).HasMaxLength(100);

                entity.HasOne(d => d.Acteco).WithMany(p => p.EmpresaActecos)
                    .HasForeignKey(d => d.ActecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa_ActividadEconomica");

                entity.HasOne(d => d.Empresa).WithMany(p => p.EmpresaActecos)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__EmpresaAc__Empre__45F365D3");


            });

            modelBuilder.Entity<EmpresaTelefonoEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__EmpresaT__3214EC07D7448EEF");

                entity.ToTable("EmpresaTelefono");

                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
                entity.Property(e => e.ModificadoPor).HasMaxLength(100);
                entity.Property(e => e.Telefono).HasMaxLength(20);

                entity.HasOne(d => d.Empresa).WithMany(p => p.EmpresaTelefonos)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__EmpresaTe__Empre__4316F928");
            });

            modelBuilder.Entity<PaisEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__Pais__3214EC0705391B6A");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Iso)
                    .HasMaxLength(100)
                    .HasColumnName("ISO");
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<RangoFolioEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__RangoFol__3214EC071EA6534B");

                entity.ToTable("RangoFolio");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
                entity.Property(e => e.ModificadoPor).HasMaxLength(100);
                entity.Property(e => e.TipoDocumentoCodigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Resolucion).WithMany(p => p.RangoFolios)
                    .HasForeignKey(d => d.ResolucionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RangoFoli__Resol__5812160E");

                entity.HasOne(d => d.TipoDocumentoCodigoNavigation).WithMany(p => p.RangoFolios)
                    .HasForeignKey(d => d.TipoDocumentoCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RangoFoli__TipoD__59063A47");
            });

            modelBuilder.Entity<ResolucionDteEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__Resoluci__3214EC074FF4B287");

                entity.ToTable("ResolucionDTE");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
                entity.Property(e => e.ModificadoPor).HasMaxLength(100);
                entity.Property(e => e.Observaciones).HasMaxLength(500);

                entity.HasOne(d => d.Sucursal).WithMany(p => p.ResolucionDtes)
                    .HasForeignKey(d => d.SucursalId)
                    .HasConstraintName("FK__Resolucio__Obser__5441852A");
            });

            modelBuilder.Entity<SucursalEntity>(entity => {
                entity.HasKey(e => e.Id).HasName("PK__Sucursal__6CB482E125DD8849");

                entity.ToTable("Sucursal");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.CodigoSiisucursal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CodigoSIISucursal");
                entity.Property(e => e.Comuna)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
                entity.Property(e => e.ModificadoPor).HasMaxLength(100);
                entity.Property(e => e.NombreSucursal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa).WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sucursal__Empres__49C3F6B7");
            });

            modelBuilder.Entity<TipoDocumentoEntity>(entity => {
                entity.HasKey(e => e.Codigo).HasName("PK__TipoDocu__06370DAD5574E669");

                entity.ToTable("TipoDocumento");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(suser_sname())");
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
                entity.Property(e => e.ModificadoPor).HasMaxLength(100);
                entity.Property(e => e.Nombre).HasMaxLength(200);
            });

           // OnModelCreatingPartial(modelBuilder);
        }

    //   partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}