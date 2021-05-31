using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
   public interface ILogicaCategoria
    {
        public void AgregarPlaylistsACategoria(Categoria unaCategoria);

        void AgregarPlaylistACategoriaOmitiendoRepetidos(Categoria.NomCategoria nombreCategoria, Playlist unaPlaylist);

        Categoria ObtenerCategoria(string nombre);





    }
}
