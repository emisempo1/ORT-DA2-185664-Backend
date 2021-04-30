using System;
using System.Collections.Generic;
using System.Text;
using static ElDescontracturante.Dominio.Problematica_Psicologo;

namespace ElDescontracturante.Dominio
{
    public class Solicitud
    {
        public int Celular { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Problematica NombreProblematica { get; set; }
      



    }
}
