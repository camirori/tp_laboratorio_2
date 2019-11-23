using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using EClases = Clases_Instanciables.Universidad.EClases;

namespace Clases_Instanciables
{
    public sealed class Profesor: Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        #region Metodos
        /// <summary>
        /// Constructor
        /// </summary>
        public Profesor()
        {
            
        }
        /// <summary>
        /// Constructor estático
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Asigna clases al azar
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)random.Next(0, 4));
            this.clasesDelDia.Enqueue((EClases)random.Next(0, 4));
        }

        /// <summary>
        /// Retorna los datos del profesor
        /// </summary>
        /// <returns>String</returns>
        protected override string MostrarDatos()
        {
            StringBuilder mensaje = new StringBuilder(base.MostrarDatos());
            mensaje.Append(this.ParticiparEnClase());
            return mensaje.ToString();
        }
        /// <summary>
        /// Retorna los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns>String</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder mensaje = new StringBuilder("");
            mensaje.AppendLine("\nCLASES DEL DIA:");
            foreach (EClases clase in this.clasesDelDia)
                mensaje.AppendLine(clase.ToString());
            return mensaje.ToString();
        }
        #endregion


        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i==clase);
        }
    }
}
