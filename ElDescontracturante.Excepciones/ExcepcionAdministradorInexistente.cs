using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionPsicologoInexistente : ExcepcionGenerica
    {
        public const string message = "El Psicologo de mail NO existe como un admin activo : ";
        public ExcepcionPsicologoInexistente(string msg) : base(message + msg) { }



    }
}
