using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
        public DniInvalidoException(Exception e) : this("El DNI ingresado es invalido", e)
        {

        }
        public DniInvalidoException(string message) : base(message)
        {

        }
        public DniInvalidoException() : this("El DNI ingresado es invalido")
        {

        }
    }
}
