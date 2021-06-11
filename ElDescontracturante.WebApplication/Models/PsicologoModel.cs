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
    public class PsicologoModel
    {


        public string Email { get; set; }
        public string Nombre { get; set; }
        public string TipoDeConsulta { get; set; }
        public string[] ProblematicasEspecializadas { get; set; }
        public string FechaIngreso { get; set; }
        public string DireccionFisica { get; set; }
        public int Tarifa { get; set; }


        public Psicologo ToEntity()
        {
            try
            {
                Psicologo psicologo = new Psicologo();
                psicologo.Nombre = this.Nombre;
                psicologo.Email = this.Email;
                psicologo.TipoDeConsulta = (ElDescontracturante.Dominio.Psicologo.ModoDeConsulta)Enum.Parse(typeof(ElDescontracturante.Dominio.Psicologo.ModoDeConsulta), this.TipoDeConsulta);
                psicologo.FechaIngreso = Convert.ToDateTime(FechaIngreso);
                psicologo.DireccionFisica = this.DireccionFisica;
                psicologo.Tarifa = this.Tarifa;
                return psicologo;
            }
            catch (System.ArgumentException)
            {
                throw new Excepciones.ExcepcionNombreModoDeConsultaIncorrecta(this.TipoDeConsulta);
            }
         
            
        }


        public Problematica_Psicologo.Problematica[] GetListaProblematicas()
        {
            if (ProblematicasEspecializadas == null)
            {
                throw new Excepciones.ExcepcionCantidadIncorrectaDeProblematicasPsicologo();
            }
            if (!(ProblematicasEspecializadas.Length == 3))
            {
                throw new Excepciones.ExcepcionCantidadIncorrectaDeProblematicasPsicologo();
            }

            Problematica_Psicologo.Problematica[] problematicas = new Problematica_Psicologo.Problematica[3];
            string unaProblematica = "";

            try
            {
                for (int i = 0; i < ProblematicasEspecializadas.Length; i++)
                {
                    unaProblematica = this.ProblematicasEspecializadas[i];
                    problematicas[i] = (ElDescontracturante.Dominio.Problematica_Psicologo.Problematica)Enum.Parse(typeof(ElDescontracturante.Dominio.Problematica_Psicologo.Problematica), unaProblematica);
                }
            }
            catch (System.ArgumentException)
            {
                throw new Excepciones.ExcepcionNombreProblematicaIncorrecta(unaProblematica);
            }
            return problematicas;
        }



        public PsicologoModel()
        {
        }
    }
}
