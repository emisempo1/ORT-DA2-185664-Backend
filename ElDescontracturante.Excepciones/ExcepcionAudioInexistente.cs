using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionAudioInexistente : ExcepcionGenerica
    {
        public const string message = "No existe el audio que quiere agregar a la playlist : ";
        public ExcepcionAudioInexistente(string msg) : base(message + msg) { }



    }
}
