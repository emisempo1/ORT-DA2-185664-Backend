using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazAccesoADatos
{
    public interface IPsicologoRepositorio
    {
        void Agregar(Psicologo unPsicologo);

        List<Psicologo> Obtener();

        void AgregarProblematica(Problematica_Psicologo unaProblematica);

        List<Problematica_Psicologo> ObtenerProblematica();





    }
}
