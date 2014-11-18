using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelo;
using Controladora;
using System.Drawing.Printing;
using System.IO;

namespace TPEspecial2013
{
    public partial class ListadoProductos_CantPedido : Form
    {
        public ListadoProductos_CantPedido()
        {
            InitializeComponent();
        }

        ControlProductos controller = new ControlProductos();
        const string SALTO = "\n";
        const string COMA = ", ";
        string Descripcion;

        private void PrintCommand()
        {
            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            PrintPreviewDialog printpreview = new PrintPreviewDialog();
            printpreview.Document = printDocument;
            printDialog.Document = printDocument;

            printDocument.PrintPage += new PrintPageEventHandler(printer);

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();

            }
        }

        void printer(object sender, PrintPageEventArgs e)
        {
            int x = 10;
            int y = 0;
            int chars = 0;

            while (chars < richTextBox1.Text.Length)
            {
                if (richTextBox1.Text[chars] == '\n')
                {
                    chars++;
                    y += 20;
                    x = 10;
                }
                else if (richTextBox1.Text[chars] == '\r')
                {
                    chars++;
                    y += 20;
                    x = 10;
                }
                else
                {
                    richTextBox1.Select(chars, 1);
                    e.Graphics.DrawString(richTextBox1.SelectedText,
                        richTextBox1.SelectionFont,
                        new SolidBrush(richTextBox1.SelectionColor), new PointF(x, y));
                    x = x + 14;
                    chars++;
                }
            }
        }

        private void ListadoProductos_CantPedido_Load(object sender, EventArgs e)
        {
            try
            {
                List<Zona> Lista = controller.ListarZonas();

                Descripcion = string.Empty;

                Descripcion += "\t\t Sistema del Minimercado";

                Descripcion += SALTO;

                Descripcion += "_________________________________________________________";

                Descripcion += SALTO;

                Descripcion += "\t\t\t\t Listado de Productos";

                Descripcion += SALTO;

                Descripcion += "_________________________________________________________";

                ModeloCantFija cantfija = new ModeloCantFija();

                ModeloPeriodoTiempoFijo tiempofijo = new ModeloPeriodoTiempoFijo();

                Descripcion += SALTO;

                Descripcion += "Codigo \t Stock \t Precio \t Cantidad Orden";

                Descripcion += SALTO;

                foreach (Zona z in Lista)
                {
                    foreach (Producto p in z.ListadoDeProductos)
                    {
                        if (z.Descripcion == "A")
                        {
                            Descripcion += p.CodigoBarra + "\t " + p.Stock + "\t\t" + p.Precio.ToString("F3", new System.Globalization.CultureInfo("es-AR")) + "\t " + cantfija.CalcularCantidadUnidadesReorden(p).ToString("F3", new System.Globalization.CultureInfo("es-AR"));

                            Descripcion+= SALTO;
                        }
                        else if (z.Descripcion == "B")
                        {
                            Descripcion += p.CodigoBarra + "\t " + p.Stock + "\t\t" + p.Precio.ToString("F3", new System.Globalization.CultureInfo("es-AR")) + "\t " + cantfija.CalcularCantidadUnidadesReorden(p).ToString("F3", new System.Globalization.CultureInfo("es-AR"));

                            Descripcion += SALTO;
                        }
                        else
                        {
                            SaldoInventario s=controller.BuscarUltimaSaldoInventario(p);

                            Descripcion += p.CodigoBarra + "\t " + p.Stock + "\t\t" + p.Precio.ToString("F3", new System.Globalization.CultureInfo("es-AR")) + "\t " + tiempofijo.CalcularCantidadUnidadesReorden(p, s.ValorInventario).ToString("F3", new System.Globalization.CultureInfo("es-AR"));

                            Descripcion += SALTO;
                        }
                    }
                }

                richTextBox1.Text = "";

                richTextBox1.Text = Descripcion;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                richTextBox1.Text = Descripcion;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintCommand();
        }
    }
}
