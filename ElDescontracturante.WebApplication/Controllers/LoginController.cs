﻿using System;
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
    public class LoginController : ControllerBase
    {
        private readonly ILogicaAdministrador logicaAdministrador;
        private readonly ILogicaLogin logicaLogin;

   

        public LoginController(ILogicaLogin logicaLogin, ILogicaAdministrador logicaAdministrador)
        {
  
            this.logicaLogin = logicaLogin;
            this.logicaAdministrador = logicaAdministrador;
        }

        public ILogicaAdministrador Object { get; }

        [HttpGet]
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
                logicaAdministrador.Obtener(email, password);
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

            Token unToken = new Token();
            unToken.Id = token;
            unToken.Fecha = DateTime.Now;

            return Ok(JsonConvert.SerializeObject(unToken));

        }


    }
}
