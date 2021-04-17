﻿// <auto-generated />
using ElDescontracturante.AccesoADatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElDescontracturante.AccesoADatos.Migrations
{
    [DbContext(typeof(ElDescontracturanteContext))]
    [Migration("20210417190056_6")]
    partial class _6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElDescontracturante.Dominio.Audio", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<string>("NombreCreador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadDeTiempo")
                        .HasColumnType("int");

                    b.Property<string>("UrlImagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlMp3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Nombre");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("ElDescontracturante.Dominio.Categoria", b =>
                {
                    b.Property<int>("NombreCategoria")
                        .HasColumnType("int");

                    b.HasKey("NombreCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ElDescontracturante.Dominio.Categoria_Playlist", b =>
                {
                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("NombrePlaylist")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Categoria", "NombrePlaylist");

                    b.ToTable("Categoria_Playlist");
                });

            modelBuilder.Entity("ElDescontracturante.Dominio.Playlist", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Nombre");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("ElDescontracturante.Dominio.Playlist_Audio", b =>
                {
                    b.Property<string>("NombrePlaylist")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreAudio")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NombrePlaylist", "NombreAudio");

                    b.ToTable("Playlists_Audio");
                });
#pragma warning restore 612, 618
        }
    }
}
