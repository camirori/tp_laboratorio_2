using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador recibido sea del tipo +,-,* o /
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Si el operador ingresado es válido devuelve el mismo, sino devuelve +</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return operador;
            else
                return "+";
        }

        /// <summary>
        /// Realiza las operaciones de suma, resta, multiplicación y división entre dos operandos
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Indica la operación a realizar</param>
        /// <returns>Resultado de la operación</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            switch (ValidarOperador(operador))
            {
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                case "+":
                default:
                    return num1 + num2;
            }
        }
    }
}
