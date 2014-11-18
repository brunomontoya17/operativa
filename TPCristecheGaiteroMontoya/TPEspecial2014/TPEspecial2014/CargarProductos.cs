using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controladora;
using System.Threading.Tasks;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace TPEspecial2013
{
    public partial class CargarProductos : Form
    {
        public CargarProductos()
        {
            InitializeComponent();
        }

        ControlProductos c_productos = new ControlProductos();
        DataSet dataSet = null;

        private void LLenarGrid(string archivo, string hoja)
        {
            //declaramos las variables         
            OleDbConnection conexion = null;

            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";

            //esta cadena es para archivos excel 2007 y 2010
            //string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

            //para archivos de 97-2003 usar la siguiente cadena
            string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";

            //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset
                    dataGridView1.DataSource = dataSet.Tables[0]; //le asignamos al DataGridView el contenido del dataSet
                    conexion.Close();//cerramos la conexion
                    dataGridView1.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
                }
            }
        }

        public List<string> ObtenerHojas(string archivo)
        {
            string nombre = archivo;

            var excel = new Excel.Application();
            Excel.Workbook libro = excel.Workbooks.Open(nombre);

            List<string> listas = new List<string>();

            foreach (Microsoft.Office.Interop.Excel.Worksheet item in libro.Sheets)
            {
                listas.Add(item.Name);
            }

            return listas;
        }

        private void CargarProductos_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
            //solo los archivos excel

            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //el nombre del archivo sera asignado al textbox
                txtArchivo.Text = dialog.FileName;

                comboBox1.DataSource = ObtenerHojas(txtArchivo.Text);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarGrid(txtArchivo.Text, comboBox1.Text);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las
            //columnas al ancho del DataGridview para que no quede espacio en blanco (opcional)
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = new Aviso().ShowDialog();

            if (respuesta == DialogResult.Cancel)
                return;

            bool change = false;

            try
            {
                if (dataGridView1.Columns[0].HeaderText.ToLower() == "codigo"
                    && dataGridView1.Columns[1].HeaderText.ToLower() == "descripcion"
                    && dataGridView1.Columns[2].HeaderText.ToLower() == "precio"
                    && dataGridView1.Columns[3].HeaderText.ToLower()=="stock")
                {


                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {

                            change = c_productos.ProcesarCodigo(item.Cells["Codigo"].Value, item.Cells["Descripcion"].Value, item.Cells["Precio"].Value,item.Cells["Stock"].Value);

                            item.DefaultCellStyle.BackColor = change ? Color.LightGreen : Color.Salmon;

                        }
                        //grabo
                        if(change)
                        {
                            MessageBox.Show("Guardado Correctamente");
                        }

                    
                }
                else
                {
                    MessageBox.Show("El archivo tienen formato incorrecto");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
