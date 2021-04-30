using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class CitaRepositorio : ICitaRepositorio
    {
        private readonly DbContext context;

        public CitaRepositorio(DbContext context)
        {
            this.context = context;
        }

        public void Agregar(Cita unCita)
        {
            try
            {
                this.context.Add(unCita);
                this.context.SaveChanges();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public List<Cita> Obtener()
        {
            try
            {
                return this.context.Set<Cita>().ToList();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

       
    }
}
