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
        public void AgregarOmitiendoRepetidos(List<Audio> audios)
        {       
            for (int i = 0; i < audios.Count; i++)
            {
                List<Audio> audiosExistentes = this.ObtenerAudios();
                if (!audiosExistentes.Contains(audios[i]))
                {
                    this.Agregar(audios[i]);
                }           
            }         
        }

        public void Borrar(string nombre)
        {
            List<Audio> audios = ObtenerAudios();

            for (int i = 0; i < audios.Count; i++)
            {
                if (audios[i].Nombre == nombre)
                {
                    audioRepositorio.Eliminar(audios[i]);
                    return;
                }
            }

            throw new Excepciones.ExcepcionAudioInexistente(nombre);
        }


        public List<Audio> ObtenerAudios()
        {
            return audioRepositorio.ObtenerAudios();
        }

        public List<Audio> ObtenerAudios(string[] audios)
        {
            return audioRepositorio.ObtenerAudios(audios);
        }


    }
}
