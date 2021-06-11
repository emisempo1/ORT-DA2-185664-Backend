using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
    public interface IBonificacionRepositorio
    {
        public void Agregar(Bonificacion bonificacion);
        public void Eliminar(Bonificacion bonificacion);
        public List<Bonificacion> ObtenerBonificacions();
    }
}
