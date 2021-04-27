using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionPsicologoDuplicado : ExcepcionGenerica
    {
        public const string message = "Ya existe dicho psicolgo";
        public ExcepcionPsicologoDuplicado(string msg = message) : base(msg) { }

    }
}