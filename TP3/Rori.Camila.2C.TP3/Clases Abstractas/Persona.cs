using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Campos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        
        #endregion

        #region Propiedades
        /// <summary>
        /// Nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        /// <summary>
        /// DNI, lo valida antes de ingresar
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }
        /// <summary>
        /// Nombre de la persona. Lo valida antes de ingresar.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    this.nombre = value;
            }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    this.apellido = value;
            }
        }
        /// <summary>
        /// DNI, lo valida antes de ingresar
        /// </summary>
        public string StringToDNI                  
        {
            set { this.dni = ValidarDni(this.nacionalidad,value); }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;            
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Retornará los datos de la Persona
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder("");
            mensaje.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido,this.Nombre);
            mensaje.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            //mensaje.AppendFormat("DNI: {0}\n", this.DNI);     > no incluyo DNI porque el archivo de ejemplo no lo incluye en profesor ni alumno, y reutilizo código
            return mensaje.ToString();
        }
        /// <summary>
        /// Valida que el DNI sea correcto según la nacionalidad y el tamaño
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>DNI validado</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato) 
        {
            if(nacionalidad==ENacionalidad.Argentino && dato> 89999999)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
            if (nacionalidad == ENacionalidad.Extranjero && dato < 90000000)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
            if (dato<1 || dato > 99999999)
            {
                throw new DniInvalidoException("Error de formato: más caracteres de los permitidos");   //error de formato
            }
            return dato;
            
        }
        /// <summary>
        /// Valida que el DNI solo contenga números y sea correcto según la nacionalidad y el tamaño
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>DNI validado</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato) 
        {
            int datoParse;        
            if (!Int32.TryParse(dato, out datoParse))
                throw new DniInvalidoException("Error de formato: contiene caracteres que no son dígitos");    
            return ValidarDni(nacionalidad,datoParse);                            
        }
        /// <summary>
        /// Valida que los nombres solo contengan caracteres validos
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Nombre validado</returns>
        private static string ValidarNombreApellido(string dato)
        {
            foreach(char letra in dato)
            {
                if (!(char.IsLetter(letra) || char.IsWhiteSpace(letra)))
                    return null;
            }
            return dato;
        }

        #endregion

        public enum ENacionalidad { Argentino, Extranjero }

    }
}
