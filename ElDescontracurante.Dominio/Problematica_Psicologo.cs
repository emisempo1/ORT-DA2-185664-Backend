using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElDescontracturante.Dominio
{
    public class Problematica_Psicologo
    {


        public string Email { get; set; }
        public Problematica NombreProblematica { get; set; }
        public enum Problematica {Depresion,Estres, Ansiedad, Autoestima, Enojo, Relaciones, Duelo, Otros }



    }
}
