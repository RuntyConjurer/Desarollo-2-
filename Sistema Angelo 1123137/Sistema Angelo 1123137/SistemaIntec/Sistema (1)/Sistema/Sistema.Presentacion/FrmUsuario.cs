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
    public partial class FrmUsuario: Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        #region "Metodos Auxiliares"

        //Metodo para formater el data grid view
        private void Formato()
        {
            //dgvlistado.Columns[0].Visible = false;//ocultamos la columna eliminar
            //dgvlistado.Columns[2].Visible = false;//ancho de la columna


        }//fin del metodo formato

        private void Listar_Rol()
        {
            try
            {
                //cargar el data table en el datagitview
                cmbRol.DataSource = Nusuario.Listar_Rol();
                cmbRol.ValueMember = "idrol";
                cmbRol.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//fin del metodo cargar categoria
        }

        //metodo para limpiar los controles del formulario
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtId.Clear();
            txtNombre.Clear();
            txtNumeroDocumento.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtClave.Clear();



            //btnInsertar.Visible = true;
            btnActualizar.Visible = true;

            dgvlistado.Columns[0].Visible = false;
            btnEliminar.Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            chkSeleccionar.Checked = false;

        }//fin del metodo limpiar



        //metodo para mostrar un mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//fin del metodo mensaje error

        //metodo para mostrar un mensaje de ok
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//fin del metodo mensaje ok


        //listar articulos
        private void Listar()
        {
            //cargar el data table en el datagitview
            dgvlistado.DataSource = Nusuario.Listar();
            this.Formato();//dale formato al datagridview
            this.Limpiar();//limpiamos los controles
            lblTotal.Text = "Total de registros: " + dgvlistado.Rows.Count.ToString();//mostramos el total de registros
        }//fin del metodo listar



        //buscar categorias
        private void Buscar(string valor)
        {
            try
            {
                //cargar el data table en el datagitview
                dgvlistado.DataSource = Nusuario.Buscar(valor);
                this.Formato();//dale formato al datagridview
                lblTotal.Text = "Total de registros: " + dgvlistado.Rows.Count.ToString();//mostramos el total de registros
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }//fin del metodo buscar

        //insertar una categoria

        private void Insertar()
        {
            try
            {
                string respuesta = "";//variable para capturar la respuesta que nos dara el metodo insertar de la capa de negocio
                if (txtNombre.Text == string.Empty || txtNumeroDocumento.Text == string.Empty || txtEmail.Text == string.Empty || txtClave.Text == string.Empty || cmbTipoDocumento.SelectedIndex == -1)
                {
                    this.MensajeError("Ingrese los campos Necesesario");//mostramos un mensaje de error
                }
                else
                {
                    //llamamos al metodo insertar de la capa de negocio
                    respuesta = Nusuario.Insertar(Convert.ToInt32(cmbRol.SelectedValue),
                        txtNombre.Text.Trim(),
                        cmbTipoDocumento.Text.Trim(),
                        txtNumeroDocumento.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtClave.Text.Trim());

                    if (respuesta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto de forma correcta el registro");
                        this.Listar();//listamos los registros

                        //muevete a la pestaña de listar
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
        }//fin del metodo insertar

        //metodo para actualizar un articulo
        public void Actualizar()
        {
            try
            {
                string respuesta = "";//variable para capturar la respuesta que nos dara el metodo insertar de la capa de negocio
                if (txtNombre.Text == string.Empty || txtNumeroDocumento.Text == string.Empty || txtEmail.Text == string.Empty || txtClave.Text == string.Empty)
                {
                    this.MensajeError("Ingrese los Campos Necesarios");//mostramos un mensaje de error
                }
                else
                {
                    //llamamos al metodo insertar de la capa de negocio
                    respuesta = Nusuario.Actualizar(Convert.ToInt32(txtId.Text),
                        Convert.ToInt32(cmbRol.SelectedValue),
                        txtNombre.Text.Trim(),
                        cmbTipoDocumento.Text.Trim(),
                        txtNumeroDocumento.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtClave.Text.Trim());

                    if (respuesta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizo de forma correcta el registro");
                        this.Listar();//listamos los registros
                        //muevete a la pestaña de listar
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
        }//fin del metodo actualizar

        //metodo para activar un articulo
        private void Activar()
        {

            //preguntarle al ususario si realmente deasea activar la categoria
            DialogResult resultado = MessageBox.Show("Esta seguro de activar el/los registros seleccionados?", "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int codigo;
                    string respuesta = "";
                    //recorrer las filas del datagridview
                    foreach (DataGridViewRow row in dgvlistado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = Nusuario.Activar(codigo);

                            if (respuesta == "OK")
                            {
                                this.MensajeOk("Se activo correctamente el registro " + row.Cells[2].Value.ToString());
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                this.Listar();//listamos los registros
            }



        }//fin del metodo activar

        //metodo para desactivar una categoria

        private void Desactivar()
        {

            //preguntarle al ususario si realmente deasea activar la categoria
            DialogResult resultado = MessageBox.Show("Esta seguro de desacctivar el/los registros seleccionados?", "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int codigo;
                    string respuesta = "";
                    //recorrer las filas del datagridview
                    foreach (DataGridViewRow row in dgvlistado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = Nusuario.Desactivar(codigo);

                            if (respuesta == "OK")
                            {
                                this.MensajeOk("Se Desactivo correctamente el registro " + row.Cells[2].Value.ToString());
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                this.Listar();//listamos los registros
            }



        }

        //fin del metodo desactivar

        //metodo para eliminar una categoria

        private void Eliminar()
        {

            //preguntarle al ususario si realmente deasea activar la categoria
            DialogResult resultado = MessageBox.Show("Esta seguro de Eliminar el/los registros seleccionados?", "Sistema de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int codigo;
                    string respuesta = "";
                    //recorrer las filas del datagridview
                    foreach (DataGridViewRow row in dgvlistado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = Nusuario.Eliminar(codigo);

                            if (respuesta == "OK")
                            {
                                this.MensajeOk("Se Elimino correctamente el registro " + row.Cells[2].Value.ToString());
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                this.Listar();//listamos los registros
            }



        }

        //fin del metodo eliminar



        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.Listar_Rol();

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

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Buscar(txtBuscar.Text.Trim());
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            this.Insertar();

        }


        private void dgvlistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btninsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["ID"].Value);
                cmbRol.Text = Convert.ToString(dgvlistado.CurrentRow.Cells["Rol"].Value);
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

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvlistado.Columns[0].Visible = true;
                btnEliminar.Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
            }
            else
            {
                dgvlistado.Columns[0].Visible = false;
                btnEliminar.Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            this.Activar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Actualizar();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
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

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void dgvlistado_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabPrincipal.SelectedIndex = 1;

                txtId.Text = dgvlistado.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtNombre.Text = dgvlistado.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtNumeroDocumento.Text = dgvlistado.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtDireccion.Text = dgvlistado.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dgvlistado.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvlistado.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                // Obtener el texto del documento desde el DataGridView
                string tipoDocumentoTexto = dgvlistado.Rows[e.RowIndex].Cells[5].Value.ToString();

                // Buscar el ID correspondiente en el ComboBox
                foreach (DataRowView item in cmbTipoDocumento.Items)
                {
                    if (item["Nombre"].ToString() == tipoDocumentoTexto)
                    {
                        cmbTipoDocumento.SelectedValue = item["Id"];
                        break;
                    }
                }
                string rolTexto = dgvlistado.Rows[e.RowIndex].Cells["Rol"].Value.ToString();

                // Buscar el ID correspondiente en el ComboBox de roles
                foreach (DataRowView item in cmbRol.Items)
                {
                    if (item["Nombre"].ToString() == rolTexto)
                    {
                        cmbRol.SelectedValue = item["idrol"];
                        break;
                    }
                }
            }
        }
    }
}
