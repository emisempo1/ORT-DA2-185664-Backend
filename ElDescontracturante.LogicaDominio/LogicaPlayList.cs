using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaPlayList : ILogicaPlaylist
    {

        private readonly IPlaylistRepositorio playlistRepositorio;
        private readonly IAudioRepositorio audioRepositorio;

        public LogicaPlayList(IPlaylistRepositorio playlistRepositorio, IAudioRepositorio audioRepositorio)
        {
            this.playlistRepositorio = playlistRepositorio;
            this.audioRepositorio = audioRepositorio;
        }

        public void Agregar(Playlist unplaylist)
        {
            playlistRepositorio.Agregar(unplaylist);
        }

        public void AgregarAsociaciones(Playlist unaPlaylist)
        {
            for (int i = 0; i < unaPlaylist.ListaAudios.Count; i++)
            {
                Playlist_Audio playlistAudio = new Playlist_Audio();
                playlistAudio.NombrePlaylist = unaPlaylist.Nombre;
                playlistAudio.NombreAudio = unaPlaylist.ListaAudios[i].Nombre;
                this.AgregarAsociacion(playlistAudio);
            }
        }


        public void AgregarAsociacion(Playlist_Audio unaAsociacion)
        {
            List<Playlist_Audio> asociaciones = playlistRepositorio.ObtenerAsociaciones();
            if (!asociaciones.Contains(unaAsociacion))
            {
                playlistRepositorio.AgregarAsociacion(unaAsociacion);
            }
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


        public Playlist ObtenerPlaylist(string nombre)
        {
            Playlist playlistsaretornar = new Playlist();
            playlistsaretornar = playlistRepositorio.ObtenerPlaylist(nombre);
            playlistsaretornar.ListaAudios = audioRepositorio.ObtenerAudios(playlistsaretornar);
            return playlistsaretornar;
        }


        public void AgregarOmitiendoRepetidos(Playlist unaPlaylist)
        {
            List<Playlist> playlists = playlistRepositorio.ObtenerPlaylist();

            if (!playlists.Contains(unaPlaylist))
            {
                this.Agregar(unaPlaylist);
            }
        }


}
}


