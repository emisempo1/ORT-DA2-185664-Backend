using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazLogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace ElDescontracturante.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BonificacionController : ControllerBase
    {
        private readonly ILogicaBonificacion logicaBonificacion;
        private readonly ILogicaLogin logicaLogin;

        public BonificacionController(ILogicaBonificacion logicaBonificacion, ILogicaLogin logicaLogin)
        {
            this.logicaBonificacion = logicaBonificacion;
            this.logicaLogin = logicaLogin;
        }
    

        [HttpPost]
        public ActionResult AprobarBonificacion([FromHeader] string token,[FromBody] BonificacionModel bonificacionmodel)
        {
            if (bonificacionmodel == null)
            {
                return BadRequest("Formato de JSON Incorrecto");
            }
            Bonificacion bonificacion = new Bonificacion();
            try
            {
                this.logicaLogin.BuscarToken(token);
                bonificacion = bonificacionmodel.ToEntity();
                this.logicaBonificacion.Aprobar(bonificacion);
            }
            catch (Excepciones.ExcepcionTokenInexistente e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Excepciones.ExcepcionBonificacionInexistente e )
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok("Se bonifo correctamente, " + bonificacionmodel.Email + " lo vera reflejado en la proxima consulta");
        }


        [HttpGet]
        public ActionResult ObtenerBonificacionesNoAprobadas()
        {
            List<Bonificacion> listaBonificaciones;
            try
            {
                listaBonificaciones = this.logicaBonificacion.ObtenerBonificacionesNoAprobadas();
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Excepciones.ExcepcionBonificacionInexistente e)
            {
                return NotFound(e.Message);
            }
            return Ok(JsonConvert.SerializeObject(listaBonificaciones));
        }


    }
}
