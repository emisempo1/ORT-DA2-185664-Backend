using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaAudio : ILogicaAudio
    {
        private readonly IAudioRepositorio audioRepositorio;

        public LogicaAudio(IAudioRepositorio audioRepositorio)
        {
            this.audioRepositorio = audioRepositorio;
        }

        public void Agregar(Audio unAudio)
        {
            audioRepositorio.Agregar(unAudio);
        }
    }
}
