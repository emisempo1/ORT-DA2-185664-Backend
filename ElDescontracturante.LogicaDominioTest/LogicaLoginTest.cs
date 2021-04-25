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
    public class LogicaLoginTest
    {
     
        LogicaLogin logicaLogin;
        List<Token> tokens;
        Mock<ITokenRepositorio> mock;
    
       


        [TestInitialize]
        public void initialize()
        {
            tokens = new List<Token>();
            mock = new Mock<ITokenRepositorio>();
            logicaLogin = new LogicaLogin(mock.Object);

        }


        [TestMethod]
        public void TestRegistrarToken()
        {
            
            Token tokenPrueba = new Token();
            tokenPrueba.Id = logicaLogin.RegistrarToken();
            tokens.Add(tokenPrueba);
            mock.Setup(m => m.ObtenerTokens()).Returns(tokens);
            logicaLogin.BuscarToken(tokenPrueba.Id);
            mock.VerifyAll();
        }


        [TestMethod]
        public void TestBuscarToken()
        {
            
            Token tokenPrueba = new Token();
            tokenPrueba.Id = logicaLogin.RegistrarToken();
            tokens.Add(tokenPrueba);
            mock.Setup(m => m.ObtenerTokens()).Returns(tokens);
            logicaLogin.BuscarToken(tokenPrueba.Id);
            mock.VerifyAll();
        }



    }




    }

