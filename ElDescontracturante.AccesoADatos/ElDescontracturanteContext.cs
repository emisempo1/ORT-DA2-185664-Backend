using ElDescontracturante.Dominio;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElDescontracturante.AccesoADatos
{
    public class ElDescontracturanteContext:DbContext
    {
        public DbSet<Audio> Audios { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<Playlist_Audio> Playlists_Audio { get; set; }

        public DbSet<Categoria_Playlist> Categoria_Playlist { get; set; }

        public DbSet<Token> Tokens { get; set; }


        public ElDescontracturanteContext() { }


        public ElDescontracturanteContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audio>()
                .HasKey(c => c.Nombre);

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.NombreCategoria);

            modelBuilder.Entity<Playlist>()
                .HasKey(c => c.Nombre);

            modelBuilder.Entity<Token>()
               .HasKey(c => c.Id);

            modelBuilder.Entity<Administrador>()
              .HasKey(c => c.Email);

            modelBuilder.Entity<Psicologo>()
              .HasKey(c => c.Email);

            modelBuilder.Entity<Cita>()
           .HasKey(c => c.ID);

            modelBuilder.Entity<Playlist_Audio>()
               .HasKey(c => new { c.NombrePlaylist,c.NombreAudio});

            modelBuilder.Entity<Categoria_Playlist>()
              .HasKey(c => new { c.Categoria, c.NombrePlaylist });

            modelBuilder.Entity<Problematica_Psicologo>()
             .HasKey(c => new { c.Email,c.NombreProblematica });

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database = Descontracturante;Integrated Security=True");

        }


    }
}
