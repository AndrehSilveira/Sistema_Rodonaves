using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sistema_Rodonaves.Models;

namespace Sistema_Rodonaves.Data
{
    public partial class Api_Crud_CsharpContext : DbContext
    {
        public Api_Crud_CsharpContext()
        {
        }

        public Api_Crud_CsharpContext(DbContextOptions<Api_Crud_CsharpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colaboradore> Colaboradores { get; set; } = null!;
        public virtual DbSet<Unidade> Unidades { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HLRFOVS;DataBase=Api_Crud_Csharp;User Id=sa;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaboradore>(entity =>
            {
                entity.Property(e => e.IdUnidade).HasColumnName("idUnidade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.HasOne(d => d.IdUnidadeNavigation)
                    .WithMany(p => p.Colaboradores)
                    .HasForeignKey(d => d.IdUnidade)
                    .HasConstraintName("FK_Unidades_IdUnidade");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Colaboradores)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Colaboradores_IdColaborador");
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.ToTable("unidades");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Login).HasMaxLength(100);

                entity.Property(e => e.Senha).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
