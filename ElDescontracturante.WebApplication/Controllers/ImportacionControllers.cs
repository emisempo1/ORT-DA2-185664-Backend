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
using Excepciones;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportacionController : ControllerBase
    {

        private readonly ILogicaCategoria logicaCategoria;
        private readonly ILogicaReflection logicaReflection;
        private readonly ILogicaPlaylist logicaPlaylist;
        private readonly ILogicaAudio logicaAudio;

        public ImportacionController(ILogicaCategoria logicaCategoria, ILogicaPlaylist logicaPlaylist, ILogicaAudio logicaAudio, ILogicaReflection logicaReflection)
        {
            this.logicaCategoria = logicaCategoria;
            this.logicaReflection = logicaReflection;
            this.logicaPlaylist = logicaPlaylist;
            this.logicaAudio = logicaAudio;
        }


        [HttpPost]
        public ActionResult AgregarImportacion(ImportacionModel importacionModel)
        {
            if (importacionModel == null)
            {
                return BadRequest("Formato de JSON Incorrecto");
            }
            Categoria categoria = new Categoria();
            try
            {
                categoria = this.logicaReflection.InstanciarObjetosConInterfazConocida(importacionModel.TipoDeArchivo, importacionModel.Path);
                for (int i = 0; i < categoria.ListaPlaylist.Count; i++)
                {
                    this.logicaAudio.AgregarOmitiendoRepetidos(categoria.ListaPlaylist[i].ListaAudios);
                    this.logicaPlaylist.AgregarOmitiendoRepetidos(categoria.ListaPlaylist[i]);
                    this.logicaPlaylist.AgregarAsociaciones(categoria.ListaPlaylist[i]);
                    this.logicaCategoria.AgregarPlaylistACategoriaOmitiendoRepetidos(categoria.NombreCategoria, categoria.ListaPlaylist[i]);
                }     
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }
            return Ok("Archivo Importado Con Exito");
        }
    }
}
