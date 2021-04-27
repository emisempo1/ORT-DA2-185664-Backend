using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionNombreModoDeConsultaIncorrecta : ExcepcionGenerica
    {
        public const string message = "El nombre de ESTE Modo De Consulta no existe : ";
        public ExcepcionNombreModoDeConsultaIncorrecta(string msg) : base(message + msg) { } 

    }
}