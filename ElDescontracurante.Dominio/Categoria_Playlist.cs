using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static ElDescontracturante.Dominio.Categoria;

namespace ElDescontracturante.Dominio
{
    public class Categoria_Playlist
    {
        [ForeignKey("CategoriaForeignKey")]
        public NomCategoria Categoria { get; set; }

        [ForeignKey("PlaylistForeignKey")]
        public string NombrePlaylist { get; set; }

    }
}
