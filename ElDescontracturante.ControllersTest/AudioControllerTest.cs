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

            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; // <-- Cast is before using it.

            Assert.AreEqual(200, repuestaAAPIController);

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

            var repuestaAAPIController = ((BadRequestObjectResult)result).StatusCode; // <-- Cast is before using it.

            Assert.AreEqual(400, repuestaAAPIController);


        }



        [TestMethod]
        public void TestObetnerAudios()
        {


            ActionResult result = controllerAudio.ObtenerAudios();


            var repuestaAAPIController = ((OkObjectResult)result).StatusCode; // <-- Cast is before using it.

            Assert.AreEqual(200, repuestaAAPIController);


        }




    }

}