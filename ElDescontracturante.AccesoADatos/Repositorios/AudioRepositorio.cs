using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
