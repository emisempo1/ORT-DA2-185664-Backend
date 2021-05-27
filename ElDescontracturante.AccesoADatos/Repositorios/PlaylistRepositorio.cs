using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class PlaylistRepositorio : IPlaylistRepositorio
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
                throw new Excepciones.ExcepcionPlaylistDuplicado();
            }
            catch (System.InvalidOperationException)
            {
                throw new Excepciones.ExcepcionPlaylistDuplicado();
            }
        }


        public Playlist ObtenerPlaylist(string nombre)
        {
           
            List<Playlist> listaplaylists =  this.context.Set<Playlist>().ToList();

            for (int j = 0; j < listaplaylists.Count; j++)
            {
                if (nombre.Equals(listaplaylists[j].Nombre))
                {
                    return listaplaylists[j];
                }
            }

            throw new Excepciones.ExcepcionPlaylistInexistente(nombre);

        }

        public List<Playlist> ObtenerPlaylist(string[] nombres)

        {
            bool encontro = false;
            List<Playlist> listaplaylistsARetornar = new List<Playlist>();
            try
            {
                List<Playlist> listaplaylists = this.context.Set<Playlist>().ToList();
                for (int i = 0; i < nombres.Length; i++)
                {
                    encontro = false;
                    for (int j = 0; j < listaplaylists.Count; j++)
                    {
                        if (nombres[i].Equals(listaplaylists[j].Nombre))
                        {
                            listaplaylistsARetornar.Add(listaplaylists[j]);
                            encontro = true;
                        }
                    }
                    if (!encontro)
                    {
                        throw new Excepciones.ExcepcionPlaylistInexistente(nombres[i]);
                    }
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }

            return listaplaylistsARetornar;
        }


    }
}
