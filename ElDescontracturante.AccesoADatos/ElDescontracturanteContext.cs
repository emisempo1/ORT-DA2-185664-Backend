﻿using ElDescontracturante.Dominio;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElDescontracturante.AccesoADatos
{
    public class ElDescontracturanteContext:DbContext
    {
        public DbSet<Audio> Audios { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

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
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database = Descontracturante;Integrated Security=True");

        }


    }
}