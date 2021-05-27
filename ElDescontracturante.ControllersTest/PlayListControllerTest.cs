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
            var repuestaAAPIController = ((CreatedResult)result).StatusCode; 
           Assert.AreEqual(201, repuestaAAPIController);
        }

        [TestMethod]
        public void TestAagregarPlaylistNull()
        {
            ActionResult result = controllerPlaylist.Agregarplaylist(null);
            var repuestaAAPIController = ((BadRequestObjectResult)result).StatusCode; 
            Assert.AreEqual(400, repuestaAAPIController);
        }

        [TestMethod]
        public void TestAagregarPlaylistDuplicada()
        {
            mockPlaylist.Setup(m => m.Agregar(It.IsAny<Playlist>())).Throws(new Excepciones.ExcepcionPlaylistDuplicado());
            controllerPlaylist = new PlayListsController(mockPlaylist.Object, mockAudio.Object);

            PlaylistModel playlistModel = new PlaylistModel()
            {
                Nombre = "Cachengue",
                Descripcion = "Para Escabiar y pasarla bien con tus panas",
                ListaAudio = new string[] { "Soltero Hasta la Tumba", "Con Altura" }


            };
            ActionResult result = controllerPlaylist.Agregarplaylist(playlistModel);
            var repuestaAAPIController = ((ConflictObjectResult)result).StatusCode;
            Assert.AreEqual(409, repuestaAAPIController);
        }

        [TestMethod]
        public void TestPlaylistconAudioInexistente()
        {
            mockAudio.Setup(m => m.ObtenerAudios(It.IsAny<string[]>())).Throws(new Excepciones.ExcepcionAudioInexistente("AudioInexistente"));
            controllerPlaylist = new PlayListsController(mockPlaylist.Object, mockAudio.Object);
            PlaylistModel playlistModel = new PlaylistModel()
            {
                Nombre = "Cachengue",
                Descripcion = "Para Escabiar y pasarla bien con tus panas",
                ListaAudio = new string[] { "Soltero Hasta la Tumba", "Con Altura" }


            };
            ActionResult result = controllerPlaylist.Agregarplaylist(playlistModel);
            var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode;
            Assert.AreEqual(404, repuestaAAPIController);
        }


        [TestMethod]
        public void TestPlaylistconBdCaida()
        {
            mockPlaylist.Setup(m => m.Agregar(It.IsAny<Playlist>())).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
            controllerPlaylist = new PlayListsController(mockPlaylist.Object, mockAudio.Object);
            PlaylistModel playlistModel = new PlaylistModel()
            {
                Nombre = "Cachengue",
                Descripcion = "Para Escabiar y pasarla bien con tus panas",
                ListaAudio = new string[] { "Soltero Hasta la Tumba", "Con Altura" }


            };
            ActionResult result = controllerPlaylist.Agregarplaylist(playlistModel);
            var repuestaAAPIController = ((ObjectResult)result).StatusCode;
            Assert.AreEqual(500, repuestaAAPIController);
        }


        [TestMethod]
        public void TestObtenerPlaylist()
        {       
            ActionResult result = controllerPlaylist.ObtenerPlaylist("Cachuengue");
            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; // <-- Cast is before using it.
            Assert.AreEqual(200, repuestaAAPIController);
        }

        [TestMethod]
        public void TestObtenerPlaylistConBdCaida()
        {
            mockPlaylist.Setup(m => m.ObtenerPlaylist("Cachuengue")).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
            controllerPlaylist = new PlayListsController(mockPlaylist.Object, mockAudio.Object);
            ActionResult result = controllerPlaylist.ObtenerPlaylist("Cachuengue");
            var repuestaAAPIController = ((ObjectResult)result).StatusCode;
            Assert.AreEqual(500, repuestaAAPIController);
        }










    }

}