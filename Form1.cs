using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase_3_Daniel_Vinsaco
{
    public partial class Form1 : Form
    {
        private const string STRCLAVE = "unad";
        private ErrorProvider error;

        
        public Form1()
        {
            InitializeComponent();
            error= new ErrorProvider();

            // inhabilita los botones clave e ingresar . 
            txtClave.Enabled = false;
            bntIngresar.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void itemMenuAcercaDe_Click(object sender, EventArgs e)
        {
            
        }

        private void bntIngresar_Click(object sender, EventArgs e)
        {
            string strClave = "";
            strClave = this.txtClave.Text.Trim();
            if (strClave.Equals(""))

            {
                this.error.SetError(this.txtClave, "Debe agregar una clave ");
                this.txtClave.Focus();


            }
            else
            {
                if (!strClave.Equals(STRCLAVE))
                {
                    this.error.SetError(this.txtClave, "la clave ingresada no es válida! ");
                    this.txtClave.Focus();

                }
                else
                {
                    this.error.SetError(this.txtClave, null);
                    frmIngresoDatosUsuario ingresoDatosUsuario = new frmIngresoDatosUsuario();
                    ingresoDatosUsuario.Show(); 


                    this.Hide(); // oculta el formulario actual

                }
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fase_3_Daniel_Vinasco\n Daniel Vinasco Isaza\n Estudiante de Ingeniería de Sistemas. ");
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtClave.Enabled = true;
            bntIngresar.Enabled = true;
            txtClave.Focus();
        }
    }
}
