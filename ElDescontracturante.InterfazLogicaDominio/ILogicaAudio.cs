using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;

namespace ElDescontracturante.InterfazLogicaDominio
{
    public interface ILogicaAudio
    {
        public void Agregar(Audio unAudio);

        public List<Audio> ObtenerAudios();

        List<Audio> ObtenerAudios(string[] nombre);

        void Borrar(string nombre);

    }

}