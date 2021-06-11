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
    public class BonificacionModel
    {

        public string Email { get; set; }
        public string PorcentajeDescuento { get; set; }
        public string Usado { get; set; }
        public string Aprobado { get; set; }



        public Bonificacion ToEntity()
        {
            Bonificacion bonificacion = new Bonificacion();
            try
            {
                bonificacion.Email = this.Email;
                bonificacion.PorcentajeDescuento = Int32.Parse(PorcentajeDescuento);
                bonificacion.Usado = System.Convert.ToBoolean(this.Usado);
                bonificacion.Aprobado = System.Convert.ToBoolean(this.Aprobado);
            }
            catch (System.ArgumentException)
            {
                throw new Excepciones.ExcepcionUnidadDeTiempoDesconocida();
            }

            return bonificacion;
        }

        public BonificacionModel()

        {
            Email = "";
            PorcentajeDescuento = "0";
            Usado = "false";
            Aprobado = "false";
        }



    }
}
