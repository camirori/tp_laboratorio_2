using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Constructores
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigo">Codigo de barras</param>
        /// <param name="color">Color primario del empaque</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias           //+override
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Producto
        /// </summary>
        /// <returns>String con datos del producto</returns>
        public override sealed string Mostrar()                         //private > public
        {
            StringBuilder sb = new StringBuilder("");

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
