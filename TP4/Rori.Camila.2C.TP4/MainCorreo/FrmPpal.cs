using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            mtxtTrackingID.TextMaskFormat = MaskFormat.IncludeLiterals;
            
        }

        /// <summary>
        /// Agrega un paquete al correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {

                MessageBox.Show(ex.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            ActualizarEstados();
        }

        /// <summary>
        /// Actualiza la información de los paquetes mostrada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Actualiza los estados de los paquetes
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            lstEstadoIngresado.Items.Clear();
            foreach (Paquete paquete in correo.Paquetes)
            {
                switch(paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        /// <summary>
        /// Mustra los datos del listado de paquetes y los guarda en un archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Mustra los datos de un paquete y lo guarda en un archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// Mustra los datos de un paquete o listado de paquetes y lo guarda en un archivo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string datos = "";
            if (elemento != null)
            {
                if(elemento.GetType()== typeof(Paquete))
                    datos = ((Paquete)elemento).MostrarDatos((IMostrar<Paquete>)elemento);
                else if(elemento.GetType() == typeof(Correo))
                    datos = correo.MostrarDatos((IMostrar<List<Paquete>>)elemento);

                rtbMostrar.Text = datos;
                try
                {
                    datos.Guardar("salida.txt");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message,"Error al guardar",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
        }


        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

    }
}

