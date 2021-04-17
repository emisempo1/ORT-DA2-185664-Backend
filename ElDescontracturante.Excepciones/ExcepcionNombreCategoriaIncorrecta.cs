using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionNombreCategoriaIncorrecta : ExcepcionGenerica
    {
        public const string message = "El nombre de la categoria no existe";
        public ExcepcionNombreCategoriaIncorrecta(string msg = message) : base(msg) { }

    }
}