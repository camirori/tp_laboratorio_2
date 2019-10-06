using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks: Producto
    {
        #region Constructores
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="marca">Marca del producto</param>
        /// <param name="codigo">Codigo de barras</param>
        /// <param name="color">Color primario del empaque</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Producto
        /// </summary>
        /// <returns>String con datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder("");

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
