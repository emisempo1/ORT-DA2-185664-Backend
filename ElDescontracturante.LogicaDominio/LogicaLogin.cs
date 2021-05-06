
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaLogin : ILogicaLogin
    {
        private readonly ITokenRepositorio tokenRepositorio;


        public LogicaLogin(ITokenRepositorio tokenRepositorio)
        {
            this.tokenRepositorio = tokenRepositorio;
        }

        public void BuscarToken(string token)
        {
            List<Token> listaTokens = tokenRepositorio.ObtenerTokens();

            for (int i = 0; i < listaTokens.Count; i++)
            {
                if (listaTokens[i].Id == token)
                {
                    return;
                }
            }

            throw new Excepciones.ExcepcionTokenInexistente(token);
        }

        public string RegistrarToken()
        {
            Guid g = Guid.NewGuid();
            string tokenId = g.ToString();
            tokenRepositorio.Agregar(tokenId);
            return tokenId;
        }
    };
}