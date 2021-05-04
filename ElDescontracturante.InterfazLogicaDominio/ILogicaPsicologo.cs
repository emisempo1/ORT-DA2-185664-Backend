using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
    public interface ILogicaPsicologo
    { 
        public void Agregar(Psicologo Psicologo);

        public void AgregarEspecialidadEnProblematica(string emailPsicologo, Problematica_Psicologo.Problematica[] problematicas);

        public void Borrar(Psicologo psicologo);

        Psicologo Obtener(string email);

        public List<Psicologo> ObtenerPsicologosEspecializado(Problematica_Psicologo.Problematica problematica);

    }
}
