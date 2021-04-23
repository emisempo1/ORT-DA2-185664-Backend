using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DbContext context;


        public CategoriaRepositorio(DbContext context)
        {
            this.context = context;
        }

        public void AgregarPlaylistsACategoria(Categoria unaCategoria)
        {
            Categoria_Playlist cp = new Categoria_Playlist();

            try
            {

                cp.Categoria = unaCategoria.NombreCategoria;

                for (int i = 0; i < unaCategoria.ListaPlaylist.Count; i++)
                {
                    cp.NombrePlaylist = unaCategoria.ListaPlaylist[i].Nombre;
                    this.context.Add(cp);
                    this.context.SaveChanges();
                }

            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new Excepciones.ExcepcionPlaylistYaAsociadaACategoria(cp.Categoria.ToString(), cp.NombrePlaylist);
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public Categoria ObtenerCategoria(string nombre)
        {
            Categoria categoria;
            try
            {
                var nomCategoria = (ElDescontracturante.Dominio.Categoria.NomCategoria)Enum.Parse(typeof(ElDescontracturante.Dominio.Categoria.NomCategoria), nombre);
                List<Categoria_Playlist> listaCategoriaPlaylists = this.context.Set<Categoria_Playlist>().ToList();
                List<string> nombresPlaylist = new List<string>();

                for (int i = 0; i < listaCategoriaPlaylists.Count; i++)
                {
                    if (listaCategoriaPlaylists[i].Categoria == nomCategoria)
                    {
                        nombresPlaylist.Add(listaCategoriaPlaylists[i].NombrePlaylist);
                    }
                }

                PlaylistRepositorio playlistRepositorio = new PlaylistRepositorio(context);
                List<Playlist> listaPlaylist = playlistRepositorio.ObtenerPlaylist(nombresPlaylist.ToArray());
                categoria = new Categoria(nomCategoria, listaPlaylist);
            }
            catch (System.ArgumentException)
            {
                throw new Excepciones.ExcepcionNombreCategoriaIncorrecta();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }

            return categoria;
        }



    }
}
