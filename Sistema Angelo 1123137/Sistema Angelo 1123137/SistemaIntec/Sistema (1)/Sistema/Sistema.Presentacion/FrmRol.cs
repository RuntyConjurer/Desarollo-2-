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
    public partial class FrmRol : Form
    {
        public FrmRol()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {


                dgvListado.DataSource = NRol.Listar();
                this.Formato();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }//Fin del metodo Listar()
        }
        private void Formato()
        {
            dgvListado.Columns[0].Width = 100;
            dgvListado.Columns[1].Width = 220;


        } //Fin del metodo formato

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
    
