using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class BonificacionRepositorio : IBonificacionRepositorio
    {
        private readonly DbContext context;

        public BonificacionRepositorio(DbContext context)
        {
            this.context = context;
        }

        public void Agregar(Bonificacion bonificacion)
        {
            try
            {
                this.context.Add(bonificacion);
                this.context.SaveChanges();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public void Eliminar(Bonificacion bonificacion)
        {
            try
            {
                this.context.Remove(bonificacion);
                this.context.SaveChanges();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
            catch(System.InvalidOperationException)
            {
                throw new Excepciones.ExcepcionBonificacionInexistente(bonificacion.Email);
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                throw new Excepciones.ExcepcionBonificacionInexistente(bonificacion.Email);
            }
        }
        public List<Bonificacion> ObtenerBonificacions()
        {
            try
            {
                return this.context.Set<Bonificacion>().ToList();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

    }
}
