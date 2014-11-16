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
    public partial class VerInventarios : Form
    {
        public VerInventarios()
        {
            InitializeComponent();
        }

        ControlProductos controller = new ControlProductos();
        BindingSource bin = new BindingSource();
        const string SALTO = "\n";
        const string COMA = ", ";
        bool seguir = false;

        private void VerInventarios_Load(object sender, EventArgs e)
        {
            try
            {
                controller.ProcesarZonas();

                bin.DataSource = controller.ListarProductos();

                dataGridView1.DataSource = bin;

                seguir = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                seguir = false;
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (seguir)
                {
                    Producto p = (Producto)dataGridView1.CurrentRow.DataBoundItem;

                    if (p != null)
                    {
                        Zona z = controller.BuscarZona_Producto(p);

                        if (z.Descripcion == "A")
                        {
                            ModeloCantFija cantfija = new ModeloCantFija();

                            string Descripcion = string.Empty;

                            Descripcion += "\t\t Direccion de Abastecimiento de Viveres-Armada Argentina";

                            Descripcion += SALTO;

                            Descripcion += "_________________________________________________________";

                            Descripcion += SALTO;

                            Descripcion += "\t\t\t\t Informacion del Producto";

                            Descripcion += SALTO;

                            Descripcion += "_________________________________________________________";

                            Descripcion += SALTO;

                            Descripcion += "Datos del Producto";

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Codigo: " + p.CodigoBarra;

                            Descripcion += SALTO;

                            Descripcion += "Descripcion: " + p.Descripcion;

                            Descripcion += SALTO;

                            Descripcion += "Stock: " + p.Stock + " unidades";

                            Descripcion += SALTO;

                            Descripcion += "Precio: $" + p.Precio;

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Informacion del Pedido:";

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Punto de Reorden del Producto: " + cantfija.CalcularPuntoReorden(p.DemandaPromedioDiaria).ToString("F3", new System.Globalization.CultureInfo("es-AR")) + " unidades.";

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Cantidad que debe ordenarse: " + cantfija.CalcularCantidadUnidadesReorden(p).ToString("F3", new System.Globalization.CultureInfo("es-AR")) + " unidades";

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Costo anual Total del Producto: $" + cantfija.CalcularCostoAnualTotal(p).ToString("F3", new System.Globalization.CultureInfo("es-AR"));

                            InfoProducto inf = new InfoProducto(Descripcion);

                            inf.ShowDialog();

                        }
                        else if (z.Descripcion == "B")
                        {
                            ModeloCantFija cantfija = new ModeloCantFija();

                            string Descripcion = string.Empty;

                            Descripcion += "\t\t Direccion de Abastecimiento de Viveres-Armada Argentina";

                            Descripcion += SALTO;

                            Descripcion += "_________________________________________________________";

                            Descripcion += SALTO;

                            Descripcion += "\t\t\t\t Informacion del Producto";

                            Descripcion += SALTO;

                            Descripcion += "_________________________________________________________";

                            Descripcion += SALTO;

                            Descripcion += "Datos del Producto";

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Codigo: " + p.CodigoBarra;

                            Descripcion += SALTO;

                            Descripcion += "Descripcion: " + p.Descripcion;

                            Descripcion += SALTO;

                            Descripcion += "Stock: " + p.Stock + " unidades";

                            Descripcion += SALTO;

                            Descripcion += "Precio: $" + p.Precio;

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Informacion del Pedido:";

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Cantidad que debe ordenarse: " + cantfija.CalcularCantidadUnidadesReorden(p).ToString("F3", new System.Globalization.CultureInfo("es-AR")) + " unidades";

                            InfoProducto inf = new InfoProducto(Descripcion);

                            inf.ShowDialog();

                        }
                        else
                        {
                            ModeloPeriodoTiempoFijo tiempofijo = new ModeloPeriodoTiempoFijo();

                            string Descripcion = string.Empty;

                            Descripcion += "\t\t Direccion de Abastecimiento de Viveres-Armada Argentina";

                            Descripcion += SALTO;

                            Descripcion += "_________________________________________________________";

                            Descripcion += SALTO;

                            Descripcion += "\t\t\t\t Informacion del Producto";

                            Descripcion += SALTO;

                            Descripcion += "_________________________________________________________";

                            Descripcion += SALTO;

                            Descripcion += "Datos del Producto";

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Codigo: " + p.CodigoBarra;

                            Descripcion += SALTO;

                            Descripcion += "Descripcion: " + p.Descripcion;

                            Descripcion += SALTO;

                            Descripcion += "Stock: " + p.Stock + " unidades";

                            Descripcion += SALTO;

                            Descripcion += "Precio: $" + p.Precio;

                            Descripcion += SALTO + SALTO;

                            Descripcion += "Informacion del Pedido:";

                            Descripcion += SALTO + SALTO;

                            SaldoInventario s = controller.BuscarUltimaSaldoInventario(p);

                            Descripcion += "Cantidad que debe ordenarse: " + tiempofijo.CalcularCantidadUnidadesReorden(p, s.ValorInventario).ToString("F3", new System.Globalization.CultureInfo("es-AR")) + " unidades";

                            InfoProducto inf = new InfoProducto(Descripcion);

                            inf.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe cargar las demandas y los saldo de los articulos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
