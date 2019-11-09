using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;       //lista de inscriptos
        private List<Profesor> profesores;  //lista de quienes pueden dar clases
        private List<Jornada> jornada;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]  
        {
            get { return this.jornada[i]; } 
            set { this. jornada[i] = value; } 

        }
        #endregion
        #region Metodos
        /// <summary>
        /// Constructor
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
       
        }

        /// <summary>
        /// serializará los datos del Universidad en un XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializador = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            return serializador.Guardar(path, uni);
        }
        /// <summary>
        /// Retornará un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> deserializador = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            Universidad retorno;
            deserializador.Leer(path, out retorno);
            return retorno;
        }
        /// <summary>
        /// Retorna los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder mensaje = new StringBuilder("");
            mensaje.AppendLine("\nJORNADA:");
            foreach (Jornada jornada in uni.jornada)
                mensaje.Append(jornada.ToString());
            
            return mensaje.ToString();
        }
        /// <summary>
        /// Retorna los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion
        #region Operadores
        /// <summary>
        /// Una Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Universitario alumno in g.alumnos)
            {
                if (alumno.Equals(a))            
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Un Universidad será distinto a un Alumno si el mismo no está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Una Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Universitario profesor in g.profesores)
            {
                if (profesor.Equals(i))           
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Una Universidad será disntinta a un Profesor si el mismo no está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>Resultado de la comparación</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// retornará el primer Profesor capaz de dar esa clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach(Profesor profesor in u.profesores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor != clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Agrega un alumno
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException();
            u.alumnos.Add(a);
            return u;
        }
        /// <summary>
        /// Agrega un profesor
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.profesores.Add(i);
            return u;
        }
        /// <summary>
        /// Agrega una clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == clase)                    
                    jornada.Alumnos.Add(alumno);
            }
            g.jornada.Add(jornada);
            return g;

        }
        #endregion


        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
    }
}
