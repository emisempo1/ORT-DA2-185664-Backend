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
    public class AdministradorModel
    {
   

        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }





        public Administrador ToEntity()
        {
            Administrador administrador = new Administrador();
                administrador.Nombre = this.Nombre;
                administrador.Email = this.Email;
                administrador.Password = this.Password;
            return administrador;
        }

        public AdministradorModel()
        {
        }
    }
}
