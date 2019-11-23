using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos recibidos en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true)) 
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee el contenido de un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = "";
            string linea = "";
            try
            {
                if (!File.Exists(archivo))
                    throw new FileNotFoundException("Archivo no encontrado:"+archivo);
                using (StreamReader str = new StreamReader(archivo))
                {
                    while ((linea = str.ReadLine()) != null)     
                    {
                        datos += (linea + "\n");
                    }
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
