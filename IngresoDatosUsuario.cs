using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase_3_Daniel_Vinsaco
{
    public partial class frmIngresoDatosUsuario : Form
    {
        private string strTipoDocumento;
        private string strNroId;
        private string strNombre;
        private string strEdad;
        private string strEstrato;
        private string strValorPago;
        private string strTipoEstructura;
        private int strReporteDatos;
        private string strFechaAcceso;
        private string strTipoAtención;
        private int intReportePila, intReporteCola, intReporteLista;

        Stack<EstructuraDatosUsuario> pilaUsuario = new Stack<EstructuraDatosUsuario>();
        Queue<EstructuraDatosUsuario> colaUsuario = new Queue<EstructuraDatosUsuario>();
        List<EstructuraDatosUsuario> listaUsuario = new List<EstructuraDatosUsuario>();



        public frmIngresoDatosUsuario()
        {
            InitializeComponent();
            cargarElementosIniciales();
            this.intReportePila = 0;
            this.intReporteCola = 0;
            this.intReporteLista = 0;
            this.btnReportePila.Enabled = false;
            this.btnReporteCola.Enabled = false;
            this.btnReporteLista.Enabled = false;
            this.btnEliminarPila.Enabled = false;
            this.btnEliminarCola.Enabled = false;
            this.btnEliminarLista.Enabled = false;


        }

        public void cargarElementosIniciales()
        {
            
          

            this.cbTipoDocumento.Items.Clear();
            this.cbEstrato.Items.Clear();
            this.cbTipoEstructura.Items.Clear();


            this.cbTipoDocumento.Items.Add("CC");
            this.cbTipoDocumento.Items.Add("CE");
            this.cbTipoDocumento.Items.Add("NUIP");
            this.cbTipoDocumento.Items.Add("PAS");


            this.cbEstrato.Items.Add("1");
            this.cbEstrato.Items.Add("2");
            this.cbEstrato.Items.Add("3");
            this.cbEstrato.Items.Add("4");
            this.cbEstrato.Items.Add("5");
            this.cbEstrato.Items.Add("6");


            this.cbTipoEstructura.Items.Add("Pila");
            this.cbTipoEstructura.Items.Add("Lista");
            this.cbTipoEstructura.Items.Add("Cola");

            this.txtNombre.Focus();

        }
        public bool validarFormulario()
        {
            string strMsg = "";// variable para controlar que los campos este llenos y no hallan campos vacios 

            this.strNroId = this.txtNroId.Text.Trim();
            if (this.strNroId.Equals(""))
            {
                strMsg = strMsg += "- Nro de identificación \n ";

            }

            this.strTipoDocumento = this.cbTipoDocumento.Text.Trim();
            if (this.strTipoDocumento.Equals(""))
            {
                strMsg = strMsg + "- Tipo de Identificación  \n ";

            }

            this.strNombre = this.txtNombre.Text.Trim();
            if (this.strNombre.Equals(""))
            {
                strMsg = strMsg + "- Nombre completo \n ";

            }

            this.strEdad = this.txtEdad.Text.Trim();
            if (this.strEdad.Equals(""))
            {
                strMsg = strMsg + "- Edad \n ";

            }

            this.strEstrato = this.cbEstrato.Text.Trim();
            if (this.strEstrato.Equals(""))
            {
                strMsg = strMsg + "- Estrato \n ";

            }

          
            this.strTipoEstructura = this.cbTipoEstructura.Text.Trim();
            if (this.strTipoEstructura.Equals(""))
            {
                strMsg = strMsg + "- Tipo de estructura \n ";

            }

            this.strFechaAcceso = this.dtFechaAcceso.Text.Trim();
            if (this.strFechaAcceso.Equals(""))
            {
                strMsg = strMsg + "- Fecha de acceso \n ";

            }


            if (this.rdGeneral.Checked == false && this.rdLaboratorio.Checked == false)
            {
                strMsg = strMsg + "- Tipo de atención  \n ";
            }
            else
            {
                if (this.rdGeneral.Checked == true)
                {
                    this.strTipoAtención = "General";
                }
                else if (this.rdLaboratorio.Checked == true)
                {
                    this.strTipoAtención = "Laboratorio";
                }
            }


            if (!strMsg.Equals(""))
            {
                strMsg = "DEBE LLENAR LOS SIGUIENTES CAMPOS: \n ***********************\n\n" + strMsg;
                MessageBox.Show(strMsg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;


            }
            else
            {
                this.strValorPago = calcularValorPago().ToString();
                this.strFechaAcceso = this.dtFechaAcceso.Value.ToString();
                this.txtValorPago.Text = this.strValorPago;
                return true;
            }
        }


        private void rdGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGeneral.Checked)
            {
                this.strTipoAtención = "General";
            }
        }

        private void rdLaboratorio_CheckedChanged(object sender, EventArgs e)
        {
            if (rdLaboratorio.Checked)
            {
                this.strTipoAtención = "Laboratorio";
            }
        }

        public int calcularValorPago()
        {
            int intValorPago = 0;
            Console.WriteLine("Tipo de Atención seleccionada: " + this.strTipoAtención); // Solo para depuración

            if (this.strTipoAtención.Equals("General"))
            {
                switch (this.strEstrato)
                {
                    case "1":
                        intValorPago = 0;
                        break;
                    case "2":
                        intValorPago = 0;
                        break;
                    case "3":
                        intValorPago = 10000;
                        break;
                    case "4":
                        intValorPago = 15000;
                        break;
                    case "5":
                        intValorPago = 20000;
                        break;
                    case "6":
                        intValorPago = 30000;
                        break;
                }
            }
            else if (this.strTipoAtención.Equals("Laboratorio"))
            {
                switch (this.strEstrato)
                {
                    case "1":
                        intValorPago = 0;
                        break;
                    case "2":
                        intValorPago = 0;
                        break;
                    case "3":
                        intValorPago = 0;
                        break;
                    case "4":
                        intValorPago = 5000;
                        break;
                    case "5":
                        intValorPago = 10000;
                        break;
                    case "6":
                        intValorPago = 20000;
                        break;
                }
            }
            return intValorPago;
        }




        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void ActualizarDataGridViewPila()
        {
            dgPila.DataSource = null;
            dgPila.DataSource = pilaUsuario.ToArray();

        }

        private void btnEliminarPila_Click(object sender, EventArgs e)
        {
            if (pilaUsuario.Count > 0)
            {
                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show("¿Está seguro que quiere eliminar el último registro de la pila?",
                                                      "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    pilaUsuario.Pop(); // Eliminar el último elemento de la pila
                    ActualizarDataGridViewPila();
                }
            }
            else
            {
                MessageBox.Show("No hay registros en la pila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que quiere salir de la aplicación", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes) 
            {
                Application.Exit();
            }
        }
        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
            {
                EstructuraDatosUsuario miEstructura = new EstructuraDatosUsuario();
                miEstructura.strNroId = this.strNroId;
                miEstructura.strNombre = this.strNombre;
                miEstructura.strTipoDocumento = this.strTipoDocumento;
                miEstructura.fechaAcceso = this.strFechaAcceso;
                miEstructura.intEdad = int.Parse(this.strEdad);
                miEstructura.intValorpago = int.Parse(strValorPago);
                miEstructura.intEstrato = int.Parse(strEstrato);    
                miEstructura.strTipoEstructura= this.strTipoEstructura;
                miEstructura.intReporteDatos = strReporteDatos;
                miEstructura.strTipoAtención = this.strTipoAtención;

                if (this.strTipoEstructura.Equals("Pila"))
                {
                    this.intReportePila = this.intReportePila + int.Parse (this.strValorPago);
                    this.pilaUsuario.Push(miEstructura);
                    dgPila.DataSource = null;
                    dgPila.DataSource = this.pilaUsuario.ToArray();
                    this.tabEstructuras.SelectedIndex = 0;
                    MessageBox.Show("El registro a la Pila fue exitoso!","Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnReportePila.Enabled = true;
                    this.btnEliminarPila.Enabled = true;

                    txtReporteDatos.Text = "Suma de copagos en la pila: $" + CalcularSumaCopagosPila();

                }

                if (this.strTipoEstructura.Equals("Cola"))
                {
                    this.colaUsuario.Enqueue(miEstructura);
                    dgCola.DataSource = null;
                    dgCola.DataSource = this.colaUsuario.ToArray();
                    this.tabEstructuras.SelectedIndex = 1;
                    MessageBox.Show("El registro se agrego correctamente a la cola!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnReporteCola.Enabled = true;
                    this.btnEliminarCola.Enabled = true;

                    txtReporteDatos.Text = "Cantidad de registros en la cola: " + colaUsuario.Count;
                }

                if (this.strTipoEstructura.Equals("Lista"))
                {
                   this.listaUsuario.Add(miEstructura);
                    dgLista.DataSource = null;
                    dgLista.DataSource = this.listaUsuario.ToArray();
                    this.tabEstructuras.SelectedIndex = 2;
                    MessageBox.Show("El registro se agregó de forma correcta a la lista!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnReporteLista.Enabled = true;
                    this.btnEliminarLista.Enabled = true;

                    txtReporteDatos.Text = "Promedio de edades en la lista: " + CalcularPromedioEdadLista().ToString("0.00");

                }

                //cargarElementosIniciales();
            }
        }
        private int CalcularSumaCopagosPila()
        {
            return pilaUsuario.Sum(usuario => usuario.intValorpago);
        }

        // Método para calcular el promedio de las edades en la lista
        private double CalcularPromedioEdadLista()
        {
            if (listaUsuario.Count == 0) return 0;
            return listaUsuario.Average(usuario => usuario.intEdad);
        }
        

        private void txtNroId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Sólo se permiten números en la identificación del usuario", "Validación ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;

            }

        }

        private void btnReportePila_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("$" + this.intReportePila.ToString(), "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtReporteDatos.Text = "Suma de copagos en la pila: $" + CalcularSumaCopagosPila();
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReporteCola_Click(object sender, EventArgs e)
        {
            // LA CANTIDAD DE REGISTROS QUE SE ENCUENTRAN ACTUALMENTE EN EL DATAGRIDIEW DE LA COLA
            txtReporteDatos.Text = "Cantidad de registros en la cola: " + colaUsuario.Count;
        }

        private void btnReporteLista_Click(object sender, EventArgs e)
        {
            txtReporteDatos.Text = "Promedio de edades en la lista: " + CalcularPromedioEdadLista().ToString("0.00");

        }

        private void btnEliminarCola_Click(object sender, EventArgs e)
        {
            if (colaUsuario.Count > 0)
            {
                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show("¿Está seguro que quiere eliminar el primer registro de la cola?",
                                                      "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    colaUsuario.Dequeue(); // Eliminar el primer elemento de la cola
                    ActualizarDataGridViewCola();
                }
            }
            else
            {
                MessageBox.Show("No hay registros en la cola para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizarDataGridViewCola()
        {
            dgCola.DataSource = null;
            dgCola.DataSource = colaUsuario.ToArray();
        }

        private void btnEliminarLista_Click(object sender, EventArgs e)
        {
            string nroId = txtNroId.Text.Trim();
            if (string.IsNullOrEmpty(nroId))
            {
                MessageBox.Show("Por favor, ingrese el número de identificación del usuario a eliminar.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar el usuario en la lista por número de identificación
            var usuarioAEliminar = listaUsuario.FirstOrDefault(usuario => usuario.strNroId == nroId);
            if (usuarioAEliminar != null)
            {
                // Confirmación antes de eliminar
                DialogResult result = MessageBox.Show($"¿Está seguro que quiere eliminar el usuario con ID: {nroId} de la lista?",
                                                      "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    listaUsuario.Remove(usuarioAEliminar);
                    ActualizarDataGridViewLista();
                }
            }
            else
            {
                MessageBox.Show("No se encontró ningún usuario con ese número de identificación en la lista.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizarDataGridViewLista()
        {
            dgLista.DataSource = null;
            dgLista.DataSource = listaUsuario.ToArray();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNroId.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
            txtReporteDatos.Clear();
            txtValorPago.Clear();
            this.cbEstrato.Text = "";
            this.cbTipoDocumento.Text = "";
            this.cbTipoEstructura.Text = "";
            this.rdGeneral.Checked = false;
            this.rdGeneral.Checked = false;
            
            MessageBox.Show("Los campos del formulario han sido limpiados.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void cbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Sólo se permiten números en la edad del usuario", "Validación ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != (char )Keys.Space))
            {
                MessageBox.Show("Sólo se permiten letras en el nombre del usuario", "Validación ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;

            }

        }
    }
}
