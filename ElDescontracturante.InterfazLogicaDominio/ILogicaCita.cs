using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
    public interface ILogicaCita
    { 
        public void Agregar(Cita unaCita);
        public List<Cita> Obtener(string email);
        public Cita GenerarCita(List<Psicologo> listaPsicologosEspecializados, DateTime fecha);
        public Cita AsignarPsicologoACita(List<Psicologo> listaPsicologosEspecializadosDisponibles, DateTime fecha);
        public Psicologo PsicologoMasAntiguo(List<Psicologo> listaPsicologosEspecializadosDisponibles, DateTime fecha);
        public List<Psicologo> ObtenerPsicologosEspecializadosLibresEnElDia(List<Psicologo> listaPsicologosEspecializados, DateTime fecha);
        public int CantidadCitasEnElDia(Psicologo psicologo, DateTime fecha);

    }
}
