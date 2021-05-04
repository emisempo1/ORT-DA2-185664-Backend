using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class PsicologoRepositorio : IPsicologoRepositorio
    {
        private readonly DbContext context;

        public PsicologoRepositorio(DbContext context)
        {
            this.context = context;
        }

        public void Agregar(Psicologo unPsicologo)
        {
            try
            {
                this.context.Add(unPsicologo);
                this.context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new Excepciones.ExcepcionPsicologoDuplicado();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }


        public void Eliminar(Psicologo unPsicologo)
        {
            try
            {
                this.context.Remove(unPsicologo);
                this.context.SaveChanges();
                EliminarProblematicasPsicologo(unPsicologo.Email);
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }



        public void EliminarProblematicasPsicologo(string email)
        {

            List<Problematica_Psicologo> listaMapeoProblematicaPsicologo = this.context.Set<Problematica_Psicologo>().ToList();
            for (int i = 0; i < listaMapeoProblematicaPsicologo.Count; i++)
            {
                if (listaMapeoProblematicaPsicologo[i].Email == email)
                {
                    this.context.Remove(listaMapeoProblematicaPsicologo[i]);
                    this.context.SaveChanges();
                }
            }
        }





        public void AgregarProblematica(Problematica_Psicologo unaProbelamaticaPsicologo)
        {
            try
            {
                this.context.Add(unaProbelamaticaPsicologo);
                this.context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new Excepciones.ExcepcionProblematicaPsicologoDuplicado();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public List<Psicologo> Obtener()
        {
            try
            {
                return this.context.Set<Psicologo>().ToList();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public List<Problematica_Psicologo> ObtenerProblematica()
        {
            try
            {
                return this.context.Set<Problematica_Psicologo>().ToList();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }
    }
}
