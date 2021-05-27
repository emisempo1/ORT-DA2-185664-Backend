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
    public class PlayListsController : ControllerBase
    {
      private readonly ILogicaPlaylist logicaPlaylist;

       private readonly ILogicaAudio logicaAudio;



        public PlayListsController(ILogicaPlaylist logicaPlaylist, ILogicaAudio logicaAudio)
        {

            this.logicaPlaylist = logicaPlaylist;
            this.logicaAudio = logicaAudio;
        }

          
        [HttpPost]
        public ActionResult Agregarplaylist([FromBody]PlaylistModel playlistmodel)
        {
            if (playlistmodel == null)
            {
                return BadRequest("Formato de JSON Incorrecto");
            }
            Playlist playlist = new Playlist();
            try
            {
                playlist = playlistmodel.ToEntity();
                playlist.ListaAudios = logicaAudio.ObtenerAudios(playlistmodel.ListaAudio);
                this.logicaPlaylist.Agregar(playlist);
            }
            catch (ExcepcionPlaylistDuplicado e)
            {
                return Conflict(e.Message);
            }
            catch(Excepciones.ExcepcionAudioInexistente e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }
            return Created("api/[controller]", playlist);


        }





        [HttpGet]
        public ActionResult ObtenerPlaylist(string nombre)
        {
            Playlist playlist = new Playlist();

            try
            {
                playlist = this.logicaPlaylist.ObtenerPlaylist(nombre);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Excepciones.ExcepcionPlaylistInexistente e)
            {
                return NotFound(e.Message);
            }

            return Ok(JsonConvert.SerializeObject(playlist));

        }




    }
}
