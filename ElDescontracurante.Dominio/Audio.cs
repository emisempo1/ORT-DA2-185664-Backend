using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.Dominio
{
    public class Audio
    {
        public string Nombre { get; set; }

        public int Duracion { get; set; }

        public UnidadTiempo UnidadDeTiempo { get; set; }

        public enum UnidadTiempo { Minuto, Hora }

        public string NombreCreador { get; set; } 

        public string UrlImagen { get; set; }

        public string UrlMp3 { get; set; }

        public Audio(string nombre, int duracion, UnidadTiempo unidadDeTiempo)
        {
            Nombre = nombre;
            Duracion = duracion;
            UnidadDeTiempo = unidadDeTiempo;
        }

        public Audio()
        {
            
        }
    }
}
