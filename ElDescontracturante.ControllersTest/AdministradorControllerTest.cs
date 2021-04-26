
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
            Mock<ILogicaAdministrador> mock;
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


                mock = new Mock<ILogicaAdministrador>();
                mock.Setup(m => m.Agregar(administrador));
                mock.Setup(m => m.Obtener(administrador.Email, administrador.Password)).Returns(administrador);
                controllerAdministrador = new AdministradorController(mock.Object);
                

            }


       [TestMethod]
        public void TestAgregarAdministradorOk()
        {
            AdministradorModel administradorModel = new AdministradorModel()
            {
                Nombre = "Fabio",
                Email= "fabiooyrockero@gmail.com",
                Password =  "123456"};

            ActionResult result = controllerAdministrador.AgregarAdministrador(administradorModel);
            var repuestaAAPIController = ((CreatedResult)result).StatusCode; 
            Assert.AreEqual(201, repuestaAAPIController);
        }












    }
    }
}

