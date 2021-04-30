using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionPsicologosInexistentes : ExcepcionGenerica
    {
        public const string message = "no existen nigun psicologo especialziado en la problematica ";
        public ExcepcionPsicologosInexistentes() : base(message) { }



    }
}
