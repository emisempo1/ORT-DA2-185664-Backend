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

        public AdministradorController(ILogicaAdministrador logicaAdministrador )
        {
            this.logicaAdministrador = logicaAdministrador;
        }

          
        [HttpPost]
        public ActionResult AgregarAdministrador(AdministradorModel administradormodel)
        {
            if (administradormodel == null)
            {
                return BadRequest("Formato de JSON Incorrecto");
            }
            Administrador administrador = new Administrador();
            try
            {
                administrador = administradormodel.ToEntity();
                this.logicaAdministrador.Agregar(administrador);
            }
            catch (Excepciones.ExcepcionAdministradorDuplicado e)
        
            {
                return Conflict(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return Created("api/[controller]", administrador);
  
        }





        [HttpGet]
        public ActionResult ObtenerAdministrador(string email, string password)
        {

            if (email == null | password == null)
            {
                return BadRequest("Query Param Incorrecto");
            }

           Administrador administrador = new Administrador();


            try
            {
                administrador = logicaAdministrador.Obtener(email, password);
            }
            catch (Excepciones.ExcepcionAdministradorInexistente e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }


            return Ok(administrador);

        }






    }
}
