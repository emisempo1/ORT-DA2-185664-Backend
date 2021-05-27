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
using Newtonsoft.Json;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   


    public class CategoriasController : ControllerBase
    {
      private readonly ILogicaCategoria logicaCategoria;
      private readonly ILogicaPlaylist logicaPlaylist;

        public CategoriasController(ILogicaPlaylist logicaPlaylist, ILogicaCategoria logicaCategoria )
        {
            this.logicaCategoria = logicaCategoria;
            this.logicaPlaylist = logicaPlaylist;
        }

          
        [HttpPost]
        public ActionResult AgregarPlaylistsACategoria(CategoriaModel categoriaModel)
        {
            if (categoriaModel == null)
            {
                return BadRequest("Formato de JSON Incorrecto ");
            }

            if (categoriaModel.NombreCategoria == null | categoriaModel.ListaPlaylist == null)
            {

                return BadRequest("Formato de JSON Incorrecto ");
            }

            Categoria categoria = new Categoria();

            try
            {
                categoria = categoriaModel.ToEntity();
                categoria.ListaPlaylist = logicaPlaylist.ObtenerPlaylist(categoriaModel.ListaPlaylist);
                this.logicaCategoria.AgregarPlaylistsACategoria(categoria);
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
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500,e.Message);
            }

            return Created("api/[controller]",categoria);
               
        }


        [HttpGet]
        public ActionResult ObtenerCategoria(string nombre)
        {

            if (nombre == null)
            {
                return BadRequest("Query Param Incorrecto");
            }

            Categoria categoria = new Categoria();

            try
            {
                categoria = this.logicaCategoria.ObtenerCategoria(nombre); 
            }
            catch (Excepciones.ExcepcionNombreCategoriaIncorrecta e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

           
            return Ok(JsonConvert.SerializeObject(categoria));

        }







    }
}
