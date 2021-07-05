using Labb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb.Data
{
	public class ApplicationDbContext : IdentityDbContext<Utilizador, IdentityRole<int>, int>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<PratoDoDium> PratoDoDia { get; set; }
        public virtual DbSet<PratoFavorito> PratoFavoritos { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<RestauranteFavorito> RestauranteFavoritos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=LabContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador)
                    .HasName("PK__Administ__254574288B0EC1BA");

                entity.Property(e => e.IdUtilizador).ValueGeneratedNever();

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithOne(p => p.Administrador)
                    .HasForeignKey<Administrador>(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__id_Ut__286302EC");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador)
                    .HasName("PK__Cliente__2545742888451838");

                entity.Property(e => e.IdUtilizador).ValueGeneratedNever();

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__id_Util__2B3F6F97");
            });

            modelBuilder.Entity<PratoDoDium>(entity =>
            {
                entity.HasKey(e => e.IdPrato)
                    .HasName("PK__PratoDoD__F8A3CCADC548BD1D");

                entity.Property(e => e.IdPrato).ValueGeneratedNever();

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.TipoPrato).IsUnicode(false);
            });

            modelBuilder.Entity<PratoFavorito>(entity =>
            {
                entity.HasKey(e => new { e.IdCliente, e.IdPrato })
                    .HasName("PK__Prato_Fa__F8064C9E76D9AA51");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.PratoFavoritos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prato_Fav__id_Cl__44FF419A");

                entity.HasOne(d => d.IdPratoNavigation)
                    .WithMany(p => p.PratoFavoritos)
                    .HasForeignKey(d => d.IdPrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prato_Fav__id_Pr__45F365D3");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador)
                    .HasName("PK__Restaura__254574289C9A4CB1");

                entity.Property(e => e.IdUtilizador).ValueGeneratedNever();

                entity.Property(e => e.DiaDescanso).IsUnicode(false);

                entity.Property(e => e.Gps).IsUnicode(false);

                entity.Property(e => e.HoraDeAbertura)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HoraDeFecho)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Morada).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.TipoEntrega).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoLocal).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoTakeaway).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithOne(p => p.Restaurante)
                    .HasForeignKey<Restaurante>(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__id_Ut__35BCFE0A");
            });

            modelBuilder.Entity<RestauranteFavorito>(entity =>
            {
                entity.HasKey(e => new { e.IdRestaurante, e.IdCliente })
                    .HasName("PK__Restaura__4F606914AE57BBBB");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.RestauranteFavoritos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__id_Cl__4222D4EF");

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.RestauranteFavoritos)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__id_Re__412EB0B6");
            });

            base.OnModelCreating(modelBuilder);
        }
       

    }
}


