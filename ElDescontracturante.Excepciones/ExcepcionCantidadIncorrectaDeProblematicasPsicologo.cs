using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionCantidadIncorrectaDeProblematicasPsicologo : ExcepcionGenerica
    {
        public const string message = "Un psicologo tiene EXACTAMENTE 3 problematicas unicamente";
        public ExcepcionCantidadIncorrectaDeProblematicasPsicologo(string msg = message) : base(msg) { }

    }
}