using ElDescontracturante.AccesoADatos.Repositorios;
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.LogicaDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace ElDescontracturante.LogicaDominioTest
{
    [TestClass]
    public class LogicaAudioTest
    {
        Audio audio;
        LogicaAudio logicaAudio;
  


        [TestInitialize]
        public void initialize()
        {



        }


        [TestMethod]
        public void TestAñadirAudio()
        {

            var unidaddetiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), "Minuto");

            audio = new Audio();
            {
                audio.Nombre = "Soltero Hasta la Tumba";
                audio.Duracion = 4;
                audio.UnidadDeTiempo = unidaddetiempo;
                audio.NombreCreador = "El Reja";
                audio.UrlImagen = "ElRejaSolteroHastaLaTumba.jpg";
                audio.UrlMp3 = "ElRejaSolteroHastaLaTumba.mp3";
            };

            Mock<IAudioRepositorio> mock = new Mock<IAudioRepositorio>();
            List<Audio> audios = new List<Audio>();
            audios.Add(audio);
            mock.Setup(m => m.ObtenerAudios()).Returns(audios);
            logicaAudio = new LogicaAudio(mock.Object);

            logicaAudio.Agregar(audio);
            var result = logicaAudio.ObtenerAudios();
            mock.VerifyAll();
            Assert.AreEqual(audio, result[0]);
        }







        [TestMethod]
        public void TestObtenerAudios()
        {

            var unidaddetiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), "Minuto");

            audio = new Audio();
            {
                audio.Nombre = "Soltero Hasta la Tumba";
                audio.Duracion = 4;
                audio.UnidadDeTiempo = unidaddetiempo;
                audio.NombreCreador = "El Reja";
                audio.UrlImagen = "ElRejaSolteroHastaLaTumba.jpg";
                audio.UrlMp3 = "ElRejaSolteroHastaLaTumba.mp3";
            };

            Mock<IAudioRepositorio> mock = new Mock<IAudioRepositorio>();
            List<Audio> audios = new List<Audio>();
            audios.Add(audio);
            mock.Setup(m => m.ObtenerAudios()).Returns(audios);
            logicaAudio = new LogicaAudio(mock.Object);
            var result = logicaAudio.ObtenerAudios();
            mock.VerifyAll();
            Assert.AreEqual(audios, result);
        }




        [TestMethod]
        public void TestObtenerAudiosConLista()
        {

            var unidaddetiempo = (ElDescontracturante.Dominio.Audio.UnidadTiempo)Enum.Parse(typeof(ElDescontracturante.Dominio.Audio.UnidadTiempo), "Minuto");

            audio = new Audio();
            {
                audio.Nombre = "Soltero Hasta la Tumba";
                audio.Duracion = 4;
                audio.UnidadDeTiempo = unidaddetiempo;
                audio.NombreCreador = "El Reja";
                audio.UrlImagen = "ElRejaSolteroHastaLaTumba.jpg";
                audio.UrlMp3 = "ElRejaSolteroHastaLaTumba.mp3";
            };

            string[] audiosLista = new string[] { "jeje" };
            Mock<IAudioRepositorio> mock = new Mock<IAudioRepositorio>();
            List<Audio> audios = new List<Audio>();
            audios.Add(audio);
            mock.Setup(m => m.ObtenerAudios()).Returns(audios);
            logicaAudio = new LogicaAudio(mock.Object);
            var result = logicaAudio.ObtenerAudios();
            var result2 = logicaAudio.ObtenerAudios(audiosLista);
            mock.VerifyAll();
            Assert.AreEqual(audios, result);
        }






    }

}
