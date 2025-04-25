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
    public partial class FrmVistaProveedores: Form
    {
        public FrmVistaProveedores()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            dgvlistado.DataSource = NPersona.Listar_proveedores();
            lblTotal.Text = "Total Registros: " + dgvlistado.Rows.Count;
            this.Formato();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgvlistado.DataSource = NPersona.Buscar_proveedores(txtBuscar.Text);
            lblTotal.Text = "Total Registros: " + dgvlistado.Rows.Count;
        }
        private void Formato()
        {
            dgvlistado.Columns[0].Visible = false;
            dgvlistado.Columns[1].Width = 50;
            dgvlistado.Columns[2].Width = 100;
            dgvlistado.Columns[2].HeaderText = " Tipo Persona";
            dgvlistado.Columns[3].Width = 170;
            dgvlistado.Columns[4].Width = 100;
            dgvlistado.Columns[4].HeaderText = " Documento";
            dgvlistado.Columns[5].Width = 100;
            dgvlistado.Columns[5].HeaderText = " Numero Doc.";
            dgvlistado.Columns[6].Width = 120;
            dgvlistado.Columns[6].HeaderText = " Direccion";
            dgvlistado.Columns[7].Width = 100;
            dgvlistado.Columns[7].HeaderText = " Telefono";
            dgvlistado.Columns[8].Width = 120;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmVistaProveedores_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btn_buscar_Click_1(object sender, EventArgs e)
        {
            dgvlistado.DataSource = NPersona.Buscar_proveedores(txtBuscar.Text);
            lblTotal.Text = "Total Registros: " + dgvlistado.Rows.Count;
        }

        private void dgvlistado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvlistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Variables.idProveedor = Convert.ToInt32(dgvlistado.CurrentRow.Cells["ID"].Value);
            Variables.NombreProveedor = Convert.ToString(dgvlistado.CurrentRow.Cells["Nombre"].Value);
            this.Close();
        }

        private void dgvlistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
