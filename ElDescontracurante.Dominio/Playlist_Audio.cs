using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElDescontracturante.Dominio
{
    public class Playlist_Audio
    {
        [ForeignKey("PlaylistForeignKey")]
        public string NombrePlaylist { get; set; }

        [ForeignKey("AudioForeignKey")]
        public string NombreAudio { get; set; }
    }
}
