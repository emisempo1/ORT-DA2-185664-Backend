using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class AudioRepositorio : IAudioRepositorio
    {
        private readonly DbContext context;

        public AudioRepositorio(DbContext context)
        {
            this.context = context;
        }

    
        public void Agregar(Audio unAudio)
        {
            try
            {
                this.context.Add(unAudio);
                this.context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new Excepciones.ExcepcionAudioDuplicado();
            }
            catch (System.InvalidOperationException)
            {
                throw new Excepciones.ExcepcionAudioDuplicado();
            }
        }

        public List<Audio> ObtenerAudios()
        {
            return this.context.Set<Audio>().ToList();
        }

        public List<Audio> ObtenerAudios(string[] nombres)
        {
            bool encontro = false;
            List <Audio>  listaAudios = this.context.Set<Audio>().ToList();
            List<Audio> listaAudiosARetornar = new List<Audio>();
              
            for (int i = 0; i < nombres.Length; i++)
            {
                encontro = false;

                for (int j = 0; j < listaAudios.Count; j++)
                {
                    if (nombres[i].Equals(listaAudios[j].Nombre))
                    {
                        listaAudiosARetornar.Add(listaAudios[j]);
                        encontro = true;
                    }     
                }

                if (!encontro)
                {
                throw new Excepciones.ExcepcionAudioInexistente(nombres[i]);
                }

            }

            return listaAudiosARetornar;
     
        }



    }
}
