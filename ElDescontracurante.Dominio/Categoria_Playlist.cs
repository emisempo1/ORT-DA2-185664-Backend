using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static ElDescontracturante.Dominio.Categoria;

namespace ElDescontracturante.Dominio
{
    public class Categoria_Playlist
    {
      
        public NomCategoria Categoria { get; set; }
        public string NombrePlaylist { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Categoria_Playlist playlist &&
                   Categoria == playlist.Categoria &&
                   NombrePlaylist == playlist.NombrePlaylist;
        }
    }
}
