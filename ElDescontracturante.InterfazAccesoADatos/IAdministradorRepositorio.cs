using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
    public interface IAdministradorRepositorio
    {
        void Agregar(Administrador unAdministrador);

        List<Administrador> Obtener();
      
    }
}
