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
    public class LoginController : ControllerBase
    {
 
     private readonly ILogicaLogin logicaLogin;

        public LoginController(ILogicaAdministrador logicaAdministrador , ILogicaLogin logicaLogin)
        {
  
            this.logicaLogin = logicaLogin;
        }

        [HttpPost]
        public ActionResult Loguearse(string email, string password)
        {
            Guid g = Guid.NewGuid();
            string token = g.ToString();

            if (email == null | password == null)
            {
                return BadRequest("Query Param Incorrecto");
            }

            try
            {       
                token = logicaLogin.RegistrarToken();
            }
            catch (Excepciones.ExcepcionAdministradorInexistente e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }


            return Ok(token);

        }


    }
}
