using Sistema.Entidad;
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
    public partial class FrmProveedores: Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }



        private void Formato()
        {
            dgvlistado.Columns[0].Visible = false;
            dgvlistado.Columns[1].Width = 50;
            dgvlistado.Columns[2].Width = 85;
            dgvlistado.Columns[2].HeaderText = " Tipo Persona";
            dgvlistado.Columns[3].Width = 100;
            dgvlistado.Columns[4].Width = 110;
            dgvlistado.Columns[4].HeaderText = " Documento";
            dgvlistado.Columns[5].Width = 90;
            dgvlistado.Columns[5].HeaderText = " Numero Documento";
            dgvlistado.Columns[6].Width = 110;
            dgvlistado.Columns[6].HeaderText = " Direccion";
            dgvlistado.Columns[7].Width = 80;
            dgvlistado.Columns[7].HeaderText = " Telefono";
            dgvlistado.Columns[8].Width = 108;
        }
       

        private void MensajeError(string respuesta)
        {
            throw new NotImplementedException();
        }

        public void Actualizar()
        {
            try
            {
                string respuesta = "";

                if (txtNombre.Text == string.Empty || cmbTipoDocumento.Text == string.Empty || txtNumeroDocumento.Text == string.Empty || txtEmail.Text == string.Empty)
                {
                    this.MensajeError("Ingrese los Campos Necesarios");
                }
                else
                {
                    respuesta = NPersona.Actualizar(
                        Convert.ToInt32(txtId.Text),                          
                        "Proveedor",                                          
                        txtNombre.Text.Trim(),
                        cmbTipoDocumento.Text,
                        txtNumeroDocumento.Text.Trim(),                       
                        txtDireccion.Text.Trim(),                             
                        txtTelefono.Text.Trim(),                              
                        txtEmail.Text.Trim()                                  
                    );

                    if (respuesta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó de forma correcta el registro");
                        this.Listar();
                        tabPrincipal.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//fin del metodo mensaje ok

        private void Listar()
        {
            dgvlistado.DataSource = NPersona.Listar_proveedores();
            lblTotal.Text = "Total Registros: " + dgvlistado.Rows.Count;
            this.Formato();
        }

        
        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            cmbTipoDocumento.SelectedIndex = -1;
            txtNumeroDocumento.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }

        private void Insertar()
        {
            try
            {
            string respuesta = "";//variable para capturar la respuesta que nos dara el metodo insertar de la capa de Persona
            if (txtNombre.Text == string.Empty || txtNumeroDocumento.Text == string.Empty || txtEmail.Text == string.Empty || cmbTipoDocumento.SelectedIndex == -1)
            {
                this.MensajeError("Ingrese los campos Necesesario");//mostramos un mensaje de error
            }
            else
            {
                respuesta = NPersona.Insertar(
                  "Proveedor",
                  txtNombre.Text.Trim(),
                  cmbTipoDocumento.Text,
                  txtNumeroDocumento.Text.Trim(),
                  txtDireccion.Text.Trim(),
                  txtTelefono.Text.Trim(),
                  txtEmail.Text.Trim()
              );

                if (respuesta.Equals("OK"))
                {
                    MessageBox.Show("Registro insertado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listar();

                }
                else
                {
                    MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }//fin del metodo inserta
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//fin del metodo insertar

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            this.Insertar();
            this.Limpiar();
            tabPrincipal.SelectedIndex = 0;
        }

       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void dgvlistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btninsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["IdPersona"].Value);
                txtNombre.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["Nombre"].Value);
                cmbTipoDocumento.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["Tipo_Documento"].Value);
                txtNumeroDocumento.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["Num_Documento"].Value);
                txtDireccion.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["Direccion"].Value);
                txtTelefono.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["Telefono"].Value);
                txtEmail.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["Email"].Value);


                tabPrincipal.SelectedIndex = 1;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void dgvlistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvlistado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkSeleccion = (DataGridViewCheckBoxCell)dgvlistado.Rows[e.RowIndex].Cells["Seleccionar"];
                chkSeleccion.Value = !Convert.ToBoolean(chkSeleccion.Value);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgvlistado.DataSource = NPersona.Buscar_proveedores(txtBuscar.Text);
            lblTotal.Text = "Total Registros: " + dgvlistado.Rows.Count;
            this.Formato();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                //Si el checkbox esta seleccionado (marcado)
                btnEliminar.Visible = true;

                dgvlistado.Columns[0].Visible = true;
            }
            else
            {
                //Si el checkbox no esta seleccionado
               
                btnEliminar.Visible = false;

                dgvlistado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("¿Realmente desea eliminar los registros seleccionados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    int id;
                    string respuesta = "";

                    foreach (DataGridViewRow row in dgvlistado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                        {
                            id = Convert.ToInt32(row.Cells["ID"].Value);
                            respuesta = NPersona.Eliminar(id);

                            if (respuesta.Equals("OK"))
                            {
                                MessageBox.Show("Registro eliminado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    Listar(); // Actualiza la lista de registros
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Actualizar();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void FrmProveedores_Load_1(object sender, EventArgs e)
        {
            this.Listar();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id");
            tabla.Columns.Add("Nombre");

            tabla.Rows.Add(1, "Licencia de Conducir");
            tabla.Rows.Add(2, "DNI");
            tabla.Rows.Add(3, "Pasaporte");
            tabla.Rows.Add(4, "Cedula");

            cmbTipoDocumento.DataSource = tabla;
            cmbTipoDocumento.DisplayMember = "Nombre";
            cmbTipoDocumento.ValueMember = "Id";
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvlistado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void dgvlistado_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabPrincipal.SelectedIndex = 1;

                txtId.Text = dgvlistado.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtNombre.Text = dgvlistado.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtNumeroDocumento.Text = dgvlistado.Rows[e.RowIndex].Cells[5].Value.ToString(); 
                txtDireccion.Text = dgvlistado.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dgvlistado.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvlistado.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                // Obtener el texto del documento desde el DataGridView
                string tipoDocumentoTexto = dgvlistado.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Buscar el ID correspondiente en el ComboBox
                foreach (DataRowView item in cmbTipoDocumento.Items)
                {
                    if (item["Nombre"].ToString() == tipoDocumentoTexto)
                    {
                        cmbTipoDocumento.SelectedValue = item["Id"];
                        break;
                    }
                }
            }
        }
    }
}
