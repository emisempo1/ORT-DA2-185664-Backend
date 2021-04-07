using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionPlaylistDuplicado : ExcepcionGenerica
    {
        public const string message = "Ya dicha Playlist";
        public ExcepcionPlaylistDuplicado(string msg = message) : base(msg) { }

    }
}