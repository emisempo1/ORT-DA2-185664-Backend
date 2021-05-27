using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElDescontracturante.InterfazLogicaDominio;
using ElDescontracturante.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ILogicaLogin logicaLogin;

   

        public TokenController(ILogicaLogin logicaLogin)
        {
  
            this.logicaLogin = logicaLogin;
        }

        public ILogicaAdministrador Object { get; }

       
        [HttpGet]
        public ActionResult ComprobarToken(string token)
        {    
            if (token == null)
            {
                return BadRequest("Query Param Incorrecto");
            }
            try
            {
                logicaLogin.BuscarToken(token);
            }
            catch (Excepciones.ExcepcionTokenInexistente e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok(JsonConvert.SerializeObject(true));
        }


    }
}
