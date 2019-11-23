using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario: Persona
    {
        private int legajo;

        public Universitario()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Resultado de la comparación</returns>
        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType() && (this.legajo == ((Universitario)obj).legajo || this.DNI == ((Universitario)obj).DNI))
                return true;
            return false;
        }
        /// <summary>
        /// Retornará todos los datos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder mensaje = new StringBuilder(base.ToString());
            mensaje.AppendFormat("\nLEGAJO NÚMERO: {0}\n", this.legajo);             //en el archivo de texto de ejemplo en la primer jornada dice "CARNET" pero en el resto dice "LEGAJO", no especifica cuál es el correcto asique dejo todo como "LEGAJO"
            return mensaje.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

    }
}
