using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElDescontracturante.AccesoADatos.Repositorios
{
    public class TokenRepositorio : ITokenRepositorio
    {
        private readonly DbContext context;

        public TokenRepositorio(DbContext context)
        {
            this.context = context;
        }

        public void Agregar(string tokenId)
        {
            try
            {
               
                Token token = new Token();
                token.Id = tokenId;
                token.Fecha = DateTime.Now;
                this.context.Add(token);
                this.context.SaveChanges();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public List<Token> ObtenerTokens()
        {
            try
            {
                return this.context.Set<Token>().ToList();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                throw new Excepciones.ExcepcionMotorBaseDeDatosCaido();
            }
        }
    }
}
