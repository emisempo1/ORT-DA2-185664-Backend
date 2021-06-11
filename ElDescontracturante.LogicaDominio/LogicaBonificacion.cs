using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaBonificacion : ILogicaBonificacion
    {
        private readonly IBonificacionRepositorio bonificacionRepositorio;
        private readonly IPsicologoRepositorio psicologoRepositorio;
        private readonly ICitaRepositorio CitaRepositorio;
        

        public LogicaBonificacion(ICitaRepositorio CitaRepositorio, IPsicologoRepositorio psicologoRepositorio, IBonificacionRepositorio bonificacionRepositorio)
        {
            this.bonificacionRepositorio = bonificacionRepositorio;
            this.CitaRepositorio = CitaRepositorio;
            this.psicologoRepositorio = psicologoRepositorio;
        }

        public void Aprobar(Bonificacion unBonificacion)
        {
            Bonificacion bonificacion = RecuperarBonificacion(unBonificacion);
            this.bonificacionRepositorio.Eliminar(bonificacion);
            bonificacion.Aprobado = true;
            bonificacion.ID = 0;
            bonificacion.PorcentajeDescuento = unBonificacion.PorcentajeDescuento;
            this.bonificacionRepositorio.Agregar(bonificacion);
        }

        public Bonificacion RecuperarBonificacion(Bonificacion unBonificacion)
        {
            List<Bonificacion> listaBonificacion = bonificacionRepositorio.ObtenerBonificacions();
            for (int i = 0; i < listaBonificacion.Count; i++)
            {
                if (listaBonificacion[i].Email.Equals(unBonificacion.Email) && !(listaBonificacion[i].Aprobado) && !(listaBonificacion[i].Usado))
                {   
                    return listaBonificacion[i];
                }
            }
            throw new Excepciones.ExcepcionBonificacionInexistente(unBonificacion.Email);

        }

        public void Usar(Bonificacion unBonificacion)
        {
            Bonificacion bonificacion = unBonificacion;
            this.bonificacionRepositorio.Eliminar(unBonificacion);
            bonificacion.Usado = true;
            bonificacion.ID = 0;
            this.bonificacionRepositorio.Agregar(bonificacion);
        }

        public Bonificacion ObtenerBonificacion(string EmailPaciente)
        {
            List<Bonificacion> listaBonificacion = bonificacionRepositorio.ObtenerBonificacions();
            for (int i = 0; i < listaBonificacion.Count; i++)
            {
                if (listaBonificacion[i].Email.Equals(EmailPaciente) && listaBonificacion[i].Aprobado && !(listaBonificacion[i].Usado))
                {
                    return listaBonificacion[i];
                }
            }
            throw new Excepciones.ExcepcionBonificacionInexistente(EmailPaciente);
        }


        public void AgregarBonificacion(string EmailPaciente)
        {
            try
            {
                CorrespondeBonificacion(EmailPaciente);
                Bonificacion bonificacion = new Bonificacion();
                bonificacion.Email = EmailPaciente;
                bonificacionRepositorio.Agregar(bonificacion);
            }
            catch (Excepciones.ExcepcionNoCorrespondeBonificacion)
            {
            }
        }

        public void CorrespondeBonificacion(string EmailPaciente)
        {
            LogicaCita logicaCita = new LogicaCita(CitaRepositorio, psicologoRepositorio, bonificacionRepositorio);
            int cantidadCitasQueHizo = logicaCita.ObtenerCitasPaciente(EmailPaciente).Count;
            int BonificacionesObtenidas = CantidadBonificaciones(EmailPaciente);
            if (((cantidadCitasQueHizo / 5) - BonificacionesObtenidas) > 0)
            {
                return;
            }

            throw new Excepciones.ExcepcionNoCorrespondeBonificacion();
        }

        public int CantidadBonificaciones(string EmailPaciente)
        {
            int cantidad = 0;
            List<Bonificacion> listaBonificacion = bonificacionRepositorio.ObtenerBonificacions();
            for (int i = 0; i < listaBonificacion.Count; i++)
            {
                if (listaBonificacion[i].Email.Equals(EmailPaciente))
                {
                    cantidad = cantidad + 1;
                }
            }
            return cantidad;
        }

        public List<Bonificacion> ObtenerBonificacionesNoAprobadas()
        {
            List<Bonificacion> listaBonificacion = bonificacionRepositorio.ObtenerBonificacions();
            List<Bonificacion> listaBonificacionNoAprobadas = new List<Bonificacion>();
            for (int i = 0; i < listaBonificacion.Count; i++)
            {
                if (!(listaBonificacion[i].Aprobado))
                {
                    listaBonificacionNoAprobadas.Add(listaBonificacion[i]);
                }
            }
            return listaBonificacionNoAprobadas;
        }
    }
}
