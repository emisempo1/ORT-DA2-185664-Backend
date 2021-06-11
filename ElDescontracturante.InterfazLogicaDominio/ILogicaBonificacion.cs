using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;

namespace ElDescontracturante.InterfazLogicaDominio
{
    public interface ILogicaBonificacion
    {
        public void Aprobar(Bonificacion unBonificacion);
        public void Usar(Bonificacion unBonificacion);
        public List<Bonificacion> ObtenerBonificacionesNoAprobadas();
        public void AgregarBonificacion(string EmailPaciente);

    }

}