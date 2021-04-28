
using System;
using System.Collections.Generic;
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace Controllers.Tests
{





    [TestClass]
    public class PsicologoControllerTest
    {



        [TestClass]
        public class LogicaPsicologoTest
        {
            Psicologo psicologo;
            Mock<ILogicaPsicologo> mockPsicologo;
            Mock<ILogicaLogin> mockLogin;
            List<Psicologo> psicologos;

            PsicologoController controllerPsicologo;



            [TestInitialize]
            public void initialize()
            {
                psicologo = new Psicologo();
                psicologo.Nombre = "Carlos";
                psicologo.TipoDeConsulta = (ElDescontracturante.Dominio.Psicologo.ModoDeConsulta)Enum.Parse(typeof(ElDescontracturante.Dominio.Psicologo.ModoDeConsulta), "VideoLlamada");
                psicologo.Email = "carlitos@gmail.com";
               


                mockPsicologo = new Mock<ILogicaPsicologo>();
                mockLogin = new Mock<ILogicaLogin>();
                mockPsicologo.Setup(m => m.Agregar(psicologo));
                mockPsicologo.Setup(m => m.Obtener(psicologo.Email)).Returns(psicologo);
                controllerPsicologo = new PsicologoController(mockPsicologo.Object, mockLogin.Object);
                

            }


       [TestMethod]
        public void TestAgregarPsicologoOk()
        {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>()));
                PsicologoModel psicologoModel = new PsicologoModel()
               {
                Nombre = "Carlos",
                Email= "carlitos@gmail.com",
                TipoDeConsulta =  "VideoLlamada"
               };

            ActionResult result = controllerPsicologo.AgregarPsicologo(token,psicologoModel);
            var repuestaAAPIController = ((CreatedResult)result).StatusCode; 
            Assert.AreEqual(201, repuestaAAPIController);
        }


            [TestMethod]
            public void TestAgregarPsicologoTokenInvalido()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionTokenInexistente(token));
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.AgregarPsicologo(token, psicologoModel);

                var repuestaAAPIController = ((ObjectResult)result).StatusCode;

                Assert.AreEqual(401, repuestaAAPIController);
            }













        }
    }
}

