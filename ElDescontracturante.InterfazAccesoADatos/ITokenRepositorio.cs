using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
    public interface ITokenRepositorio
    {
        public void Agregar(string token);

        public List<Token> ObtenerTokens();
    }
}
