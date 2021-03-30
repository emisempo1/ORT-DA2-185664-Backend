using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionAudioDuplicado : ExcepcionGenerica
    {
        public const string message = "Ya dicho Audio";
        public ExcepcionAudioDuplicado(string msg = message) : base(msg) { }

    }
}