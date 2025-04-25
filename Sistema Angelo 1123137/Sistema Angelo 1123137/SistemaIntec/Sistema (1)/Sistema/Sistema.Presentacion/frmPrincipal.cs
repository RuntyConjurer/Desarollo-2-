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
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;

        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK) 
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK) 
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void viewMenu_Click(object sender, EventArgs e)
        {

        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        { //Creamos un objeto de la clase FrmCategorias
            FrmCategorias frm = new FrmCategorias();
            //Le asignamos como padre Frmprincpal
            frm.MdiParent = this;
            //Mostramos el formulario 
            frm.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulos frm = new FrmArticulos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRol frm = new FrmRol();
            frm.MdiParent = this;
            frm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido : " + Nombre, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripStatusLabel.Text = "Usuario " + Nombre + "       Fecha: " + DateTime.Now.ToLongDateString();

            if(Rol == "Administrador")
            {

                almacenToolStripMenuItem.Enabled = true;
                ingresosToolStripMenuItem.Enabled = true;
                ventasToolStripMenuItem.Enabled = true;
                comprasToolStripMenuItem.Enabled = true;
                accesosToolStripMenuItem.Enabled = true;
                reportesToolStripMenuItem.Enabled = true;
            }
            else if (Rol == " Vendedor")
            {
                almacenToolStripMenuItem.Enabled = false;
                ingresosToolStripMenuItem.Enabled = false;
                ventasToolStripMenuItem.Enabled = true;
                comprasToolStripMenuItem.Enabled = false;
                accesosToolStripMenuItem.Enabled = false;
                reportesToolStripMenuItem.Enabled = true;
            }
            else if(Rol == "Almacen")
            {
                almacenToolStripMenuItem.Enabled = true;
                ingresosToolStripMenuItem.Enabled = false;
                ventasToolStripMenuItem.Enabled = false;
                comprasToolStripMenuItem.Enabled = true;
                accesosToolStripMenuItem.Enabled = false;
                reportesToolStripMenuItem.Enabled = false;
            }
            else
            {
                almacenToolStripMenuItem.Enabled = false;
                ingresosToolStripMenuItem.Enabled = false;
                ventasToolStripMenuItem.Enabled = false;
                comprasToolStripMenuItem.Enabled = false;
                accesosToolStripMenuItem.Enabled = false;
                reportesToolStripMenuItem.Enabled = false;
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Seguro desea salir del sistema? ", "Sistema de Ventas ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if( resultado == DialogResult.Yes)
                {
                Application.Exit();
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores frmproveedores = new FrmProveedores();
            frmproveedores.MdiParent = this;
            frmproveedores.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmclientes = new FrmClientes();
            frmclientes.MdiParent = this;
            frmclientes.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngreso frm = new FrmIngreso();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void ventasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
