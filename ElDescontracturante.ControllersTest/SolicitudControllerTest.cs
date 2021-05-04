using System;
using System.Collections.Generic;
using System.Linq;
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazLogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace Controllers.Tests
{





    [TestClass]
    public class SolicitudControllerTest
    {

        Mock<ILogicaCita> mockCita;
        Mock<ILogicaLogin> mockLogin;
        Mock<ILogicaPsicologo> mockLogicaPsicologo;

        SolicitudController controllerSolicitud;

        Cita cita;


       [TestInitialize]
        public void Setup()
        {
            mockCita = new Mock<ILogicaCita>();
            mockLogin = new Mock<ILogicaLogin>();
            mockLogicaPsicologo = new Mock<ILogicaPsicologo>();

            cita = new Cita()
            {
                EmailPsicologo = "elviejopsicologo@gmail.com",
                NombrePsicologo = "Roku",
                FechaConsulta = Convert.ToDateTime("2021-05-03"),
                TipoDeConsulta = 0,
                Direccion = "yaguaron 1415",
                EmailPaciente = "maxi@gmail.com"
            };


            controllerSolicitud = new SolicitudController(mockCita.Object, mockLogin.Object,mockLogicaPsicologo.Object);
        }

        [TestMethod]
        public void TestGenerarCitaOk()
        {
            mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>()));
            mockCita.Setup(m => m.GenerarCita(It.IsAny<List<Psicologo>>(), It.IsAny<DateTime>())).Returns(cita);

            SolicitudModel solicitudModel = new SolicitudModel()
            {
                Celular = "094556723",
                Email = "maxi@gmail.com",
                Nombre = "Maxi",
                FechaNacimiento = "1982-05-05 ",
                Problematica = "Depresion"
            };

            ActionResult result = controllerSolicitud.AgregarCita("tokenvalido",solicitudModel);
            var repuestaAAPIController = ((CreatedResult)result).StatusCode; // <-- Cast is before using it.
            Assert.AreEqual(201, repuestaAAPIController);
        }




      




    }

}