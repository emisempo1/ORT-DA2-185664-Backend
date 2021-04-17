using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElDescontracturante.InterfazLogicaDominio;
using ElDescontracturante.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using ElDescontracturante.LogicaDominio;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
      private readonly ILogicaCategoria logicaCategoria;
      private readonly ILogicaPlaylist logicaPlaylist;

        public CategoriaController(ILogicaPlaylist logicaPlaylist, ILogicaCategoria logicaCategoria )
        {
            this.logicaCategoria = logicaCategoria;
            this.logicaPlaylist = logicaPlaylist;
        }

          
        [HttpPost]
        public ActionResult AgregarPlaylistsACategoria(CategoriaModel categoriaModel)
        {
            if (categoriaModel.NombreCategoria == null | categoriaModel.ListaPlaylist == null)
            {
                return BadRequest("Formato de JSON Incorrecto ");
            }

            Categoria categoria = new Categoria();

            try
            {
                categoria = categoriaModel.ToEntity();
                categoria.ListaPlaylist = logicaPlaylist.ObtenerPlaylist(categoriaModel.ListaPlaylist);
                this.logicaCategoria.AgregarPlaylist(categoria);
            }
            catch (Excepciones.ExcepcionNombreCategoriaIncorrecta e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionPlaylistInexistente e)
            {
                return NotFound(e.Message);
            }
            catch(Excepciones.ExcepcionPlaylistYaAsociadaACategoria e)
            {
                return Conflict(e.Message);
            }

            return Created("api/[controller]",categoria);
               
        }

       




    }
}
