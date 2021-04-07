using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
   public interface ILogicaPlaylist
    {
        void Agregar(Playlist unplaylist);



        List<Playlist> Obtenerplaylists();
    }
}
