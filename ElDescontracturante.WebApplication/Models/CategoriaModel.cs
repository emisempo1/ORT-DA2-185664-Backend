using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Models
{
    public class CategoriaModel
    {
        public CategoriaModel()
        {   
        }

        public string NombreCategoria { get; set; }
        public string[] ListaPlaylist { get; set; }

        public Categoria ToEntity()
        {
            Categoria categoria = new Categoria();
            try
            {
                categoria.NombreCategoria = (ElDescontracturante.Dominio.Categoria.NomCategoria)Enum.Parse(typeof(ElDescontracturante.Dominio.Categoria.NomCategoria), this.NombreCategoria);
            }
            catch (System.ArgumentException)
            {
                throw new Excepciones.ExcepcionNombreCategoriaIncorrecta();
            }
             return categoria;
        }

        
        
    }
}
