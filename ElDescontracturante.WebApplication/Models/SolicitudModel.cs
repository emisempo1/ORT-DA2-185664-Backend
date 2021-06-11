using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Models
{
    public class SolicitudModel
    {

        public string Celular { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string FechaNacimiento  { get; set; }
        public string Problematica { get; set; }
        public string MinutosDeLaConsulta { get; set; }

        public Solicitud ToEntity()
        {
            try
            {
                Solicitud Solicitud = new Solicitud();
                Solicitud.Celular = Int32.Parse(this.Celular);
                Solicitud.Nombre = this.Nombre;
                Solicitud.Email = this.Email;
                Solicitud.NombreProblematica = (ElDescontracturante.Dominio.Problematica_Psicologo.Problematica)Enum.Parse(typeof(ElDescontracturante.Dominio.Problematica_Psicologo.Problematica), this.Problematica);
                Solicitud.FechaNacimiento = Convert.ToDateTime(FechaNacimiento);
                Solicitud.MinutosDeLaConsulta = Int32.Parse(this.MinutosDeLaConsulta);

                return Solicitud;
            }
            catch (System.ArgumentException)
            {
                throw new Excepciones.ExcepcionNombreProblematicaIncorrecta(this.Problematica);
            }
         
            
        }


        public SolicitudModel()
        {

        }
    }
}
