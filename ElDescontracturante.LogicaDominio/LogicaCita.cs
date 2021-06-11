
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaCita : ILogicaCita
    {
        private readonly ICitaRepositorio CitaRepositorio;
        private readonly IPsicologoRepositorio psicologoRepositorio;
        private readonly IBonificacionRepositorio bonificacionRepositorio;

    
        public LogicaCita(ICitaRepositorio CitaRepositorio,IPsicologoRepositorio psicologoRepositorio, IBonificacionRepositorio bonificacionRepositorio)
        {
            this.CitaRepositorio = CitaRepositorio;
            this.psicologoRepositorio = psicologoRepositorio;
            this.bonificacionRepositorio = bonificacionRepositorio;
        }

        public void Agregar(Cita unaCita)
        {
            CitaRepositorio.Agregar(unaCita);
        }


        public List<Cita> Obtener(string email)
        {
            List<Cita> listaCitaes = CitaRepositorio.Obtener();
            List<Cita> listaCitasDeUnPsicolgo = new List<Cita>();
            for (int i = 0; i < listaCitaes.Count; i++)
            {
                if (listaCitaes[i].EmailPsicologo == email)
                {
                    listaCitasDeUnPsicolgo.Add(listaCitaes[i]);
                }
            }
            return listaCitasDeUnPsicolgo;
        }

        public List<Cita> ObtenerCitasPaciente(string emailPaciente)
        {
            List<Cita> listaCitaes = CitaRepositorio.Obtener();
            List<Cita> listaCitasDeUnPsicolgo = new List<Cita>();
            for (int i = 0; i < listaCitaes.Count; i++)
            {
                if (listaCitaes[i].EmailPaciente == emailPaciente)
                {
                    listaCitasDeUnPsicolgo.Add(listaCitaes[i]);
                }
            }
            return listaCitasDeUnPsicolgo;
        }


        public Cita GenerarCita(List<Psicologo> listaPsicologosEspecializados, DateTime fecha)
        {
           List<Psicologo> psicologos = new List<Psicologo>();
           while (psicologos.Count == 0)
            {
                switch ((int)fecha.DayOfWeek)
                {
                    case 5: // si es viernes busco en el viernes y si no hay salto el viernes y el fin de semana
                        psicologos = ObtenerPsicologosEspecializadosLibresEnElDia(listaPsicologosEspecializados, fecha);
                        if (psicologos.Count == 0)
                        {
                            fecha = fecha.AddDays(3);
                        }
                        break;
                    case 6: // si es sabado ya hay que esperar 2 dias si o si.
                        fecha = fecha.AddDays(2);
                        break;
                    case 0: // si es domingo hay que esperar 1 dia. 
                        fecha = fecha.AddDays(1);
                        break;
                    default:
                        psicologos = ObtenerPsicologosEspecializadosLibresEnElDia(listaPsicologosEspecializados, fecha);
                        if (psicologos.Count == 0)
                        {
                            fecha = fecha.AddDays(1);
                        }
                        break;
                }
            }
            return AsignarPsicologoACita(psicologos, fecha);
        }


        public Cita AsignarPsicologoACita(List<Psicologo> listaPsicologosEspecializadosDisponibles, DateTime fecha)
        {
            Psicologo psicologo = PsicologoMasAntiguo(listaPsicologosEspecializadosDisponibles, fecha);
            Cita cita = new Cita();
            cita.FechaConsulta = fecha;
            cita.EmailPsicologo = psicologo.Email;
            cita.NombrePsicologo = psicologo.Nombre; ;
            cita.TipoDeConsulta = psicologo.TipoDeConsulta;
            cita.Direccion = psicologo.DireccionFisica;
            return cita;
        }

        public Psicologo PsicologoMasAntiguo(List<Psicologo> listaPsicologosEspecializadosDisponibles, DateTime fecha)
        {
            Psicologo psicologo = new Psicologo();
            List<Psicologo> psicologos = listaPsicologosEspecializadosDisponibles;
            DateTime fechaIngreso = psicologos[0].FechaIngreso;
            for (int i = 0; i < psicologos.Count; i++)
            {
                if (psicologos[i].FechaIngreso < fechaIngreso)
                {
                    fechaIngreso = psicologos[i].FechaIngreso;
                }
            }

            for (int i = 0; i < psicologos.Count; i++)
            {
                if (psicologos[i].FechaIngreso == fechaIngreso)
                {
                    psicologo = psicologos[i];
                }

            }
            return psicologo;
        }


        public List<Psicologo> ObtenerPsicologosEspecializadosLibresEnElDia(List<Psicologo> listaPsicologosEspecializados, DateTime fecha)
        {
            List<Cita> listaCitas = CitaRepositorio.Obtener();
            List<Psicologo> listaPsicologosEspecializadosLibresEnLaSemana = new List<Psicologo>();
            for (int i = 0; i < listaPsicologosEspecializados.Count; i++)
            {
                if (CantidadCitasEnElDia(listaPsicologosEspecializados[i], fecha) < 5)
                {
                    listaPsicologosEspecializadosLibresEnLaSemana.Add(listaPsicologosEspecializados[i]);
                }
            }
            return listaPsicologosEspecializadosLibresEnLaSemana;
        }

        public int CantidadCitasEnElDia(Psicologo psicologo, DateTime fecha)
        {
            int cantidadCitas = 0;
            List<Cita> listaCitas = CitaRepositorio.Obtener();

            for (int i = 0; i < listaCitas.Count; i++)
            {
                DateTime fechaCita = listaCitas[i].FechaConsulta;

                if (listaCitas[i].EmailPsicologo == psicologo.Email && fecha == fechaCita)
                {
                    cantidadCitas++;
                }
            }
            return cantidadCitas;
        }


        public int CalcularCostoConsulta(int MinutosDeLaConsulta, Cita cita )
        {
            LogicaBonificacion logicaBonificacion = new LogicaBonificacion(CitaRepositorio, psicologoRepositorio, bonificacionRepositorio);
            int costo;
            Psicologo unPsicologo = psicologoRepositorio.Obtener(cita.EmailPsicologo);
            double cantidadHoras = (double)MinutosDeLaConsulta / 60;
            try
            {
                Bonificacion bonificacion = logicaBonificacion.ObtenerBonificacion(cita.EmailPaciente);
                logicaBonificacion.Usar(bonificacion);
                costo = (int)((cantidadHoras * unPsicologo.Tarifa)*(1-((double)bonificacion.PorcentajeDescuento*0.01)));
                return costo;
            }
            catch (Excepciones.ExcepcionBonificacionInexistente)
            {
                costo = (int)(cantidadHoras * unPsicologo.Tarifa);
                return costo;
            }
        }

       
    };
}