using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelo;

namespace TPEspecial2013
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        Usuario logeado = null;

        CargarProductos _cargar = null;

        CargarPlanillaAbastecimientoProductos _cargarpd=null;

        CargarPlanillaSaldoInventario _cargars = null;

        VerInventarios _ver = null;

        ListadoProductos_CantPedido _list = null;

        private void Principal_Load(object sender, EventArgs e)
        {
            this.Hide();

            try
            {
                Login login_form = new Login();

                login_form.ShowDialog();

                logeado = login_form.UsuarioLogeado;

                if (logeado != null)
                {
                    lblUsuario.Text = logeado.Nombre;

                    this.Show();
                }
                else
                {
                    MessageBox.Show("Verifique Usuario y Contraseña");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private CargarProductos FCargar
        {
            get
            {
                if (_cargar == null)
                {
                    _cargar = new CargarProductos();
                    _cargar.MdiParent = this;
                    _cargar.Disposed += new EventHandler(_cargar_Disposed);
                }
                return _cargar;
            }
        }
        private void _cargar_Disposed(object sender, EventArgs e)
        {
            _cargar = null;
        }

        private CargarPlanillaAbastecimientoProductos FCargarD
        {
            get
            {
                if (_cargarpd == null)
                {
                    _cargarpd = new CargarPlanillaAbastecimientoProductos();
                    _cargarpd.MdiParent = this;
                    _cargarpd.Disposed += new EventHandler(_cargarpd_Disposed);
                }
                return _cargarpd;
            }
        }
        private void _cargarpd_Disposed(object sender, EventArgs e)
        {
            _cargarpd = null;
        }

        private CargarPlanillaSaldoInventario FCargarS
        {
            get
            {
                if (_cargars == null)
                {
                    _cargars = new CargarPlanillaSaldoInventario();
                    _cargars.MdiParent = this;
                    _cargars.Disposed += new EventHandler(_cargarps_Disposed);
                }
                return _cargars;
            }
        }
        private void _cargarps_Disposed(object sender, EventArgs e)
        {
            _cargars = null;
        }

        private VerInventarios Ver
        {
            get
            {
                if (_ver == null)
                {
                    _ver = new VerInventarios();
                    _ver.MdiParent = this;
                    _ver.Disposed += new EventHandler(_ver_Disposed);
                }
                return _ver;
            }
        }
        private void _ver_Disposed(object sender, EventArgs e)
        {
            _ver = null;
        }

        private ListadoProductos_CantPedido Lista
        {
            get
            {
                if (_list == null)
                {
                    _list = new ListadoProductos_CantPedido();
                    _list.MdiParent = this;
                    _list.Disposed += new EventHandler(_list_Disposed);
                }
                return _list;
            }
        }
        private void _list_Disposed(object sender, EventArgs e)
        {
            _list = null;
        }

        private void cargarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCargar.Show();
        }

        private void demandaDelBuqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCargarD.Show();
        }

        private void saldoDeInventarioDelBuqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCargarS.Show();
        }

        private void inventarioDeLosProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver.Show();
        }

        private void listadoDeCantidadesAOrdenarseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista.Show();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
