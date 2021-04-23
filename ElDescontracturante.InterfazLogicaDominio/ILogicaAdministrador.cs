using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
    public interface ILogicaAdministrador
    { 
        public void Agregar(Administrador administrador);
        Administrador Obtener(string email, string password);

    }
}
