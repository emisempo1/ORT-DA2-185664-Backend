using ElDescontracturante.AccesoADatos.Repositorios;
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.LogicaDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ElDescontracturante.LogicaDominioTest
{
    [TestClass]
    public class LogicaAudioTest
    {
        Audio unAudio;
        LogicaAudio logicaAudio;
  


        [TestInitialize]
        public void initialize()
        {
            unAudio = new Audio();

            Mock<IAudioRepositorio> mock = new Mock<IAudioRepositorio>();

            List<Audio> puntos = new List<Audio>();
            unAudio.Nombre = "Soltero Hasta la Tumba";
            puntos.Add(unAudio);

            logicaAudio = new LogicaAudio(mock.Object);

        }


        [TestMethod]
        public void TestAñadirAudio()
        {
            unAudio.Nombre = "MELO";
            logicaAudio.Agregar(unAudio);
        }

        

    }

}
