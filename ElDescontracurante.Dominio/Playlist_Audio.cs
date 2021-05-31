using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElDescontracturante.Dominio
{
    public class Playlist_Audio
    {
        
        public string NombrePlaylist { get; set; }

       
        public string NombreAudio { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Playlist_Audio audio &&
                   NombrePlaylist == audio.NombrePlaylist &&
                   NombreAudio == audio.NombreAudio;
        }
    }
}
