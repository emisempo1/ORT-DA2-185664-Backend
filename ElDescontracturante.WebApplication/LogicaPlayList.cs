using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaPlayList:ILogicaPlaylist
    {
        private readonly IPlaylistRepositorio playlistRepositorio;

        public LogicaPlayList(IPlaylistRepositorio playlistRepositorio)
        {
            this.playlistRepositorio = playlistRepositorio;
        }

        public void Agregar(Playlist unplaylist)
        {
            playlistRepositorio.Agregar(unplaylist);
        }


        public List<Playlist> Obtenerplaylists()
        {
            return playlistRepositorio.ObtenerPlaylist();
        }

    }
}


