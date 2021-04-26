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
    public class AdministradorController : ControllerBase
    {
      private readonly ILogicaAdministrador logicaAdministrador;

        private readonly ILogicaLogin  logicaLogin;

        public AdministradorController(ILogicaAdministrador logicaAdministrador,ILogicaLogin logicaLogin )
        {
            this.logicaAdministrador = logicaAdministrador;
            this.logicaLogin = logicaLogin;
        }


        [HttpPost]
        public ActionResult AgregarAdministrador([FromHeader] string token, [FromBody] AdministradorModel administradormodel)
        {
            if (administradormodel == null)
            {
                return BadRequest("Formato de JSON Incorrecto");
            }
            Administrador administrador = new Administrador();
            try
            {
                this.logicaLogin.BuscarToken(token);
                administrador = administradormodel.ToEntity();
                this.logicaAdministrador.Agregar(administrador);
            }
            catch (Excepciones.ExcepcionAdministradorDuplicado e)
            {
                return Conflict(e.Message);
            }
            catch (Excepciones.ExcepcionTokenInexistente e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return Created("api/[controller]", administrador);
  
        }


    










    }
}
