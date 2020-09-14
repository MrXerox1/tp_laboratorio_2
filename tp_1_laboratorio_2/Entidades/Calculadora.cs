using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            switch (ValidaSigno(operador))
            {
                case "-":
                    return numeroUno - numeroDos;
                case "*":
                    return numeroUno * numeroDos;
                case "/":
                    return numeroUno / numeroDos;
                default:
                    return numeroUno + numeroDos;
            }
        }

        private static string ValidaSigno(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            return "+";
        }
    }
}
