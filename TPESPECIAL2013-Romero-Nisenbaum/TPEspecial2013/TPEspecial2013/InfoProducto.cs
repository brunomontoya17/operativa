using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace TPEspecial2013
{
    public partial class InfoProducto : Form
    {
        string Descripcion;

        public InfoProducto(string d)
        {
            InitializeComponent();

            Descripcion = d;
        }

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintCommand();
        }

        private void InfoProducto_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            richTextBox1.Text += Descripcion;
        }
    }
}
