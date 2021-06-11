using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionBonificacionInexistente : ExcepcionGenerica
    {
        public const string message = "No existe la bonificacion asociada al paciente de correo : ";
        public ExcepcionBonificacionInexistente(string msg) : base(message + msg) { }



    }
}
