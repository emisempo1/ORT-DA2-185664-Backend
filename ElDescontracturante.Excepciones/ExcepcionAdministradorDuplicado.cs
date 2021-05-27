using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionAudioDuplicado : ExcepcionGenerica
    {
        public const string message = "Ya Existe el Audio a Agregar , no se agregara";
        public ExcepcionAudioDuplicado(string msg = message) : base(msg) { }

    }
}