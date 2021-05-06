
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaAdministrador : ILogicaAdministrador
    {
        private readonly IAdministradorRepositorio adminRepositorio;


        public LogicaAdministrador(IAdministradorRepositorio adminRepositorio)
        {
            this.adminRepositorio = adminRepositorio;
        }

        public void Agregar(Administrador administrador)
        {
            adminRepositorio.Agregar(administrador);
        }

        public Administrador Obtener(string email, string password)
        {
            List<Administrador> listaAdministradores = adminRepositorio.Obtener();

                for (int i = 0; i < listaAdministradores.Count; i++)
                {
                    if (listaAdministradores[i].Email == email && listaAdministradores[i].Password == password) 
                    {
                        return listaAdministradores[i];
                    }
                }           
                
                throw new Excepciones.ExcepcionAdministradorInexistente(email);
        }


    };
}