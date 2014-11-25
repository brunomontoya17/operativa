using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controladora;
using Modelo;

namespace TPEspecial2013
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        ControlUsuarios controller = new ControlUsuarios();

        public Usuario UsuarioLogeado { get { return ControlUsuarios.WhoIsLogged(); } }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text != "" && txtPass.Text != "")
                {
                    controller.LogIn(txtUser.Text, txtPass.Text);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe ingresar usuario y contraseña");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
