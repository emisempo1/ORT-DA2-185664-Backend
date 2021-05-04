using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaCategoria : ILogicaCategoria
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;
        private readonly IAudioRepositorio audioRepositorio;

        public LogicaCategoria(ICategoriaRepositorio categoriaRepositorio, IAudioRepositorio audioRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
            this.audioRepositorio = audioRepositorio;
        }

        public void AgregarPlaylistsACategoria(Categoria unaCategoria)
        {
         categoriaRepositorio.AgregarPlaylistsACategoria(unaCategoria);
        }

        public Categoria ObtenerCategoria(string nombre)
        {
        
            Categoria categoria = categoriaRepositorio.ObtenerCategoria(nombre);

            List<Playlist> playlistConAudios = categoria.ListaPlaylist;
         

            for (int i = 0; i < playlistConAudios.Count; i++)
            {
                playlistConAudios[i].ListaAudios = audioRepositorio.ObtenerAudios(playlistConAudios[i]);

            }

            categoria.ListaPlaylist = playlistConAudios;

            return categoria;

        }

    
    }
}
