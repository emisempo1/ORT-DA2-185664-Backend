using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionAdministradorInexistente : ExcepcionGenerica
    {
        public const string message = "El administrador de mail NO existe como un admin activo : ";
        public ExcepcionAdministradorInexistente(string msg) : base(message + msg) { }



    }
}
