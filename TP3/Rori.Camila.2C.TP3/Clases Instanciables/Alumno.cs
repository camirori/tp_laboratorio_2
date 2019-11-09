using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using EClases = Clases_Instanciables.Universidad.EClases;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna los datos del alumno
        /// </summary>
        /// <returns>String</returns>
        protected override string MostrarDatos()
        {
            StringBuilder mensaje = new StringBuilder(base.MostrarDatos());
            mensaje.Append("\nESTADO DE CUENTA: ");
            mensaje.Append((this.estadoCuenta == EEstadoCuenta.AlDia) ? "Cuota al día" : this.estadoCuenta.ToString());
            mensaje.AppendLine(this.ParticiparEnClase());
            mensaje.AppendLine();
            return mensaje.ToString();
        }
        /// <summary>
        /// Retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma
        /// </summary>
        /// <returns>String</returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("\nTOMA CLASE DE {0}", this.claseQueToma);
        }

        /// <summary>
        /// Retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return a.claseQueToma != clase;         //no reutilizo código porque si lo hiciera, si toma la clase y su estado de deuda es Deudor, a y clase son distintos, la consigna solo pide analizar si toma la clase
        }

        public enum EEstadoCuenta { AlDia, Deudor, Becado}
        
    }
}
