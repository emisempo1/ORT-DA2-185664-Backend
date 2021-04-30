using ElDescontracturante.AccesoADatos.Repositorios;
using ElDescontracturante.Dominio;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.LogicaDominio
{
    public class LogicaPsicologo : ILogicaPsicologo
    {
        private readonly IPsicologoRepositorio psicologoRepositorio;


        public LogicaPsicologo(IPsicologoRepositorio psicologoRepositorio)
        {
            this.psicologoRepositorio = psicologoRepositorio;
        }

        public void Agregar(Psicologo Psicologo)
        {
            psicologoRepositorio.Agregar(Psicologo);
        }

        public void AgregarEspecialidadEnProblematica(string emailPsicologo, Problematica_Psicologo.Problematica[] problematicas)
        {

            Obtener(emailPsicologo);

            

            for (int i = 0; i < problematicas.Length; i++)
            {
                Problematica_Psicologo unaProbelamaticaPsicologo = new Problematica_Psicologo();
                unaProbelamaticaPsicologo.Email = emailPsicologo;
                unaProbelamaticaPsicologo.NombreProblematica = problematicas[i];
                psicologoRepositorio.AgregarProblematica(unaProbelamaticaPsicologo);
            }

            
        }

        public Psicologo Obtener(string email)
        {
            List<Psicologo> listaPsicologoes = psicologoRepositorio.Obtener();

                for (int i = 0; i < listaPsicologoes.Count; i++)
                {
                    if (listaPsicologoes[i].Email == email) 
                    {
                        return listaPsicologoes[i];
                    }
                }

            throw new Excepciones.ExcepcionPsicologoInexistente(email);
        }

        public List<Psicologo> ObtenerPsicologosEspecializado(Problematica_Psicologo.Problematica problematica)
        {
            List<Problematica_Psicologo> listaPsicologoes = psicologoRepositorio.ObtenerProblematica();

            List<Psicologo> listaPsicologosEspecializados = new List<Psicologo>();


            for (int i = 0; i < listaPsicologoes.Count; i++)
            {
                if (listaPsicologoes[i].NombreProblematica == problematica)
                {
                    Psicologo psicologo = this.Obtener(listaPsicologoes[i].Email);
                    listaPsicologosEspecializados.Add(psicologo);
                }
            }

            if (listaPsicologosEspecializados.Count > 0)
            {
                return listaPsicologosEspecializados;
            }
           

            throw new Excepciones.ExcepcionPsicologosInexistentes();
        }





    };
}