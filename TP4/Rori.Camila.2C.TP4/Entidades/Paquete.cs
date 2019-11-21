using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete: IMostrar<Paquete>
    {
        public enum EEstado { Ingresado, EnViaje, Entregado}
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }


        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        #endregion

        #region Metodos
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        public void MockCicloDeVida()
        {
            this.estado = EEstado.Ingresado;
            do
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado(this, new EventArgs());
            } while(this.estado != EEstado.Entregado);
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }
        public override string ToString()
        {
            /*La sobrecarga del método ToString retornará la información del paquete.
             * ToString se usa solo en los ListBox asique no muestro Estado sino que uso el mismo formato que en MostrarDatos que es lo que se muestra en los listBox*/

            return this.MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


        #endregion



    }
}
