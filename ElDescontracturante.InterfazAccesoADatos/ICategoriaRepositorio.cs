using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
   public interface ICategoriaRepositorio
    { 
        void AgregarPlaylistsACategoria(Categoria unaCategoria);
        void AgregarPlaylistACategoria(Categoria_Playlist cp);
        List<Categoria_Playlist> ObtenerAsociaciones();
        Categoria ObtenerCategoria(string nombre);

    }
}
