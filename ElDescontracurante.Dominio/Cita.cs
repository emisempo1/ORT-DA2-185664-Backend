using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static ElDescontracturante.Dominio.Psicologo;

namespace ElDescontracturante.Dominio
{
    public class Cita
    {
        public int ID { get; set; }
        public string EmailPsicologo { get; set; }
        public string NombrePsicologo { get; set; }
        public DateTime FechaConsulta{ get; set; }
        public ModoDeConsulta TipoDeConsulta { get; set; }
        public string Direccion { get; set; }
        public string EmailPaciente { get; set; }
    }
}
