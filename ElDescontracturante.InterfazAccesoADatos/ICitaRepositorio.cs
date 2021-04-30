using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
    public interface ICitaRepositorio
    {
        void Agregar(Cita unCita);
        List<Cita> Obtener();
    }
}
