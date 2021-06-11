using ElDescontracturante.Dominio;
using ElDescontracturante.IImportacion;
using ElDescontracturante.InterfazLogicaDominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace ElDescontracturante.LogicaDominio
{ 
    public class LogicaReflection : ILogicaReflection
    {

        public Categoria InstanciarObjetosConInterfazConocida(string tipoDeArchivo,string path)
        {
            var dllFile = new FileInfo(@".\Reflection\" + "Importar" + tipoDeArchivo + ".dll");
            Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);
            IEnumerable<Type> implementations = GetTypesInAssembly<InterfazImportacion>(myAssembly);
            InterfazImportacion importacion = (InterfazImportacion)Activator.CreateInstance(implementations.First());
            return importacion.ObtenerPlayListyAudios(path);
        }

        public static List<Type> GetTypesInAssembly<Interface>(Assembly assembly)
        {
            List<Type> types = new List<Type>();
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(Interface).IsAssignableFrom(type))
                    types.Add(type);
            }
            return types;
        }


    }
}
