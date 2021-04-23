using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionAdministradorDuplicado : ExcepcionGenerica
    {
        public const string message = "Ya existe dicho Administrador";
        public ExcepcionAdministradorDuplicado(string msg = message) : base(msg) { }

    }
}