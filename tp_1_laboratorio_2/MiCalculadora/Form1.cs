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

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.SelectedIndex = 0;
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro que quiere cerrar la calculadora?", "Cerrar calculadora", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        #region Botones
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "";
        }

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

        #region Textos

        private void txtNumero1_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNumero1.Text, out double auxCotizacion))
            {
                txtNumero1.Focus();
            }
        }

        private void txtNumero2_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNumero2.Text, out double auxCotizacion))
            {
                txtNumero2.Focus();
            }
        }
        #endregion

        public static double Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero aux1 = new Numero(numeroUno);
            Numero aux2 = new Numero(numeroDos);
            return Calculadora.Operar(aux1, aux2, operador);
        }
    }
}
