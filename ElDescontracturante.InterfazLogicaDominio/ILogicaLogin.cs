using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
    public interface ILogicaLogin
    { 
        public string RegistrarToken();

        public void BuscarToken(string token);
 

    }
}
