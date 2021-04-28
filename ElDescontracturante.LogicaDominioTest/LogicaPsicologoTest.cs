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
    public class LogicaPsicologoTest
    {
        Psicologo psicologo;
        LogicaPsicologo logicaPsicologo;
        Mock<IPsicologoRepositorio> mock;
        List<Psicologo> psicologoes;
       


        [TestInitialize]
        public void initialize()
        {
            psicologo = new Psicologo();
            psicologo.Nombre = "Jorge";
            psicologo.TipoDeConsulta = (ElDescontracturante.Dominio.Psicologo.ModoDeConsulta)Enum.Parse(typeof(ElDescontracturante.Dominio.Psicologo.ModoDeConsulta), "VideoLlamada");  
            psicologo.Email = "jorge@gmail.com";
            psicologoes = new List<Psicologo>();
            psicologoes.Add(psicologo);
            

            mock = new Mock<IPsicologoRepositorio>();
            mock.Setup(m => m.Agregar(psicologo));
            mock.Setup(m => m.Obtener()).Returns(psicologoes);
            logicaPsicologo = new LogicaPsicologo(mock.Object);

        }


        [TestMethod]
        public void TestAñadirPsicologo()
        {
   
            logicaPsicologo.Agregar(psicologo);
            var result = logicaPsicologo.Obtener("jorge@gmail.com");
            mock.VerifyAll();
            Assert.AreEqual(psicologo, result);
        }


        [TestMethod]
        public void TestObtenerPsicologo()
        {
            var result = logicaPsicologo.Obtener("jorge@gmail.com");
 
            Assert.AreEqual(psicologo, result);
        }



    }




    }

