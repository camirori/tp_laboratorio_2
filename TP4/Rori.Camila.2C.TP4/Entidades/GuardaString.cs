using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guardará en un archivo de texto en el escritorio de la máquina el contenido del objecto
        /// </summary>
        /// <param name="texto">Objeto que se guardara</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto , string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                using (StreamWriter sw = new StreamWriter(path+"\\"+archivo,true))  
                { 
                    sw.WriteLine(texto); 
                }
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
