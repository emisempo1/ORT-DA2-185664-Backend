using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class AdministradorRepositorio : IAdministradorRepositorio
    {
        private readonly DbContext context;

        public AdministradorRepositorio(DbContext context)
        {
            this.context = context;
        }

        public void Agregar(Administrador unAdministrador)
        {
            try
            {
                this.context.Add(unAdministrador);
                this.context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new Excepciones.ExcepcionAdministradorDuplicado();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public List<Administrador> Obtener()
        {
            try
            {
                return this.context.Set<Administrador>().ToList();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }
    }
}
