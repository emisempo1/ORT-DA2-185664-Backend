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
    public class AudioControllerTest
    {

        Mock<ILogicaAudio> mock;
        AudiosController controllerAudio;


        [TestInitialize]
        public void Setup()
        {
            mock = new Mock<ILogicaAudio>();
            controllerAudio = new AudiosController(mock.Object);
        }

        [TestMethod]
        public void TestAagregarAudioOk()
        {
            var unidaddeTiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), "Minuto");

            AudioModel audioModel = new AudioModel()
            {
                Nombre = "Soltero Hasta la Tumba",
                Duracion = 4,
                UnidadDeTiempo = "Minuto",
                NombreCreador = "El Reja",
                UrlImagen = "ElRejaSolteroHastaLaTumba.jpg",
                UrlMp3 = "ElRejaSolteroHastaLaTumba.mp3"
            };

            ActionResult result = controllerAudio.AgregarAudio(audioModel);
            var repuestaAAPIController = ((CreatedResult)result).StatusCode; 
            Assert.AreEqual(201, repuestaAAPIController);
        }



        [TestMethod]
        public void TestAagregarAudioNull()
        {
            var unidaddeTiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), "Minuto");
            ActionResult result = controllerAudio.AgregarAudio(null);
            var repuestaAAPIController = ((BadRequestObjectResult)result).StatusCode;
            Assert.AreEqual(400, repuestaAAPIController);
        }


        [TestMethod]
        public void TestAagregarAudioDuplicado()
        {
            var unidaddeTiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), "Minuto");

            mock.Setup(m => m.Agregar(It.IsAny<Audio>())).Throws(new Excepciones.ExcepcionAudioDuplicado());
            controllerAudio = new AudiosController(mock.Object);

            AudioModel audioModel = new AudioModel()
            {
                Nombre = "Soltero Hasta la Tumba",
                Duracion = 4,
                UnidadDeTiempo = "Minuto",
                NombreCreador = "El Reja",
                UrlImagen = "ElRejaSolteroHastaLaTumba.jpg",
                UrlMp3 = "ElRejaSolteroHastaLaTumba.mp3"
            };

            ActionResult result = controllerAudio.AgregarAudio(audioModel);
            var repuestaAAPIController = ((ConflictObjectResult)result).StatusCode;
            Assert.AreEqual(409, repuestaAAPIController);
        }



        [TestMethod]
        public void TestAgregarAudioMalUnidadDeTiempo()
        {
            var unidaddeTiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), "Minuto");

            AudioModel audioModel = new AudioModel()
            {
                Nombre = "Soltero Hasta la Tumba",
                Duracion = 4,
                UnidadDeTiempo = "Joule",
                NombreCreador = "El Reja",
                UrlImagen = "ElRejaSolteroHastaLaTumba.jpg",
                UrlMp3 = "ElRejaSolteroHastaLaTumba.mp3"
            };

            ActionResult result = controllerAudio.AgregarAudio(audioModel);

            var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode; // <-- Cast is before using it.

            Assert.AreEqual(404, repuestaAAPIController);


        }


        [TestMethod]
        public void TestAagregarAudioBdCaida()
        {
            var unidaddeTiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), "Minuto");

            mock.Setup(m => m.Agregar(It.IsAny<Audio>())).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
            controllerAudio = new AudiosController(mock.Object);

            AudioModel audioModel = new AudioModel()
            {
                Nombre = "Soltero Hasta la Tumba",
                Duracion = 4,
                UnidadDeTiempo = "Minuto",
                NombreCreador = "El Reja",
                UrlImagen = "ElRejaSolteroHastaLaTumba.jpg",
                UrlMp3 = "ElRejaSolteroHastaLaTumba.mp3"
            };

            ActionResult result = controllerAudio.AgregarAudio(audioModel);
            var repuestaAAPIController = ((ObjectResult)result).StatusCode;
            Assert.AreEqual(500, repuestaAAPIController);
        }


        [TestMethod]
        public void TestObetnerAudios()
        {
            ActionResult result = controllerAudio.ObtenerAudios();
            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; // <-- Cast is before using it.
            Assert.AreEqual(200, repuestaAAPIController);
        }

        [TestMethod]
        public void TestObetnerAudiosBDCaida()
        {
            mock.Setup(m => m.ObtenerAudios()).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
            controllerAudio = new AudiosController(mock.Object);
            ActionResult result = controllerAudio.ObtenerAudios();
            var repuestaAAPIController = ((ObjectResult)result).StatusCode;
            Assert.AreEqual(500, repuestaAAPIController);
        }

        [TestMethod]
        public void TestBorrarAudioOk()
        {
            ActionResult result = controllerAudio.BorrarAudio("audioExistente");
            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; // <-- Cast is before using it.
            Assert.AreEqual(200, repuestaAAPIController);
        }

        [TestMethod]
        public void TestBorrarAudioInexistente()
        {
            mock.Setup(m => m.Borrar(It.IsAny<string>())).Throws(new Excepciones.ExcepcionAudioInexistente("audio inexistente"));
            controllerAudio = new AudiosController(mock.Object);
            ActionResult result = controllerAudio.BorrarAudio("audioInexistente");
            var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode;
            Assert.AreEqual(404, repuestaAAPIController);
        }

        [TestMethod]
        public void TestBorrarAudioBDCaida()
        {
            mock.Setup(m => m.Borrar(It.IsAny<string>())).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
            controllerAudio = new AudiosController(mock.Object);
            ActionResult result = controllerAudio.BorrarAudio("audioExistente");
            var repuestaAAPIController = ((ObjectResult)result).StatusCode;
            Assert.AreEqual(500, repuestaAAPIController);
        }


    }

}