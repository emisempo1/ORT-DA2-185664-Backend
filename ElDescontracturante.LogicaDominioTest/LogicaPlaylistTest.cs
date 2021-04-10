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
            mock.Setup(m => m.ObtenerPlaylist()).Returns(playlists);
            logicaPlaylist = new LogicaPlayList(mock.Object);

        }




        [TestMethod]
        public void TestAñadirPlaylist()
        {
            logicaPlaylist.Agregar(playlist);
            var result = logicaPlaylist.Obtenerplaylists();
            mock.VerifyAll();
            Assert.AreEqual(playlist, result[0]);

        }



        [TestMethod]
        public void TestObtenerPlaylist()
        {

            var result = logicaPlaylist.Obtenerplaylists();
            mock.VerifyAll();
            Assert.AreEqual(playlists, result);
        }


    }




    }
}
