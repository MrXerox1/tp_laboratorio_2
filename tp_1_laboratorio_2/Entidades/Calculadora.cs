using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Metodo que validará y realizará la operación pedida entre ambos números.
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo que valida que el operador recibido sea +, -, / o *
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
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
