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
    public class LogicaPlaylistTest
    {
        Playlist playlist;
        LogicaPlayList logicaPlaylist;
        Mock<IPlaylistRepositorio> mock;
        Mock<IAudioRepositorio> mockAudio;
        List<Playlist> playlists;


        [TestInitialize]
        public void initialize()
        {
            playlist = new Playlist();
            playlist.Nombre = "Cachengue";
            playlist.Descripcion = "Para Escabiar y pasarla bien con tus panas";
            playlist.Url = "ElRejaSolteroHastaLaTumba.jpg";

            playlists = new List<Playlist>();
            playlists.Add(playlist);

            mock = new Mock<IPlaylistRepositorio>();
            mock.Setup(m => m.ObtenerPlaylist("Cachuengue")).Returns(playlists[0]);
            mockAudio = new Mock<IAudioRepositorio>();
            logicaPlaylist = new LogicaPlayList(mock.Object,mockAudio.Object);

          

        }


        [TestMethod]
        public void TestAñadirPlaylist()
        {
            logicaPlaylist.Agregar(playlist);
            var result = logicaPlaylist.ObtenerPlaylist("Cachuengue");
            mock.VerifyAll();
            Assert.AreEqual(playlist, result);
        }


        [TestMethod]
        public void TestObtenerPlaylist()
        {
            var result = logicaPlaylist.ObtenerPlaylist("Cachuengue");
            mock.VerifyAll();
            Assert.AreEqual(playlists, result);
        }



     

    }




    }

