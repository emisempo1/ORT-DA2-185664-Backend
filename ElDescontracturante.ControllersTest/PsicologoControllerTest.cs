
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
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada",
                    ProblematicasEspecializadas = new string[] { "Depresion", "Estres", "Ansiedad" },
                    FechaIngreso = "1995-05-05",
                    DireccionFisica = "yaguaron 1415"
            };

                ActionResult result = controllerPsicologo.AgregarPsicologo(token, psicologoModel);
                var repuestaAAPIController = ((CreatedResult)result).StatusCode;
                Assert.AreEqual(201, repuestaAAPIController);


                

            }


            [TestMethod]
        public void TestAgregarPsicologoConListaEspecialidadesenNull()
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
            var repuestaAAPIController = ((ConflictObjectResult)result).StatusCode; 
            Assert.AreEqual(409, repuestaAAPIController);
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




            [TestMethod]
            public void TestAgregarPsicologoProblematicaIncorrecta()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionNombreProblematicaIncorrecta("visiones"));
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.AgregarPsicologo(token, psicologoModel);

                var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode;

                Assert.AreEqual(404, repuestaAAPIController);
            }


            [TestMethod]
            public void TestAgregarPsicologoPsicologoInexistente()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionNombreProblematicaIncorrecta("visiones"));
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.AgregarPsicologo(token, psicologoModel);

                var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode;

                Assert.AreEqual(404, repuestaAAPIController);
            }

          

            [TestMethod]
            public void TestAgregarPsicologoPsicologoDuplicado()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionPsicologoDuplicado());
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.AgregarPsicologo(token, psicologoModel);

                var repuestaAAPIController = ((ConflictObjectResult)result).StatusCode;

                Assert.AreEqual(409, repuestaAAPIController);
            }


            [TestMethod]
            public void TestAgregarPsicologoModoConsultaIncorrecto()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionNombreModoDeConsultaIncorrecta("al aire libre"));
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.AgregarPsicologo(token, psicologoModel);

                var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode;

                Assert.AreEqual(404, repuestaAAPIController);
            }





            [TestMethod]
            public void TestAgregarPsicologoPsicologoBdCaida()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.AgregarPsicologo(token, psicologoModel);

                var repuestaAAPIController = ((ObjectResult)result).StatusCode;

                Assert.AreEqual(500, repuestaAAPIController);
            }











            [TestMethod]
            public void TestBorrarPsicologoOk()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>()));
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada",
                    ProblematicasEspecializadas = new string[] { "Depresion", "Estres", "Ansiedad" },
                    FechaIngreso = "1995-05-05",
                    DireccionFisica = "yaguaron 1415"
                };

                ActionResult result = controllerPsicologo.BorrarPsicologo(token, psicologoModel.Email);
                var repuestaAAPIController = ((OkObjectResult)result).StatusCode;
                Assert.AreEqual(200, repuestaAAPIController);

            }


        


            [TestMethod]
            public void TestBorrarPsicologoTokenInvalido()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionTokenInexistente(token));
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.BorrarPsicologo(token, psicologoModel.Email);

                var repuestaAAPIController = ((ObjectResult)result).StatusCode;

                Assert.AreEqual(401, repuestaAAPIController);
            }


            [TestMethod]
            public void TestBorrarPsicologoInexistente()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionPsicologoInexistente(token));
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.BorrarPsicologo(token, psicologoModel.Email);

                var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode;

                Assert.AreEqual(404, repuestaAAPIController);
            }


            [TestMethod]
            public void TestBorrarPsicologoBdCaida()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
                PsicologoModel psicologoModel = new PsicologoModel()
                {
                    Nombre = "Carlos",
                    Email = "carlitos@gmail.com",
                    TipoDeConsulta = "VideoLlamada"
                };

                ActionResult result = controllerPsicologo.BorrarPsicologo(token, psicologoModel.Email);

                var repuestaAAPIController = ((ObjectResult)result).StatusCode;

                Assert.AreEqual(500, repuestaAAPIController);
            }







        }
    }
}

