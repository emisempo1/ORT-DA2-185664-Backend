using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Models
{
    public class AudioModel
    {
        public string Nombre { get; set; }

        public int Duracion { get; set; }

        public string UnidadDeTiempo { get; set; }

        public string NombreCreador { get; set; }

        public string UrlImagen { get; set; }

        public string UrlMp3 { get; set; }




        public Audio ToEntity()
        {
            Audio audio = new Audio();
            try
            {
                audio.Nombre = this.Nombre;
                audio.Duracion = this.Duracion;
                audio.UnidadDeTiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), this.UnidadDeTiempo);
                audio.NombreCreador = this.NombreCreador;
                audio.UrlImagen = this.UrlImagen;
                audio.UrlMp3 = this.UrlMp3;

            }
            catch (System.ArgumentException)
            {
                throw new Excepciones.ExcepcionAudioDuplicado();
            }

            return audio;
        }

        public AudioModel()
        {
        }
    }
}
