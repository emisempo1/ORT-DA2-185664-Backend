using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class PlaylistRepositorio:IPlaylistRepositorio
    {
        private readonly DbContext context;

        public PlaylistRepositorio(DbContext context)
        {
            this.context = context;
        }


        public void Agregar(Playlist unaPlaylist)
        {
            try
            {
                this.context.Add(unaPlaylist);

                for (int i = 0; i < unaPlaylist.ListaAudios.Count; i++)
                {
                    Playlist_Audio playlistAudio = new Playlist_Audio();
                    playlistAudio.NombrePlaylist = unaPlaylist.Nombre;
                    playlistAudio.NombreAudio = unaPlaylist.ListaAudios[i].Nombre;
                    this.context.Add(playlistAudio);            
                }
               
                this.context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new Excepciones.ExcepcionAudioDuplicado();
            }
            catch (System.InvalidOperationException)
            {
                throw new Excepciones.ExcepcionPlaylistDuplicado();
            }
        }


        public List<Playlist> ObtenerPlaylist()
        {
            return this.context.Set<Playlist>().ToList();
        }
    }
}
