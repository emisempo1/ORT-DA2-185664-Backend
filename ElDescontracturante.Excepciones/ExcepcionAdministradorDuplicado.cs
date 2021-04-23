using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionAudioDuplicado : ExcepcionGenerica
    {
        public const string message = "Ya dicho administrador";
        public ExcepcionAudioDuplicado(string msg = message) : base(msg) { }

    }
}