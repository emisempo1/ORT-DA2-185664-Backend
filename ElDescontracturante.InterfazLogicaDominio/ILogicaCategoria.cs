using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
   public interface ILogicaCategoria
    {
        public void AgregarPlaylistsACategoria(Categoria unaCategoria);

        Categoria ObtenerCategoria(string nombre);





    }
}
