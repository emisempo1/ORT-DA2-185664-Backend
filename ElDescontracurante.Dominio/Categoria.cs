using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.Dominio
{
    public class Categoria
    {
        public enum NomCategoria { Dormir, Meditar, Musica, Cuerpo }

        public NomCategoria NombreCategoria { get; set; }

        public List<Playlist> ListaPlaylist = new List<Playlist>();

        public Categoria(NomCategoria nombreCategoria, List<Playlist> listaPlaylist)
        {
            NombreCategoria = nombreCategoria;
            ListaPlaylist = listaPlaylist;
        }

        public Categoria()
        {
          
        }
    }
}
