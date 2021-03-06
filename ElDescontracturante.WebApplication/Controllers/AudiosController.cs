using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElDescontracturante.InterfazLogicaDominio;
using ElDescontracturante.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudiosController : ControllerBase
    {
      private readonly ILogicaAudio logicaAudio;

        public AudiosController(ILogicaAudio logicaAudio )
        {
            this.logicaAudio = logicaAudio;
        }

          
        [HttpPost]
        public ActionResult AgregarAudio(AudioModel Audiomodel)
        {
            if (Audiomodel == null)
            {
                return BadRequest("Formato de JSON Incorrecto");
            }
            Audio Audio = new Audio();
            try
            {
                Audio = Audiomodel.ToEntity();
                this.logicaAudio.Agregar(Audio);
            }
            catch (Excepciones.ExcepcionAudioDuplicado e)
            {
                return Conflict(e.Message);
            }
            catch (Excepciones.ExcepcionUnidadDeTiempoDesconocida e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }
            return Created("api/[controller]", Audio);         
        }

    
        [HttpGet]
        public ActionResult ObtenerAudios()
        {
            List<Audio> audios = new List<Audio>();
           
            try             
            {
               audios =  this.logicaAudio.ObtenerAudios(); ;
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok(audios);

        }

        [HttpDelete]
        public ActionResult BorrarAudio(string nombre)
        {
           
            Audio Audio = new Audio();
            try
            {

                this.logicaAudio.Borrar(nombre);
            }
            catch (Excepciones.ExcepcionAudioInexistente e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }
            return Ok("el aduio fue eliminado correctamente :" + nombre);
        }




    }
}
