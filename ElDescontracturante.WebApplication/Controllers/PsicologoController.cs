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
    public class PsicologoController : ControllerBase
    {
       private readonly ILogicaPsicologo logicaPsicologo;

        private readonly ILogicaLogin  logicaLogin;

        public PsicologoController(ILogicaPsicologo logicaPsicologo,ILogicaLogin logicaLogin )
        {
            this.logicaPsicologo = logicaPsicologo;
            this.logicaLogin = logicaLogin;
        }


        [HttpPost]
        public ActionResult AgregarPsicologo([FromHeader] string token, [FromBody] PsicologoModel psicologomodel)
        {
            Psicologo psicologo = new Psicologo();
            try
            {
                this.logicaLogin.BuscarToken(token);
                psicologo = psicologomodel.ToEntity();
                var especialidades = psicologomodel.GetListaProblematicas();
                this.logicaPsicologo.Agregar(psicologo);
                this.logicaPsicologo.AgregarEspecialidadEnProblematica(psicologomodel.Email, especialidades);     
            }
            catch (Excepciones.ExcepcionPsicologoDuplicado e)
            {
                return Conflict(e.Message);
            }
            catch (Excepciones.ExcepcionNombreProblematicaIncorrecta e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionNombreModoDeConsultaIncorrecta e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionTokenInexistente e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return Created("api/[controller]", psicologo);
  
        }


    










    }
}
