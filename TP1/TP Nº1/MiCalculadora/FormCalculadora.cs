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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        bool baseActualDecimal = true;  //indica si el resultado se encuentra en decimal o binario
        
        /// <summary>
        /// Borra todos los valores que se muestran en la calculadora
        /// </summary>
        private void Limpiar()
        {
            txtNum1.Text = "";
            txtNum2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Borra todos los valores que se muestran en la calculadora al clickear el botón Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza una operación matemática entre dos operandos
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador</param>
        /// <returns>Devulve el resultado de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Realiza una operación matemática entre dos operandos e imprime el resultado en una etiqueta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = FormCalculadora.Operar(txtNum1.Text, txtNum2.Text, cmbOperador.Text).ToString();
            baseActualDecimal = true;
        }

        /// <summary>
        /// Cierra el formulario al clickear el botón "Cerrar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte el contenido de la etiqueta Resultado a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                if (baseActualDecimal)
                {
                    if(Convert.ToDouble(lblResultado.Text)>Int64.MaxValue) 
                        MessageBox.Show("El numero es demasiado grande para convertir a binario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                        baseActualDecimal = false;
                    }
                }
                else
                    MessageBox.Show("El resultado ya se encuentra expresado en binario", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
                
        }

        /// <summary>
        /// Convierte el contenido de la etiqueta Resultado a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                if (!baseActualDecimal)
                {
                    lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                    baseActualDecimal = true;
                }
                else
                    MessageBox.Show("El resultado ya se encuentra expresado en decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inicializa los elementos del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
            lblResultado.Text = "";
        }
    }
}
