using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.Dominio
{
    public class Psicologo
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public ModoDeConsulta TipoDeConsulta { get; set; }
        public enum ModoDeConsulta { VideoLlamada, Presencial }

    }
}
