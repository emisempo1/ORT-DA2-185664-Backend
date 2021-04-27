using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionNombreProblematicaIncorrecta : ExcepcionGenerica
    {
        public const string message = "El nombre de ESTA Problematica no existe : ";
        public ExcepcionNombreProblematicaIncorrecta(string msg) : base(message + msg) { } 

    }
}