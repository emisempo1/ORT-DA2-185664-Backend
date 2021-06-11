using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionNoCorrespondeBonificacion : ExcepcionGenerica
    {
        public const string message = "No corresponde aun una bonificacion";
        public ExcepcionNoCorrespondeBonificacion() : base(message) { }



    }
}
