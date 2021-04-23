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
    public class LogicaCategoriaTest
    {
        Categoria Categoria;
        LogicaCategoria logicaCategoria;
        Mock<ICategoriaRepositorio> mock;
        List<Categoria> Categorias;
        Playlist playlist;
        List<Playlist> playlists;


        [TestInitialize]
        public void initialize()
        {
            Categoria = new Categoria();
            playlist = new Playlist();
            Categoria.NombreCategoria = (ElDescontracturante.Dominio.Categoria.NomCategoria)Enum.Parse(typeof(ElDescontracturante.Dominio.Categoria.NomCategoria), "Dormir");
            playlist.Nombre = "Cachengue";
            playlist.Descripcion = "Para Escabiar y pasarla bien con tus panas";
            playlist.Url = "ElRejaSolteroHastaLaTumba.jpg";
            playlists = new List<Playlist>();
            playlists.Add(playlist);
            Categoria.ListaPlaylist = playlists;

            Categorias = new List<Categoria>();
            Categorias.Add(Categoria);

            mock = new Mock<ICategoriaRepositorio>();
            mock.Setup(m => m.ObtenerCategoria("Dormir")).Returns(Categoria);
            logicaCategoria = new LogicaCategoria(mock.Object);

        }


        [TestMethod]
        public void TestAñadirPlaylistCategoria()
        {
            logicaCategoria.AgregarPlaylistsACategoria(Categoria);

            var result = logicaCategoria.ObtenerCategoria("Dormir");
            mock.VerifyAll();
            Assert.AreEqual(Categoria, result);
        }


        [TestMethod]
        public void TestObtenerCategoria()
        {
            var result = logicaCategoria.ObtenerCategoria("Dormir");
            mock.VerifyAll();
            Assert.AreEqual(Categorias[0], result);
        }


    }




    }

