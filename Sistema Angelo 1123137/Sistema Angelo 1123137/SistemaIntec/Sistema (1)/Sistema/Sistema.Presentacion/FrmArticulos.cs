using Sistema.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using System.Drawing;
using System.Drawing.Imaging;

namespace Sistema.Presentacion
{
    public partial class FrmArticulos : Form
    {
        private string RutaOrigen;
        private string RutaDestino;
        private string Directorio = "C:\\Sistema\\";
        private string NombreAnt;
        public FrmArticulos()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.PictureBox pictureBoxBarcode;

        private void GenerarCodigoBarras(string codigo)
        {
            BarcodeLib.Barcode Codigo = new Barcode();
            Codigo.IncludeLabel = true;
            picCodigoBarras.BackgroundImage = Codigo.Encode(BarcodeLib.TYPE.CODE128, codigo, Color.Black, Color.White, 200, 100);
            btnGuardarCodigo.Enabled = true;
        }



        #region "Metodos Auxiliares"

        //Metodo para formater el data grid view
        private void Formato()
        {
            dgvListado.Columns[0].Visible = false;//ocultamos la columna eliminar
            dgvListado.Columns[2].Visible = false;//ancho de la columna
            dgvListado.Columns[0].Width = 100;//ancho de la columna
            dgvListado.Columns[1].Width = 50;//ancho de la columna
            dgvListado.Columns[3].Width = 90;//ancho de la columna
            dgvListado.Columns[3].HeaderText = "Categoria";//ancho de la columna
            dgvListado.Columns[4].Width = 90;//ancho de la columna
            dgvListado.Columns[4].HeaderText = "Codigo";//ancho de la columna
            dgvListado.Columns[5].Width = 100;//ancho de la columna
            dgvListado.Columns[6].Width = 90;//ancho de la columna
            dgvListado.Columns[6].HeaderText = "Precio Venta";//ancho de la columna
            dgvListado.Columns[7].Width = 60;//ancho de la columna
            dgvListado.Columns[8].Width = 90;//ancho de la columna
            dgvListado.Columns[8].HeaderText = "Descirpcion";//ancho de la columna
            dgvListado.Columns[9].Width = 70;//ancho de la columna
            dgvListado.Columns[10].Width = 70;//ancho de la columna

        }//fin del metodo formato


        //metodo para limpiar los controles del formulario
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtId.Clear();
            txtDescripcion.Clear();
            txtCodigo.Clear();
            txtPrecio.Clear();
            txtStock.Clear();


            picCodigoBarras.BackgroundImage = null;
            picArticuloImagen.BackgroundImage = null;

            txtStock.Text = "0";
            txtPrecio.Text = "0.00";

            //btnInsertar.Visible = true;
            btnActualizar.Visible = true;

            dgvListado.Columns[0].Visible = false;
            btnEliminar.Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            chkSeleccionar.Visible = true
                ;

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
            dgvListado.DataSource = NArticulos.Listar();
            this.Formato();//dale formato al datagridview
            this.Limpiar();//limpiamos los controles
            lblTotal.Text = "Total de registros: " + dgvListado.Rows.Count.ToString();//mostramos el total de registros
        }//fin del metodo listar

