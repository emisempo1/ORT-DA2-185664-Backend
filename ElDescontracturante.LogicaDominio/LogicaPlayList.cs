using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaPlayList:ILogicaPlaylist
    {

        
        Playlist unaPlaylist;
        private readonly IPlaylistRepositorio playlistRepositorio;
        private readonly IAudioRepositorio audioRepositorio;
        LogicaAudio logicaAudio;

        public LogicaPlayList(IPlaylistRepositorio playlistRepositorio, IAudioRepositorio audioRepositorio)
        {
            this.playlistRepositorio = playlistRepositorio;
            this.audioRepositorio = audioRepositorio;
        }

        public void Agregar(Playlist unplaylist)
        {
            playlistRepositorio.Agregar(unplaylist);
        }

        public List<Playlist> ObtenerPlaylist(string[] nombre)
        {
            List<Playlist> playlistsaretornar = new List<Playlist>();
            playlistsaretornar = playlistRepositorio.ObtenerPlaylist(nombre);

            for (int i = 0; i < playlistsaretornar.Count; i++)
            {
                playlistsaretornar[i].ListaAudios = audioRepositorio.ObtenerAudios(playlistsaretornar[i]);
            }

            return playlistsaretornar;
        }

        public List<Playlist> Obtenerplaylists()
        {
            List<Playlist> playlistsaretornar = new List<Playlist>();
            playlistsaretornar = playlistRepositorio.ObtenerPlaylist();

            for (int i = 0; i < playlistsaretornar.Count; i++)
            {
                playlistsaretornar[i].ListaAudios = audioRepositorio.ObtenerAudios(playlistsaretornar[i]);
            }

            return playlistsaretornar;
        }

      
    }
}


