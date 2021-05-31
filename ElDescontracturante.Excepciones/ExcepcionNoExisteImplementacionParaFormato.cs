using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionNoExisteImplementacionParaFormato : ExcepcionGenerica
    {
        public const string message = "No existe implementacion para dicho formato";
        public ExcepcionNoExisteImplementacionParaFormato(string msg) : base(message + msg) { }



    }
}
