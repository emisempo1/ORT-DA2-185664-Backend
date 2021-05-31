using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
   public interface ILogicaPlaylist
    {
        void Agregar(Playlist unplaylist);
        void AgregarAsociaciones(Playlist unaPlaylist);
        void AgregarOmitiendoRepetidos(Playlist unaPlaylist);
        Playlist ObtenerPlaylist(string nombre);
        public List<Playlist> ObtenerPlaylist(string[] nombre);
    }
}
