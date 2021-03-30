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
    public class AudioController : ControllerBase
    {
      private readonly ILogicaAudio logicaAudio;

        public AudioController(ILogicaAudio logicaAudio )
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
            catch (Excepciones.ExcepcionAudioDuplicado)
            {
                return BadRequest("Ya existe un Audio con Dicho Nombre");
            }

            return Ok("Se Agrego Correctamente");
               
        }

   
    }
}
