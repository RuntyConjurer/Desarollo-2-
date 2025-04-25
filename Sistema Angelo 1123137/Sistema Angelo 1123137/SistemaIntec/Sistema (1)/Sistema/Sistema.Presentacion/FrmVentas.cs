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
    public partial class FrmVentas : Form
    {
        //Crear el dtDetalle para llenar el etalle de un ingreso
        private DataTable DtDetalle = new DataTable();

        // Agregar el siguiente campo en la clase FrmIngreso para declarar el componente ErrorProvider.
        private ErrorProvider ErrorIcono = new ErrorProvider();
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void Buscar(string valor)
        {
            try
            {
                dgvListado.DataSource = NVentas.Buscar(valor);
                this.Formato();
                this.Limpiar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        } //Fin del metodo Buscar
        private void Formato()
        {
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns[1].Visible = false;
            dgvListado.Columns[2].Visible = false;
            dgvListado.Columns[0].Width = 40;
            dgvListado.Columns[2].Width = 40;
            dgvListado.Columns[3].Width = 80;
            dgvListado.Columns[4].Width = 90;
            dgvListado.Columns[5].Width = 80;
            dgvListado.Columns[5].HeaderText = "Documento";
            dgvListado.Columns[6].Width = 60;
            dgvListado.Columns[6].HeaderText = "Serie";
            dgvListado.Columns[7].Width = 60;
            dgvListado.Columns[7].HeaderText = "Numero";
            dgvListado.Columns[8].Width = 80;
            dgvListado.Columns[9].Width = 60;
            dgvListado.Columns[10].Width = 80;
            dgvListado.Columns[11].Width = 55;
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//fin del metodo mensaje ok
        private void Limpiar()
        {
            DtDetalle.Clear();

            txtBuscar.Clear();
            txtCodigo.Clear();
            txtIdCliente.Clear();
            txtNombreCliente.Clear();
            txtSerieDeComprobante.Clear();
            txtNumComprobante.Clear();
            txtSubTotal.Text = "0.00";
            txtToalImpuesto.Text = "0.00";
            txtTotal.Text = "0.00";

            dgvListado.Columns[0].Visible = false;

            btnAnular.Visible = false;

            chkSeleccionar.Checked = false;
        }//fin del metodo limpiar
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//Fin del metodo mensaje error
         //Listar las categorias
        private void Listar()
        {
            try
            {
                dgvListado.DataSource = NVentas.Listar();
                this.Formato();
                this.Limpiar();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }


        }//Fin del metodo Listar()
        private void CrearTabla()
        {
            this.DtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("codigo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("stock", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal"));

            //A;adimos al DGV
            dgvDetalles.DataSource = this.DtDetalle;

            dgvDetalles.Columns[0].Visible = false;
            dgvDetalles.Columns[0].HeaderText = "CODIGO";
            dgvDetalles.Columns[1].Width = 100;
            dgvDetalles.Columns[2].HeaderText = "ARTICULO";
            dgvDetalles.Columns[2].Width = 200;
            dgvDetalles.Columns[3].HeaderText = "CANTIDAD";
            dgvDetalles.Columns[3].Width = 70;
            dgvDetalles.Columns[4].HeaderText = "PRECIO";
            dgvDetalles.Columns[4].Width = 70;
            dgvDetalles.Columns[5].HeaderText = "IMPORTE";
            dgvDetalles.Columns[5].Width = 80;

            dgvDetalles.Columns[1].ReadOnly = true;
            dgvDetalles.Columns[2].ReadOnly = true;
            dgvDetalles.Columns[5].ReadOnly = true;

        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CrearTabla();
        }
        private void AgregarDetalle(int IdArticulo, string Codigo, string Nombre, decimal Precio)
        {
            bool Agregar = true;
            //Agregar una fila al datatable
            foreach (DataRow FilaTemp in this.DtDetalle.Rows)
            {
                if (Convert.ToInt32(FilaTemp["idarticulo"]) == IdArticulo)
                {
                    Agregar = false;
                    this.MensajeError("El articulo ya fue agregado");
                }
            }
            if (Agregar)
            {
                DataRow Fila = DtDetalle.NewRow();
                Fila["idarticulo"] = IdArticulo;
                Fila["codigo"] = Codigo;
                Fila["articulo"] = Nombre;
                Fila["cantidad"] = 1;
                Fila["precio"] = Precio;
                Fila["importe"] = Precio;
                this.DtDetalle.Rows.Add(Fila);

                //Debemos calcular los totales
                this.CalcularTotales();

            }

        }
        private void CalcularTotales()
        {
            decimal Total = 0;
            decimal SubTotal = 0;

            if (dgvDetalles.Rows.Count == 0)
            {
                Total = 0;
            }
            else
            {
                foreach (DataRow item in DtDetalle.Rows)
                {
                    Total = Total + Convert.ToDecimal(item["importe"]);
                }
                SubTotal = Total / (1 + Convert.ToDecimal(txtImpuestos.Text));
                txtTotal.Text = Total.ToString("#0.00#");
                txtSubTotal.Text = SubTotal.ToString("#0.00#");
                txtToalImpuesto.Text = (Total - SubTotal).ToString("#0.00#");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar(txtBuscar.Text.Trim());
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaClientes vista = new FrmVistaClientes();
            vista.ShowDialog();
            txtIdCliente.Text = Variables.idCliente.ToString();
            txtNombreCliente.Text = Variables.NombreCliente;
        }

        private void FrmVentas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataTable Tabla = new DataTable();
                    Tabla = NArticulos.BuscarCodigo(txtCodigo.Text.Trim());

                    if (Tabla.Rows.Count <= 0)
                    {
                        this.MensajeError("Articulo no encontrado");
                    }
                    else
                    {
                        //Llenamos el datagridview
                        this.AgregarDetalle
                             (
                             Convert.ToInt32(Tabla.Rows[0][0]),
                             Convert.ToString(Tabla.Rows[0][1]),
                             Convert.ToString(Tabla.Rows[0][2]),
                             Convert.ToDecimal(Tabla.Rows[0][3])
                             );


                    }
                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerArticulo_Click(object sender, EventArgs e)
        {
            FrmMostrarArticulos frm = new FrmMostrarArticulos();
            frm.ShowDialog();
            this.AgregarDetalle(Variables.IdArticulo,
                Variables.Codigo,
                Variables.Nombre,
                Variables.Precio);
        }

        private void dgvDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow Fila = (DataRow)DtDetalle.Rows[e.RowIndex];
            decimal Precio = Convert.ToDecimal(Fila["precio"]);
            int Cantidad = Convert.ToInt32(Fila["cantidad"]);
            Fila["importe"] = Precio * Cantidad;
            this.CalcularTotales();
        }

        private void dgvDetalles_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.CalcularTotales();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";//variable para capturar la respuesta que nos dara el metodo insertar de la capa de negocio
                if (txtIdCliente.Text == string.Empty || txtImpuestos.Text == string.Empty || txtNumComprobante.Text == string.Empty || DtDetalle.Rows.Count == 0)
                {
                    this.MensajeError("Faltan ingresar algunos datos, seran remarcados");//mostramos un mensaje de error
                    ErrorIcono.SetError(txtIdCliente, "Seleccione un proveedor");
                    ErrorIcono.SetError(txtImpuestos, "Ingrese el impuesto");
                    ErrorIcono.SetError(txtNumComprobante, "Ingrese el numero de comprobante");
                    ErrorIcono.SetError(dgvDetalles, "Debe tener al menos un detalle");
                }
                else
                {
                    //llamamos al metodo insertar de la capa de negocio
                    Rpta = NVentas.Insertar(Convert.ToInt32(txtIdCliente.Text), Variables.idUsuario, cboComprobante.Text, txtSerieDeComprobante.Text.Trim(), txtNumComprobante.Text.Trim(), Convert.ToDecimal(txtImpuestos.Text), Convert.ToDecimal(txtTotal.Text), DtDetalle);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto de forma correcta el registro");
                        this.Listar();//listamos los registros
                        this.Limpiar();//limpiamos los campos
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvMostrarDetalles.DataSource = NVentas.ListarDetalle(Convert.ToInt32(dgvListado.CurrentRow.Cells["Id"].Value));
                decimal Total, SubTotal;
                decimal Impuesto = Convert.ToDecimal(dgvListado.CurrentRow.Cells["Impuesto"].Value);
                Total = Convert.ToDecimal(dgvListado.CurrentRow.Cells["Total"].Value);
                SubTotal = Total / (1 + Impuesto);
                txtSubTotalD.Text = SubTotal.ToString("#0.00#");
                txtTotalImpuestosD.Text = (Total - SubTotal).ToString("#0.00");
                txtTotalD.Text = Total.ToString("#0.00#");
                panelDetalleCliente.Visible = true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                //Si el checkbox esta seleccionado (marcado)
                btnAnular.Visible = true;

                dgvListado.Columns[0].Visible = true;
            }
            else
            {
                //Si el checkbox no esta seleccionado

                btnAnular.Visible = false;

                dgvListado.Columns[0].Visible = false;
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("¿Realmente desea eliminar los registros seleccionados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    int Codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NVentas.Anular(Codigo);

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

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkSeleccion = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chkSeleccion.Value = !Convert.ToBoolean(chkSeleccion.Value);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabPrincipal.SelectedIndex = 0;
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgvMostrarDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            panelDetalleCliente.Visible = false;
        }
        //Metodo agregar detalle de un articulo para ingreso

    }
}
