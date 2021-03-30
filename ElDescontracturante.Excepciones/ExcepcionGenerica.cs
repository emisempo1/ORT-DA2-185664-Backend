using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ExcepcionGenerica : Exception
    {
        public ExcepcionGenerica(string message) : base(message) { }
    }
}