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
    public class CategoriaControllerTest
    {
        Mock<ILogicaPlaylist> mockPlaylist;
        Mock<ILogicaAudio> mockAudio;

        Mock<ILogicaCategoria> mockCategoria;

        PlayListsController controllerPlaylist;
        CategoriaController controllerCategoria;


        [TestInitialize]
        public void Setup()
        {
            mockPlaylist = new Mock<ILogicaPlaylist>();
            mockAudio = new Mock<ILogicaAudio>();
            mockCategoria = new Mock<ILogicaCategoria>();

            controllerPlaylist = new PlayListsController(mockPlaylist.Object, mockAudio.Object);
            controllerCategoria = new CategoriaController(mockPlaylist.Object, mockCategoria.Object);
        }


        [TestMethod]
        public void TestAagregarPlaylistAACategoriaOk()
        {


            CategoriaModel categoriaModel = new CategoriaModel()
            {
                NombreCategoria = "Dormir",
                ListaPlaylist = new string[] { "Cachengue" }
             

            };


            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(categoriaModel);

            var repuestaAAPIController = ((CreatedResult)result).StatusCode;

            Assert.AreEqual(201, repuestaAAPIController);

        }


        [TestMethod]
        public void TestObtenerCategoria()
        {
           
            ActionResult result = controllerCategoria.ObtenerCategoria("Dormir");

            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; // <-- Cast is before using it.

            Assert.AreEqual(200, repuestaAAPIController);


        }










    }

}