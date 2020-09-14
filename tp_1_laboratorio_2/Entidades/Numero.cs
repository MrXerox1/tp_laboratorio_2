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
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            return 0;
        }

        private void SetNumero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }
        #endregion

        #region Constructor

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero) : this()
        {
            this.numero = numero;
        }

        public Numero(string strNumero) : this()
        {
            SetNumero(strNumero);
        }
        #endregion

        #region Conversores
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
        
        public static string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double aux))
            {
                return DecimalBinario(aux);
            }
            return "Valor inválido";
        }

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
        public static double operator +(Numero NumUno, Numero NumDos)
        {
            return NumUno.numero + NumDos.numero;
        }
        public static double operator -(Numero NumUno, Numero NumDos)
        {
            return NumUno.numero - NumDos.numero;
        }
        public static double operator *(Numero NumUno, Numero NumDos)
        {
            return NumUno.numero * NumDos.numero;
        }
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
