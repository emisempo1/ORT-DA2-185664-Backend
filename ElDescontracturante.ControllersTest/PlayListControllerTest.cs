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
    public class PlaylistControllerTest
    {

        Mock<ILogicaPlaylist> mockPlaylist;
        Mock<ILogicaAudio> mockAudio;

        PlayListsController controllerPlaylist;


        [TestInitialize]
        public void Setup()
        {
            mockPlaylist = new Mock<ILogicaPlaylist>();
            mockAudio = new Mock<ILogicaAudio>();
            controllerPlaylist = new PlayListsController(mockPlaylist.Object,mockAudio.Object);
        }

        [TestMethod]
        public void TestAagregarPlaylistOk()
        {


            PlaylistModel playlistModel = new PlaylistModel()
            {
                Nombre = "Cachengue",
                Descripcion = "Para Escabiar y pasarla bien con tus panas",
                ListaAudio = new string[] { "Soltero Hasta la Tumba", "Con Altura" }
             

            };


            ActionResult result = controllerPlaylist.Agregarplaylist(playlistModel);

            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; // <-- Cast is before using it.

            Assert.AreEqual(200, repuestaAAPIController);

        }


        [TestMethod]
        public void TestObtenerPlaylist()
        {
           
            ActionResult result = controllerPlaylist.Obtenerplaylists();

            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; // <-- Cast is before using it.

            Assert.AreEqual(200, repuestaAAPIController);


        }










    }

}