using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionUnidadDeTiempoDesconocida : ExcepcionGenerica
    {
        public const string message = "No se reconoce la unidad de tiempo , solo se acepta Minuto, Hora";
        public ExcepcionUnidadDeTiempoDesconocida(string msg = message) : base(msg) { }

    }
}