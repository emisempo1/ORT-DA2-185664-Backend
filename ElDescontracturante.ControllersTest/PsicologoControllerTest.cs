
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
    public class AdministradorControllerTest
    {



        [TestClass]
        public class LogicaAdministradorTest
        {
            Administrador administrador;
            Mock<ILogicaAdministrador> mockAdministrador;
            Mock<ILogicaLogin> mockLogin;
            List<Administrador> administradores;

            AdministradorController controllerAdministrador;



            [TestInitialize]
            public void initialize()
            {
                administrador = new Administrador();
                administrador.Nombre = "Carlos";
                administrador.Password = "123455678";
                administrador.Email = "dsd@gmail.com";
                administradores = new List<Administrador>();
                administradores.Add(administrador);


                mockAdministrador = new Mock<ILogicaAdministrador>();
                mockLogin = new Mock<ILogicaLogin>();
                mockAdministrador.Setup(m => m.Agregar(administrador));
                mockAdministrador.Setup(m => m.Obtener(administrador.Email, administrador.Password)).Returns(administrador);
                controllerAdministrador = new AdministradorController(mockAdministrador.Object, mockLogin.Object);
                

            }


       [TestMethod]
        public void TestAgregarAdministradorOk()
        {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>()));
                AdministradorModel administradorModel = new AdministradorModel()
               {
                Nombre = "Fabio",
                Email= "fabiooyrockero@gmail.com",
                Password =  "123456"};

            ActionResult result = controllerAdministrador.AgregarAdministrador(token,administradorModel);
            var repuestaAAPIController = ((CreatedResult)result).StatusCode; 
            Assert.AreEqual(201, repuestaAAPIController);
        }


            [TestMethod]
            public void TestAgregarAdministradorTokenInvalido()
            {
                string token = "tokenvalido";
                mockLogin.Setup(m => m.BuscarToken(It.IsAny<string>())).Throws(new Excepciones.ExcepcionTokenInexistente(token));
                AdministradorModel administradorModel = new AdministradorModel()
                {
                    Nombre = "Fabio",
                    Email = "fabiooyrockero@gmail.com",
                    Password = "123456"
                };

                ActionResult result = controllerAdministrador.AgregarAdministrador(token, administradorModel);

                var repuestaAAPIController = ((ObjectResult)result).StatusCode;

                Assert.AreEqual(401, repuestaAAPIController);
            }













        }
    }
}

