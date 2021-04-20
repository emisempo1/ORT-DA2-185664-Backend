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

            modelBuilder.Entity<Playlist_Audio>()
               .HasKey(c => new { c.NombrePlaylist,c.NombreAudio});

            modelBuilder.Entity<Categoria_Playlist>()
              .HasKey(c => new { c.Categoria, c.NombrePlaylist });
       
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database = Descontracturante;Integrated Security=True");

        }


    }
}
