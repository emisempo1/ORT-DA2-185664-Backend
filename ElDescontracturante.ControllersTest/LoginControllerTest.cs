
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
            Mock<ILogicaLogin> mock;
            List<Administrador> administradores;

            LoginController controllerLogin;

    



            [TestInitialize]
            public void initialize()
            {

            mock = new Mock<ILogicaLogin>();
            Token tokenPrueba = new Token();
        
            controllerLogin = new LoginController(mock.Object);

            mock.Setup(m => m.RegistrarToken()).Returns("tokendeprueba");
            mock.Setup(m => m.BuscarToken("tokendeprueba"));


        }


       [TestMethod]
        public void TestLoguearseOk()
        {
          
            ActionResult result = controllerLogin.Loguearse("hola@gmail.com", "12345678");
            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; 
            Assert.AreEqual(200, repuestaAAPIController);
        }


       









    }

}