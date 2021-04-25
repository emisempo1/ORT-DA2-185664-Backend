using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionTokenInexistente : ExcepcionGenerica
    {
        public const string message = "No existe el token : ";
        public ExcepcionTokenInexistente(string msg) : base(message + msg) { }



    }
}
