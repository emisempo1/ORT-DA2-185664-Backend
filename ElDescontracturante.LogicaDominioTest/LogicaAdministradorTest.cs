using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.LogicaDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominioTest
{
    [TestClass]
    public class LogicaAdministradorTest
    {
        Administrador administrador;
        LogicaAdministrador logicaAdministrador;
        Mock<IAdministradorRepositorio> mock;
        List<Administrador> administradores;
       


        [TestInitialize]
        public void initialize()
        {
            administrador = new Administrador();
            administrador.Nombre = "Jorge";
            administrador.Password = "123456";
            administrador.Email = "jorge@gmail.com";
            administradores = new List<Administrador>();
            administradores.Add(administrador);
            

            mock = new Mock<IAdministradorRepositorio>();
            mock.Setup(m => m.Agregar(administrador));
            mock.Setup(m => m.Obtener()).Returns(administradores);
            logicaAdministrador = new LogicaAdministrador(mock.Object);

        }


        [TestMethod]
        public void TestAñadirAdministrador()
        {
            logicaAdministrador.Agregar(administrador);
            var result = logicaAdministrador.Obtener("jorge@gmail.com","123456");
            mock.VerifyAll();
            Assert.AreEqual(administrador, result);
        }


        [TestMethod]
        public void TestObtenerAdministrador()
        {
            var result = logicaAdministrador.Obtener("jorge@gmail.com", "123456");
 
            Assert.AreEqual(administrador, result);
        }



    }




    }

