using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionProblematicaPsicologoDuplicado : ExcepcionGenerica
    {
        public const string message = "Ya existe la problematica para ese psicologo";
        public ExcepcionProblematicaPsicologoDuplicado(string msg = message) : base(msg) { }

    }
}