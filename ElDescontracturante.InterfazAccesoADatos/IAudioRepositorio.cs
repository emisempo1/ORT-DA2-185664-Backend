using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
    public interface IAudioRepositorio
    {
        void Agregar(Audio unAudio);
        void Eliminar(Audio unAudio);
        List<Audio> ObtenerAudios();
        List<Audio> ObtenerAudios(string[] nombre);
        List<Audio> ObtenerAudios(Playlist unaPlaylist);
    }
}
