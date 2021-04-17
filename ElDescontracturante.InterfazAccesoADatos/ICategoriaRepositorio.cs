using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
   public interface ICategoriaRepositorio
    { 
        void AgregarPlaylistsACategoria(Categoria unaCategoria);
        Categoria ObtenerCategoria(string nombre);




    }
}
