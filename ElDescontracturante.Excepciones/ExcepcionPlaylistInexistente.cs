using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionPlaylistInexistente : ExcepcionGenerica
    {
        public const string message = "No existe LA PLAYLIST que quiere agregar a la Categoria : ";
        public ExcepcionPlaylistInexistente(string msg) : base(message + msg) { }



    }
}
