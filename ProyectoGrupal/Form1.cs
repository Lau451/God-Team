using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;   //Libreria que me permite usar Regex para validar el mail

namespace ProyectoGrupal
{
    public partial class Form1 : Form
    {
        BindingList<Cliente> ListaClientes = new BindingList<Cliente>();  //Creo una lista de clientes
        int indice;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = ListaClientes;   //Le doy la fuente de datos al dgv -> Lista de clientes
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Var Auxiliares para chequear Edad y Dni
            int enteroEdad;
            int enteroDni;

            //obj auxiliar para chequear imput de mail correcto
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

            //Auxiliares para chequear la edad y el Dni
            bool errorEdad = int.TryParse(txtEdad.Text, out enteroEdad);
            bool errorDni = int.TryParse(txtDni.Text, out enteroDni);
            int dnitLenght = txtDni.Text.Length;


            //Validación

            if (
                !String.IsNullOrEmpty(txtNombre.Text) &&
                !String.IsNullOrEmpty(txtApellido.Text) &&
                !String.IsNullOrEmpty(txtEmail.Text) &&
                !String.IsNullOrEmpty(txtDni.Text) &&
                !String.IsNullOrEmpty(txtEdad.Text) &&
                /*int.TryParse(txtEdad.Text, out enteroEdad) &&
                int.TryParse(txtDni.Text, out enteroDni) &&*/
                errorEdad &&
                errorDni &&
                dnitLenght == 8 &&
                validateEmailRegex.IsMatch(txtEmail.Text)   //Devuelve "true" si es un formato válido de Email
            )
            {
                Cliente NuevoCliente = new Cliente(txtNombre.Text, txtApellido.Text, txtEmail.Text,
                    int.Parse(txtDni.Text), int.Parse(txtEdad.Text));

                ListaClientes.Add(NuevoCliente);

                //Limpio los textbox
                /*txtNombre.Clear();
                txtApellido.Clear();
                txtEmail.Clear();
                txtDni.Clear();
                txtEdad.Clear();*/
                
            }
            else if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor ingrese su nombre.", "Ups, se ha producido un error...",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Por favor ingrese su apellido.", "Ups, se ha producido un error...",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Muestro mensajes de error si el formato ingresado no es válido
            else if (!validateEmailRegex.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Por favor ingrese un Mail válido.", "Ups, se ha producido un error...",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (errorDni == false || !(dnitLenght == 8))  //Si el dni no es convertible a int, o no tiene 8 digitos entonces:
            {
                MessageBox.Show("Por favor ingrese una DNI válido.", "Ups, se ha producido un error...",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else if (errorEdad == false && enteroEdad>= 0)
            {
                MessageBox.Show("Por favor ingrese una edad válida.", "Ups, se ha producido un error...",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = e.RowIndex;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente clienteModificar = ListaClientes.ElementAt(indice);

            clienteModificar.ModCliente(txtNombre.Text, txtApellido.Text, txtEmail.Text, int.Parse(txtDni.Text), int.Parse(txtEdad.Text));
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            ListaClientes.RemoveAt(indice);
        }

       
    }
}
