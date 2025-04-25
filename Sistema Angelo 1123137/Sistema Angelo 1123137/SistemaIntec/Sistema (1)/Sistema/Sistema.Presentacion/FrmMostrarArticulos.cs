using Sistema.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class FrmMostrarArticulos: Form
    {
        public FrmMostrarArticulos()
        {
            InitializeComponent();
        }
        private void Buscar()
        {
            try
            {
                //cargar el data table en el datagitview
                dgvListado.DataSource = NArticulos.Buscar(txtBuscar.Text);
                this.Formato();//dale formato al datagridview
                lblTotal.Text = "Total de registros: " + dgvListado.Rows.Count.ToString();//mostramos el total de registros
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }


        }//fin del metodo buscar
        private void Formato()
        {
            dgvListado.Columns[0].Visible = false;//ocultamos la columna eliminar
            dgvListado.Columns[2].Visible = false;//ancho de la columna
            dgvListado.Columns[0].Width = 100;//ancho de la columna
            dgvListado.Columns[1].Width = 50;//ancho de la columna
            dgvListado.Columns[3].Width = 100;//ancho de la columna
            dgvListado.Columns[3].HeaderText = "Categoria";//ancho de la columna
            dgvListado.Columns[4].Width = 100;//ancho de la columna
            dgvListado.Columns[4].HeaderText = "Codigo";//ancho de la columna
            dgvListado.Columns[5].Width = 150;//ancho de la columna
            dgvListado.Columns[6].Width = 100;//ancho de la columna
            dgvListado.Columns[6].HeaderText = "Precio Venta";//ancho de la columna
            dgvListado.Columns[7].Width = 60;//ancho de la columna
            dgvListado.Columns[8].Width = 200;//ancho de la columna
            dgvListado.Columns[8].HeaderText = "Descirpcion";//ancho de la columna
            dgvListado.Columns[9].Width = 100;//ancho de la columna
            dgvListado.Columns[10].Width = 100;//ancho de la columna

        }//fin del metodo formato

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           Variables.IdArticulo = Convert.ToInt32(dgvListado.CurrentRow.Cells["ID"].Value);
            Variables.Codigo = Convert.ToString(dgvListado.CurrentRow.Cells["Codigo"].Value);
            Variables.Nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            Variables.Precio = Convert.ToDecimal(dgvListado.CurrentRow.Cells["Precio_Venta"].Value);
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
