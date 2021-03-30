using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.Dominio
{
    public class Categoria
    {
        public enum NomCategoria { Dormir, Meditar, Musica, Cuerpo }
        public NomCategoria NombreCategoria { get; set; }

        public List<Audio> ListaAudios = new List<Audio>();

    }
}
