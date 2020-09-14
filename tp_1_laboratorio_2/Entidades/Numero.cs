using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Validar
        /// <summary>
        /// metodo que comprobará que el valor recibido sea numérico, y lo retornará en
        /// formato double en Caso contrario, retornará 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            return 0;
        }
        /// <summary>
        /// Propiedad que asignará un valor al atributo número, previa validación.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor base que asignará valor 0 al atributo numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que recibe un double que asignará valor al atributo numero.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) : this()
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que recibe un string que asignará valor al atributo numero luego de validarlo.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero) : this()
        {
            this.SetNumero=strNumero;
        }
        #endregion

        #region Conversores
        /// <summary>
        /// Metodo que Convierte un número decimal a binario, recibiendo un double en caso de ser posible en Caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            long resto;
            StringBuilder sb = new StringBuilder();
            StringBuilder binario = new StringBuilder();
            while (numero >= 1)
            {
                resto = (long)numero % 2;
                numero /= 2;
                sb.Append(resto);
            }
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                binario.Append(sb[i]);
            }
            return binario.ToString();
        }
        /// <summary>
        /// Metodo que Convierte un número decimal a binario, recibiendo un String en caso de ser posible en Caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double aux))
            {
                return DecimalBinario(aux);
            }
            return "Valor inválido";
        }
        /// <summary>
        /// Metodo que validará que la cadena de caracteres esté compuesta
        /// SOLAMENTE por caracteres '0' o '1'.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(String binario)
        {
            bool flag = false;
            if (Regex.IsMatch(binario, "^[01]+$"))
            {
                flag = true;
            }
            return flag;
        }

        public static string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                return Convert.ToInt32(binario, 2).ToString();
            }
            return "Valor inválido";

        }


        #endregion

        #region Operadores
        /// <summary>
        /// Operador que realizarán las sumas entre dos objetos tipo Numero.
        /// </summary>
        /// <param name="NumUno"></param>
        /// <param name="NumDos"></param>
        /// <returns></returns>
        public static double operator +(Numero NumUno, Numero NumDos)
        {
            return NumUno.numero + NumDos.numero;
        }
        /// <summary>
        /// Operador que realizarán las resta entre dos objetos tipo Numero.
        /// </summary>
        /// <param name="NumUno"></param>
        /// <param name="NumDos"></param>
        /// <returns></returns>
        public static double operator -(Numero NumUno, Numero NumDos)
        {
            return NumUno.numero - NumDos.numero;
        }
        /// <summary>
        /// Operador que realizarán las multiplicacion entre dos objetos tipo Numero.
        /// </summary>
        /// <param name="NumUno"></param>
        /// <param name="NumDos"></param>
        /// <returns></returns>
        public static double operator *(Numero NumUno, Numero NumDos)
        {
            return NumUno.numero * NumDos.numero;
        }
        /// <summary>
        //Operador que realizarán las division entre dos objetos tipo Numero en caso de ser por 0 retornará el valor double.MinValue.
        /// </summary>
        /// <param name="NumUno"></param>
        /// <param name="NumDos"></param>
        /// <returns></returns>
        public static double operator /(Numero NumUno, Numero NumDos)
        {
            if (NumDos.numero != 0)
            {
                return NumUno.numero / NumDos.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
        #endregion

    }
}
