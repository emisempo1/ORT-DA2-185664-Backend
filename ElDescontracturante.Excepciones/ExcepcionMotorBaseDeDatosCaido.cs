using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionMotorBaseDeDatosCaido : ExcepcionGenerica
    {
        public const string message = "El motor de base de datos arrojo una excepcion, verifique que el mismo se encuentra activo";
        public ExcepcionMotorBaseDeDatosCaido(string msg = message) : base(msg) { }

    }
}