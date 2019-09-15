using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Asigna el valor recibido al campo numero
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numero">Valor a asignar al número</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor. Valida el valor recibido.
        /// </summary>
        /// <param name="strNumero">Valor a asignar al número</param>
        public Numero(string strNumero)     
        {
            SetNumero = strNumero;
        }
        #endregion

        /// <summary>
        /// Valida que el valor recibido sea un número
        /// </summary>
        /// <param name="strNumero">Valor a validar</param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if (Double.TryParse(strNumero, out retorno))
                return retorno;
            else
                return 0;
        }

        #region Conversion Binario-Decimal
        /// <summary>
        /// Valida y convierte el número binario recibido a decimal. 
        /// </summary>
        /// <param name="binario">Número binario a convertir</param>
        /// <returns>Resultado de la conversión si tiene éxito, sino mensaje de error</returns>
        public static string BinarioDecimal(string binario)
        {
            string caracteresPermitidos = "01";
            foreach (char caracter in binario)
            {
                if (!caracteresPermitidos.Contains(caracter))
                    return "Valor inválido";
            }
            
            return Convert.ToUInt32(binario, 2).ToString();
        }
        /// <summary>
        /// Valida y convierte el número decimal entero positivo recibido a binario. 
        /// </summary>
        /// <param name="numero">Número decimal entero positivo a convertir</param>
        /// <returns>Resultado de la conversión si tiene éxito, sino mensaje de error</returns>
        public static string DecimalBinario(string numero)
        {
            double numeroDecimal;
            if (Double.TryParse(numero, out numeroDecimal))
                return DecimalBinario(numeroDecimal);
            else
                return "Valor inválido";
        }
        /// <summary>
        /// Convierte el número decimal entero positivo recibido a binario. 
        /// </summary>
        /// <param name="numero">Número decimal entero positivo a convertir</param>
        /// <returns>Resultado de la conversión</returns>
        public static string DecimalBinario(double numero)
        {
            long sinSigno = Convert.ToInt64(Math.Abs(numero));
            return Convert.ToString(sinSigno, 2);
        }
        #endregion


        #region Sobrecarga operadores
        /// <summary>
        /// Realiza la operación de suma entre dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>Resultado de la operación</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Realiza la operación de resta entre dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>Resultado de la operación</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Realiza la operación de multiplicación entre dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>Resultado de la operación</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Realiza la operación de división entre dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>Resultado de la operación</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return Double.MinValue;
            else
                return n1.numero / n2.numero;
        }

        #endregion
    }
}