        private void CategoriaSeleccionar()
        {
            try
            {
                //cargar el data table en el datagitview
                cmbCategorias.DataSource = NArticulos.CategoriaSeleccionar();
                cmbCategorias.ValueMember = "idcategoria";
                cmbCategorias.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//fin del metodo cargar categoria
        }

        //buscar categorias
        private void Buscar(string valor)
        {
            try
            {
                //cargar el data table en el datagitview
                dgvListado.DataSource = NArticulos.Buscar(valor);
                this.Formato();//dale formato al datagridview
                lblTotal.Text = "Total de registros: " + dgvListado.Rows.Count.ToString();//mostramos el total de registros
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
                if (txtNombre.Text == string.Empty || cmbCategorias.Text == string.Empty || txtCodigo.Text == string.Empty || txtPrecio.Text == string.Empty || txtStock.Text == string.Empty)
                {
                    this.MensajeError("Ingrese los campos Necesesario");//mostramos un mensaje de error
                }
                else
                {
                    //llamamos al metodo insertar de la capa de negocio
                    respuesta = NArticulos.Insertar(Convert.ToInt32(cmbCategorias.SelectedValue),
                        txtCodigo.Text.Trim(),
                        txtNombre.Text.Trim(),
                        Convert.ToDecimal(txtPrecio.Text.Trim()),
                        Convert.ToInt32(txtStock.Text),
                        txtDescripcion.Text.Trim(), "");
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
                if (txtNombre.Text == string.Empty || cmbCategorias.Text == string.Empty || txtCodigo.Text == string.Empty || txtPrecio.Text == string.Empty || txtStock.Text == string.Empty)
                {
                    this.MensajeError("Ingrese los Campos Necesarios");//mostramos un mensaje de error
                }
                else
                {
                    //llamamos al metodo insertar de la capa de negocio
                    respuesta = NArticulos.Actualizar(
                        Convert.ToInt32(txtId.Text),
                        Convert.ToInt32(cmbCategorias.SelectedValue),
                        txtCodigo.Text.Trim(),
                        txtNombre.Text.Trim(),
                        Convert.ToDecimal(txtPrecio.Text.Trim()),
                        Convert.ToInt32(txtStock.Text),
                        txtDescripcion.Text.Trim(), "");

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
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NArticulos.Activar(codigo);

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
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NArticulos.Desactivar(codigo);

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
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NArticulos.Eliminar(codigo);

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {

            //llamar al metodo Listar()

            //Llamar al metodo Categoria Seleccionar
            this.CategoriaSeleccionar();
            this.Listar();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkSeleccion = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chkSeleccion.Value = !Convert.ToBoolean(chkSeleccion.Value);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(txtBuscar.Text.Trim());
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.Insertar();
        }
        private void dgvlistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["ID"].Value);
                cmbCategorias.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["idcategoria"].Value);
                txtCodigo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["codigo"].Value);
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value);
                txtPrecio.Text = Convert.ToString(dgvListado.CurrentRow.Cells["precio_venta"].Value);
                txtStock.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Stock"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value);
                txtImagen.Text = Convert.ToString(dgvListado.CurrentRow.Cells["imagen"].Value);

                tabPrincipal.SelectedIndex = 1;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Actualizar();
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListado.Columns[0].Visible = true;
                btnEliminar.Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;

            }
            else
            {
                dgvListado.Columns[0].Visible = false;
                btnEliminar.Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
            }
        }

        private void picCodigoBarras_Click(object sender, EventArgs e)
        {
            this.pictureBoxBarcode = new System.Windows.Forms.PictureBox();
            this.pictureBoxBarcode.Location = new System.Drawing.Point(600, 30); // Change position as needed
            this.pictureBoxBarcode.Size = new System.Drawing.Size(200, 100);
            this.Controls.Add(this.pictureBoxBarcode);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            GenerarCodigoBarras(txtCodigo.Text);
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {

        }

        private void dgvListado_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Cambiar a la pestaña de Mantenimiento
                tabPrincipal.SelectedIndex = 1;

                // Obtener los valores de la fila seleccionada
                txtId.Text = dgvListado.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtNombre.Text = dgvListado.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvListado.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                txtCodigo.Text = dgvListado.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                txtPrecio.Text = dgvListado.Rows[e.RowIndex].Cells["precio_venta"].Value.ToString();
                txtStock.Text = dgvListado.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
                txtImagen.Text = dgvListado.Rows[e.RowIndex].Cells["Imagen"].Value.ToString();
                cmbCategorias.SelectedValue = dgvListado.Rows[e.RowIndex].Cells["idcategoria"].Value.ToString();


            }
        }

        private void btnActivar_Click_1(object sender, EventArgs e)
        {
            this.Activar();
        }

        private void btnDesactivar_Click_1(object sender, EventArgs e)
        {
            this.Desactivar();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void btnGuardarCodigo_Click(object sender, EventArgs e)
        {
            Image imgFinal = (Image)picCodigoBarras.Image.Clone();

            SaveFileDialog DialogoGuardar = new SaveFileDialog();
            DialogoGuardar.AddExtension = true;
            DialogoGuardar.Filter = "Image PNG (*.png)|*.png";
            DialogoGuardar.ShowDialog();
            if (!string.IsNullOrEmpty(DialogoGuardar.FileName))
            {
                imgFinal.Save(DialogoGuardar.FileName, ImageFormat.Png);
            }

            imgFinal.Dispose();
        }

        private void btnInsertarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                picArticuloImagen.Image = Image.FromFile(file.FileName);
                txtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);
                this.RutaOrigen = file.FileName;
            }

        }


         

        }
}

