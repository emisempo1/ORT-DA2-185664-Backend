using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.IImportacion
{
    public interface InterfazImportacion
    {
        Categoria ObtenerPlayListyAudios(string path);
    }
}
