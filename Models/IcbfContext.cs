using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ICBF_3.Models;

public partial class IcbfContext : DbContext
{
    public IcbfContext()
    {
    }

    public IcbfContext(DbContextOptions<IcbfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<AvancesAcademico> AvancesAcademicos { get; set; }

    public virtual DbSet<Ep> Eps { get; set; }

    public virtual DbSet<Jardine> Jardines { get; set; }

    public virtual DbSet<Nino> Ninos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TipoDoc> TipoDocs { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.PkIdAsistencia).HasName("PK__asistenc__6DABF79D031BEAA2");

            entity.ToTable("asistencias");

            entity.Property(e => e.PkIdAsistencia).HasColumnName("pkIdAsistencia");
            entity.Property(e => e.DescripcionEstado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("descripcionEstado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FkIdNino).HasColumnName("fkIdNino");

            entity.HasOne(d => d.FkIdNinoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.FkIdNino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__asistenci__fkIdN__571DF1D5");
        });

        modelBuilder.Entity<AvancesAcademico>(entity =>
        {
            entity.HasKey(e => e.PkIdAvance).HasName("PK__avances___37A75E1E6B6E5725");

            entity.ToTable("avances_academicos");

            entity.Property(e => e.PkIdAvance).HasColumnName("pkIdAvance");
            entity.Property(e => e.AnoEscolar)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("anoEscolar");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(240)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaNota).HasColumnName("fechaNota");
            entity.Property(e => e.FkIdNino).HasColumnName("fkIdNino");
            entity.Property(e => e.Nivel)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("nivel");
            entity.Property(e => e.Notas)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("notas");

            entity.HasOne(d => d.FkIdNinoNavigation).WithMany(p => p.AvancesAcademicos)
                .HasForeignKey(d => d.FkIdNino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__avances_a__fkIdN__5812160E");
        });

        modelBuilder.Entity<Ep>(entity =>
        {
            entity.HasKey(e => e.PkIdEps).HasName("PK__eps__3A1EB51637BC9A83");

            entity.ToTable("eps");

            entity.Property(e => e.PkIdEps).HasColumnName("pkIdEps");
            entity.Property(e => e.CentroMedico)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("centro_medico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nit).HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Jardine>(entity =>
        {
            entity.HasKey(e => e.PkIdJardin).HasName("PK__jardines__3A633FA399DA1603");

            entity.ToTable("jardines");

            entity.Property(e => e.PkIdJardin).HasColumnName("pkIdJardin");
            entity.Property(e => e.Direccion)
                .HasMaxLength(260)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasMaxLength(260)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Nino>(entity =>
        {
            entity.HasKey(e => e.PkIdNino).HasName("PK__ninos__DCEE195B3800E589");

            entity.ToTable("ninos");

            entity.Property(e => e.PkIdNino).HasColumnName("pkIdNino");
            entity.Property(e => e.CiudadNacimiento)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("ciudadNacimiento");
            entity.Property(e => e.FkIdEps).HasColumnName("fkIdEps");
            entity.Property(e => e.FkIdJardin).HasColumnName("fkIdJardin");
            entity.Property(e => e.FkIdUsuario).HasColumnName("fkIdUsuario");
            entity.Property(e => e.Niup).HasColumnName("niup");
            entity.Property(e => e.TipoSangre)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipoSangre");

            entity.HasOne(d => d.FkIdEpsNavigation).WithMany(p => p.Ninos)
                .HasForeignKey(d => d.FkIdEps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ninos__fkIdEps__59063A47");

            entity.HasOne(d => d.FkIdJardinNavigation).WithMany(p => p.Ninos)
                .HasForeignKey(d => d.FkIdJardin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ninos__fkIdJardi__59FA5E80");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.Ninos)
                .HasForeignKey(d => d.FkIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ninos__fkIdUsuar__35BCFE0A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.PkIdRol).HasName("PK__roles__6116435DD84B6036");

            entity.ToTable("roles");

            entity.Property(e => e.PkIdRol).HasColumnName("pkIdRol");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoDoc>(entity =>
        {
            entity.HasKey(e => e.PkIdTipoDoc).HasName("PK__tipoDoc__7EDA73FAE5F12B1C");

            entity.ToTable("tipoDoc");

            entity.Property(e => e.PkIdTipoDoc).HasColumnName("pkIdTipoDoc");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.PkIdUsuario).HasName("PK__usuarios__F9EDFC1D9924EBF0");

            entity.ToTable("usuarios");

            entity.Property(e => e.PkIdUsuario).HasColumnName("pkIdUsuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(260)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.FkIdRol).HasColumnName("fkIdRol");
            entity.Property(e => e.FkIdTipoDoc).HasColumnName("fkIdTipoDoc");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.FkIdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuarios__fkIdRo__2F10007B");

            entity.HasOne(d => d.FkIdTipoDocNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkIdTipoDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuarios__fkIdTi__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
