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
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        #region "Metodos auxiliares"
        //Metodo para dar formato al dgvListado

        private void Formato()
        {
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns[1].Visible = false;
            dgvListado.Columns[2].Width = 80;
            dgvListado.Columns[3].Width = 400;
            dgvListado.Columns[3].HeaderText = "Descripcion";
            dgvListado.Columns[4].Width = 20;


        } //Fin del metodo formato

        //Metodo para resetear la interfaz

        private void Limpiar()
        {
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;

            txtBuscar.Clear();
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();

            dgvListado.Columns[0].Visible = false;

            btnInsertar.Visible = true;
            btnActualizar.Visible = false;

            chkSeleccionar.Checked = false;
        }//fin del metodo limpiar

        //Metodo para indicar que hubo un error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//Fin del metodo mensaje error

        //Metodo para indicar que las cosas salieron bien
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        //Listar las categorias
        private void Listar()
        {
            dgvListado.DataSource = NCategorias.Listar();
            this.Limpiar();//limpiamos los controles
            lblTotal.Text = "Total de registros: " + dgvListado.Rows.Count.ToString();//mostramos el total de registros
        }//Fin del metodo Listar()

        //Insertar una categoria 
        private void Insertar()
        {
            try
            {
                string respuesta = ""; //aqui almacenaremos la respuesta desde la capa de datos
                if(txtNombre.Text == string.Empty)
                {
                    //Mostraremos un manesaje que indica que el nombre es obligatorio
                    this.MensajeError("El campo nombre no puede estar vacio");
                }
                else
                {
                    //inset=rtamos la categoria
                    respuesta = NCategorias.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if(respuesta == "OK")
                    {
                        this.MensajeOK("El registro se inserto de manera correcta");
                        this.Listar();
                        tabPrincipal.SelectedIndex = 0; //Muevete a la pestana del listado

                        txtId.Clear();
                        txtNombre.Clear();
                        txtDescripcion.Clear();
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                }
            }
            
            catch (Exception ex)
                {

                    throw;
                }
        } //Fin del metodo Insertar

        //Buscar categorias 
        private void Buscar(string valor)
        {
            try
            {
                dgvListado.DataSource = NCategorias.Buscar(valor);
                //this.Formato();
                this.Limpiar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        } //Fin del metodo Buscar

        //Actualizar una Categoria

        private void Actualizar()
        {
            try
            {
                string respuesta = "";

                if (txtNombre.Text == string.Empty)
                {
                    this.MensajeError("El campo nombre no puede estar vacío");
                    return;
                }

                
                respuesta = NCategorias.Actualizar(
                    Convert.ToInt32(txtId.Text),
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim()
                );

                if (respuesta == "OK")
                {
                    this.MensajeOK("El registro se actualizó de manera correcta");
                    this.Listar();  
                    tabPrincipal.SelectedIndex = 0; 
                }
                else if (!string.IsNullOrEmpty(respuesta))
                {
                    this.MensajeError(respuesta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//Fin del metodo Actualizar

        //Activar una o varias categorias
        private void Activar()
        {
            try
            {
                //Primero le vamos a preguntar al usuario si desea realizar esta accion
                DialogResult opcion = MessageBox.Show("Seguro que desea activar el(Los) registros seleccionado(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if(opcion == DialogResult.OK)
                {
                    //Procedemos a obtener los idcategoria de cada categoria seleccionada
                    int codigo;
                    string respuesta = "";

                    //recorrer el dgvListado y para cada categoria que este seleccionada, la activamos
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //Si esa fila esta marcada (el check) entonces obtenemos el idCategoria
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            //activamos esa categoria
                            respuesta = NCategorias.Activar(codigo);
                            if(respuesta == "OK")
                            {
                                this.MensajeOK("El registro se activo correctamente");
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }
                    //refrescar el dgvlistado
                    this.Listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }//Fin del metodo Activar

        //Desactivar una o varias categorias
        private void Desactivar()
        {
            try
            {
                //Primero le vamos a preguntar al usuario si desea realizar esta accion
                DialogResult opcion = MessageBox.Show("Seguro que desea desactivar el(Los) registros seleccionado(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    //Procedemos a obtener los idcategoria de cada categoria seleccionada
                    int codigo;
                    string respuesta = "";

                    //recorrer el dgvListado y para cada categoria que este seleccionada, la activamos
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //Si esa fila esta marcada (el check) entonces obtenemos el idCategoria
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            //activamos esa categoria
                            respuesta = NCategorias.Desactivar(codigo);
                            if (respuesta == "OK")
                            {
                                this.MensajeOK("El registro se desactivo correctamente");
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }
                    //refrescar el dgvlistado
                    this.Listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }//Fin del metodo Desactivar

        //Eliminar una o varias categorias
        private void Eliminar()
        {
            try
            {
                //Primero le vamos a preguntar al usuario si desea realizar esta accion
                DialogResult opcion = MessageBox.Show("Seguro que desea eliminar el(Los) registros seleccionado(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    //Procedemos a obtener los idcategoria de cada categoria seleccionada
                    int codigo;
                    string respuesta = "";

                    //recorrer el dgvListado y para cada categoria que este seleccionada, la activamos
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //Si esa fila esta marcada (el check) entonces obtenemos el idCategoria
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            //activamos esa categoria
                            respuesta = NCategorias.Eliminar(codigo);
                            if (respuesta == "OK")
                            {
                                this.MensajeOK("El registro se Elimino correctamente");
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }
                    //refrescar el dgvlistado
                    this.Listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }//Fin del metodo Eliminar
        

        #endregion


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index){
                DataGridViewCheckBoxCell chkSeleccion = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chkSeleccion.Value = !Convert.ToBoolean(chkSeleccion.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Buscar(txtBuscar.Text.Trim());
        }

        private void gdvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnInsertar.Visible = false;
                btnActualizar.Visible = true;

                //traemos los datos de la categoria
                txtId.Text = dgvListado.CurrentRow.Cells["ID"].Value.ToString();
                txtNombre.Text = dgvListado.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvListado.CurrentRow.Cells["Descripcion"].Value.ToString();
                tabPrincipal.SelectedIndex = 1; //muevete directo a la pestana de mantenimiento


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

                

                

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            //ejecuta el metodo Listar()
            this.Listar(); 
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.Insertar();
        }
          
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Actualizar();
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSeleccionar.Checked)
            {
                //Si el checkbox esta seleccionado (marcado)
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;

                dgvListado.Columns[0].Visible = true;
            }
            else
            {
                //Si el checkbox no esta seleccionado
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;

                dgvListado.Columns[0].Visible = false;
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

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            this.Desactivar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Listar();
            tabPrincipal.SelectedIndex = 0;           
        }

        private void FrmCategorias_Load_1(object sender, EventArgs e)
        {
            this.Listar();
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescipcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Cambiar a la pestaña de Mantenimiento
                tabPrincipal.SelectedIndex = 1;

                // Obtener los valores de la fila seleccionada
                txtId.Text = dgvListado.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtNombre.Text = dgvListado.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvListado.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            }
        }
    }
}

