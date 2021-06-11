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
    public class SolicitudController : ControllerBase
    {
        private readonly ILogicaCita logicaCita;
        private readonly ILogicaPsicologo logicaPsicologo;
        private readonly ILogicaLogin logicaLogin;
        private readonly ILogicaBonificacion logicaBonificacion;

        public SolicitudController(ILogicaCita logicaCita, ILogicaLogin logicaLogin, ILogicaPsicologo logicaPsicologo,ILogicaBonificacion logicaBonificacion)
        {
            this.logicaCita = logicaCita;
            this.logicaLogin = logicaLogin;
            this.logicaPsicologo = logicaPsicologo;
            this.logicaBonificacion = logicaBonificacion;
        }


        [HttpPost]
        public ActionResult AgregarCita([FromBody] SolicitudModel solicitudmodel)
        {
               Cita cita = new Cita();

                Solicitud solicitud = new Solicitud();
            try
            {
               solicitud = solicitudmodel.ToEntity();
               List<Psicologo> psicEspecializados = this.logicaPsicologo.ObtenerPsicologosEspecializado(solicitud.NombreProblematica);
               DateTime fecha = DateTime.Today;
               cita = logicaCita.GenerarCita(psicEspecializados,fecha);
               cita.EmailPaciente = solicitud.Email;
               cita.Costo = logicaCita.CalcularCostoConsulta(solicitud.MinutosDeLaConsulta,cita);
               logicaCita.Agregar(cita);
               logicaBonificacion.AgregarBonificacion(cita.EmailPaciente);
            }
         
            catch (Excepciones.ExcepcionNombreProblematicaIncorrecta e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionPsicologosInexistentes e)
            {
                return NotFound(e.Message);
            }
            catch (Excepciones.ExcepcionMotorBaseDeDatosCaido e)
            {
                return StatusCode(500, e.Message);
            }

            return Created("api/[controller]", cita);

        }













    }
}
