using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionPlaylistYaAsociadaACategoria : ExcepcionGenerica
    {
    
        public ExcepcionPlaylistYaAsociadaACategoria(string nombrecategoria, string playlist) : base("La Playlist " + playlist +  " ya existe en la categoria " + nombrecategoria) { }

    }
}