using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaCategoria : ILogicaCategoria
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public LogicaCategoria(ICategoriaRepositorio logicaCategoria)
        {
            this.categoriaRepositorio = logicaCategoria;
        }

        public void AgregarPlaylistsACategoria(Categoria unaCategoria)
        {
         categoriaRepositorio.AgregarPlaylistsACategoria(unaCategoria);
        }

        public Categoria ObtenerCategoria(string nombre)
        {
            return categoriaRepositorio.ObtenerCategoria(nombre);
        }

    
    }
}
