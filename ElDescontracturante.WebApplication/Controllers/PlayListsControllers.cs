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
                return BadRequest(e.Message);
            }
            catch(Excepciones.ExcepcionAudioInexistente e)
            {
             return BadRequest(e.Message);
            }

            return Ok("Se Agrego Correctamente");
               
        }

        [HttpGet]
        public ActionResult Obtenerplaylists()
        {
            List<Playlist> playlists = new List<Playlist>();
           
            try
            {
               playlists =  this.logicaPlaylist.Obtenerplaylists(); ;
            }
            catch (ExcepcionPlaylistDuplicado)
            {
                return BadRequest("Ya existe un playlist con Dicho Nombre");
            }

            return Ok(playlists);

        }




    }
}
