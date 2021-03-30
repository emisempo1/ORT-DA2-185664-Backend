using System;
using System.Collections.Generic;

namespace ElDescontracturante.Dominio
{
    public class Playlist
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Url { get; set; }

        public List<Audio> ListaAudios = new List<Audio>();


    }
}
