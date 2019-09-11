using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double _numero;

        public double SetNumero { set => _numero = value; }
        /*El método SetNumero asignará un valor al atributo número, previa validación. En
        este lugar será el único en todo el código que llame al método ValidarNumero.*/

        #region Constructores
        public Numero()
        {
            this._numero = 0;
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(string strNumero)     //usar : this(ValidarNumero(strNumero))?
        {
            this._numero = ValidarNumero(strNumero);
        }
        #endregion

        private double ValidarNumero(string strNumero)
        {
            double retorno;
            if (Double.TryParse(strNumero, out retorno))
                return retorno;
            else
                return 0;
        }

        public string BinarioDecimal(string binario)
        {

        }
        public string DecimalBinario(string numero)
        {

        }
        public string DecimalBinario(double binario)
        {

        }

        #region Sobrecarga operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2._numero == 0)
                return Double.MinValue;
            else
                return n1._numero / n2._numero;
        }

        #endregion
    }
}
