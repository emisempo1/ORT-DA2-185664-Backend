using ElDescontracturante.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Models
{
    public class ImportacionModel
    {
        public string TipoDeArchivo { get; set; }
        public string Path { get; set; }

        public ImportacionModel()
        {
        }
    }
}
