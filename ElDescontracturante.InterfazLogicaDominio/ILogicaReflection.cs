﻿using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElDescontracturante.InterfazLogicaDominio
{
    public interface ILogicaReflection
    {
        public Categoria InstanciarObjetosConInterfazConocida(string tipoDeArchivo, string path);
    }
}