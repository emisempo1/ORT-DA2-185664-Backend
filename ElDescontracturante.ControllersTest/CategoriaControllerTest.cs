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
    public class CategoriasControllerTest
    {
        Mock<ILogicaPlaylist> mockPlaylist;
        Mock<ILogicaAudio> mockAudio;

        Mock<ILogicaCategoria> mockCategoria;

        PlayListsController controllerPlaylist;
        CategoriasController controllerCategoria;


        [TestInitialize]
        public void Setup()
        {
            mockPlaylist = new Mock<ILogicaPlaylist>();
            mockAudio = new Mock<ILogicaAudio>();
            mockCategoria = new Mock<ILogicaCategoria>();

            controllerPlaylist = new PlayListsController(mockPlaylist.Object, mockAudio.Object);
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);
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
        public void TestAagregarPlaylistInexistenteAACategoria()
        {
            mockPlaylist.Setup(m => m.ObtenerPlaylist(It.IsAny<string[]>())).Throws(new Excepciones.ExcepcionPlaylistInexistente("playlistInexistente"));
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);

            CategoriaModel categoriaModel = new CategoriaModel()
            {
                NombreCategoria = "Dormir",
                ListaPlaylist = new string[] { "Cachengue" }
            };
            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(categoriaModel);
            var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode;
            Assert.AreEqual(404, repuestaAAPIController);
        }



        public void TestAagregarPlaylistInexistenteNull()
        {
            
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);

            CategoriaModel categoriaModel = new CategoriaModel()
            {
                NombreCategoria = "Dormir",
                ListaPlaylist = new string[] { "Cachengue" }
            };
            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(null);
            var repuestaAAPIController = ((BadRequestObjectResult)result).StatusCode;
            Assert.AreEqual(400, repuestaAAPIController);
        }

        public void TestAagregarCategoriaInexistente()
        {
            mockCategoria.Setup(m => m.AgregarPlaylistsACategoria(It.IsAny<Categoria>())).Throws(new Excepciones.ExcepcionNombreCategoriaIncorrecta());
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);

            CategoriaModel categoriaModel = new CategoriaModel()
            {
                NombreCategoria = "Dormir",
                ListaPlaylist = new string[] { "Cachengue" }
            };
            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(categoriaModel);
            var repuestaAAPIController = ((ConflictObjectResult)result).StatusCode;
            Assert.AreEqual(409, repuestaAAPIController);
        }


        

        [TestMethod]
        public void TestAagregarPlaylistALaMismaCategoriaDosveces()
        {
            mockPlaylist.Setup(m => m.ObtenerPlaylist(It.IsAny<string[]>())).Throws(new Excepciones.ExcepcionPlaylistYaAsociadaACategoria("categoria","playlistInexistente"));
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);

            CategoriaModel categoriaModel = new CategoriaModel()
            {
                NombreCategoria = "Dormir",
                ListaPlaylist = new string[] { "Cachengue" }
            };
            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(categoriaModel);
            var repuestaAAPIController = ((ConflictObjectResult)result).StatusCode;
            Assert.AreEqual(409, repuestaAAPIController);
        }


        [TestMethod]
        public void TestAagregarPlaylistBdCaida()
        {
            mockPlaylist.Setup(m => m.ObtenerPlaylist(It.IsAny<string[]>())).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);

            CategoriaModel categoriaModel = new CategoriaModel()
            {
                NombreCategoria = "Dormir",
                ListaPlaylist = new string[] { "Cachengue" }
            };
            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(categoriaModel);
            var repuestaAAPIController = ((ObjectResult)result).StatusCode;
            Assert.AreEqual(500, repuestaAAPIController);
        }

        [TestMethod]
        public void TestAagregarPlaylistACategoriaNull()
        {
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);
            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(null);
            var repuestaAAPIController = ((BadRequestObjectResult)result).StatusCode;
            Assert.AreEqual(400, repuestaAAPIController);
        }

        [TestMethod]
        public void TestAagregarPlaylistListaPlaylistNull()
        {
       
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);

            CategoriaModel categoriaModel = new CategoriaModel()
            {
                NombreCategoria = "Dormir",
                ListaPlaylist = null
            };
            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(categoriaModel);
            var repuestaAAPIController = ((BadRequestObjectResult)result).StatusCode;
            Assert.AreEqual(400, repuestaAAPIController);
        }


        [TestMethod]
        public void TestAagregarPlaylistACategoriaincorrecta()
        {
            mockCategoria.Setup(m => m.AgregarPlaylistsACategoria(It.IsAny<Categoria>())).Throws(new Excepciones.ExcepcionNombreCategoriaIncorrecta());
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);

            CategoriaModel categoriaModel = new CategoriaModel()
            {
                NombreCategoria = "Dormir",
                ListaPlaylist = new string[] { "Cachengue" }
            };
            ActionResult result = controllerCategoria.AgregarPlaylistsACategoria(categoriaModel);
            var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode;
            Assert.AreEqual(404, repuestaAAPIController);
        }

      

        [TestMethod]
        public void TestObtenerCategoria()
        {     
            ActionResult result = controllerCategoria.ObtenerCategoria("Dormir");
            var repuestaAAPIController = ((OkObjectResult)result).StatusCode;
            Assert.AreEqual(200, repuestaAAPIController);
        }


        [TestMethod]
        public void TestObtenerCategoriaNombreIncorrecto()
        {
            mockCategoria.Setup(m => m.ObtenerCategoria(It.IsAny<string>())).Throws(new Excepciones.ExcepcionNombreCategoriaIncorrecta());
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);
            ActionResult result = controllerCategoria.ObtenerCategoria("Dormir");
            var repuestaAAPIController = ((NotFoundObjectResult)result).StatusCode; 
            Assert.AreEqual(404, repuestaAAPIController);
        }

        [TestMethod]
        public void TestObtenerCategoriaMotorBaseDeDatosCaido()
        {
            mockCategoria.Setup(m => m.ObtenerCategoria(It.IsAny<string>())).Throws(new Excepciones.ExcepcionMotorBaseDeDatosCaido());
            controllerCategoria = new CategoriasController(mockPlaylist.Object, mockCategoria.Object);
            ActionResult result = controllerCategoria.ObtenerCategoria("Dormir");
            var repuestaAAPIController = ((ObjectResult)result).StatusCode; 
            Assert.AreEqual(500, repuestaAAPIController);
        }









    }

}