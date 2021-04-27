
using System.Collections.Generic;
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using ElDescontracturante.LogicaDominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace Controllers.Tests
{







        [TestClass]
        public class LoginControllerTest
        {
            Administrador administrador;

            Mock<ILogicaAdministrador> mockAdministrador;
            Mock<ILogicaLogin> mockLogin;
            List<Administrador> administradores;

            LoginController controllerLogin;

    



            [TestInitialize]
            public void initialize()
            {

            mockLogin = new Mock<ILogicaLogin>();
            mockAdministrador = new Mock<ILogicaAdministrador>();
            Token tokenPrueba = new Token();
        
            controllerLogin = new LoginController(mockLogin.Object,mockAdministrador.Object);

            mockLogin.Setup(m => m.RegistrarToken()).Returns("tokendeprueba");
            mockLogin.Setup(m => m.BuscarToken("tokendeprueba"));


        }


       [TestMethod]
        public void TestLoguearseOk()
        {
          
            ActionResult result = controllerLogin.Loguearse("hola@gmail.com", "12345678");
            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; 
            Assert.AreEqual(200, repuestaAAPIController);
        }


        [TestMethod]
        public void TestLoguearseCredencialesInvalidas()
        {
            mockAdministrador.Setup(m => m.Obtener(It.IsAny<string>(), It.IsAny<string>())).Throws(new Excepciones.ExcepcionAdministradorInexistente("unadmin"));
            ActionResult result = controllerLogin.Loguearse("hola@gmail.com", "12345678");
            var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode; // <-- Cast is before using it.
            Assert.AreEqual(404, repuestaAAPIController);

        }












    }

}