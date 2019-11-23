using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EClases = Clases_Instanciables.Universidad.EClases;
using Archivos;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Constructor
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor): this()
        {
            this.clase = clase;
            this.instructor = instructor;
            
        }
        /// <summary>
        /// Guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True: Guardado exitosamente, False: Error</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivador = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";
            return archivador.Guardar(path, jornada.ToString());
        }
        /// <summary>
        /// Leerá desde un archivo y retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto archivo = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";
            string retorno;
            archivo.Leer(path, out retorno);
            return retorno;
        }
        /// <summary>
        /// Mostrará todos los datos de la Jornada
        /// </summary>
        /// <returns>Datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder("");
            mensaje.AppendFormat("CLASE DE {0} POR ", clase);
            mensaje.Append(instructor.ToString());
            mensaje.AppendLine("\nALUMNOS:");
            foreach (Alumno alumno in this.alumnos)
                mensaje.Append(alumno.ToString());
            mensaje.AppendLine("<------------------------------------------------>\n");

            return mensaje.ToString();
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Universitario alumno in j.alumnos)
            {
                if (alumno.Equals(a))                
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Una Jornada será distinto a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega Alumnos a la clase, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }

        #endregion


    }
}
