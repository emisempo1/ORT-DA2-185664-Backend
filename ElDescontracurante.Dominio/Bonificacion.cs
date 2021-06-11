using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.Dominio
{
    public class Bonificacion
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int PorcentajeDescuento { get; set; }
        public bool Usado { get; set; }
        public bool Aprobado { get; set; }

        public Bonificacion()

        {
            ID = 0 ;
            Email = "";
            PorcentajeDescuento = 0;
            Usado = false ;
            Aprobado = false;
        }
    }
}
