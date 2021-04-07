using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Models
{
    public class PlaylistModel
    {

   

        public PlaylistModel()
        {
            
        }


        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string[] ListaAudio { get; set; }

  



        public Playlist ToEntity()
        {
            AudioModel audioModel = new AudioModel();

            Playlist playlist = new Playlist();

            try
            {
                playlist.Nombre = this.Nombre;
                playlist.Descripcion = this.Descripcion;
      
            }
            catch (System.ArgumentException)
            {
                throw new Excepciones.ExcepcionPlaylistDuplicado();
            }

            return playlist;
        }

        
        
    }
}
