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
        /// <summary>
        /// Constructor base del Form
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento que carga datos antes de la apertura del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.SelectedIndex = 0;
        }
        /// <summary>
        /// Evento que verfica con un mensaje si realmente quiere cerrar el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro que quiere cerrar la calculadora?", "Cerrar calculadora", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        #region Botones
        /// <summary>
        /// Evento que recibirá los dos números y el operador para luego llamar al método Operar que
        /// retornara el resultado en el evento del botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }
        /// <summary>
        /// Evento que activara el evento de cerrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento que llama al metodo Limpiar para vaciar los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Metodo encargado de vaciar los campos
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "";
        }
        /// <summary>
        /// Evento que convertirá el resultado, de existir, a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                if (double.TryParse(lblResultado.Text, out double aux))
                {
                    lblResultado.Text = Numero.DecimalBinario(aux);
                    btnConvertirADecimal.Enabled = true;
                    btnConvertirABinario.Enabled = false;
                }


            }
        }
        /// <summary>
        /// Evento que convertirá el resultado, de existir, a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text).ToString();
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;

            }
        }
        #endregion
        /// <summary>
        /// recibirá los dos números y el operador para luego
        /// llamar al método Operar de Calculadora y retornar un double
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero aux1 = new Numero(numeroUno);
            Numero aux2 = new Numero(numeroDos);
            return Calculadora.Operar(aux1, aux2, operador);
        }

        #region Textos
        /// <summary>
        /// Evento que se encarga de no poder seleccionar otra cosa si no es un numero valido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero1_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNumero1.Text, out double auxCotizacion))
            {
                txtNumero1.Focus();
            }
        }
        /// <summary>
        /// Evento que se encarga de no poder seleccionar otra cosa si no es un numero valido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero2_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNumero2.Text, out double auxCotizacion))
            {
                txtNumero2.Focus();
            }
        }
        #endregion
    }
}
