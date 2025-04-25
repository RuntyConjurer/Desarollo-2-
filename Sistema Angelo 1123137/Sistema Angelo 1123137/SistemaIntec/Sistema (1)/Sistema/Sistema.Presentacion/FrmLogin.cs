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
    public partial class FrmLogin: Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla = NLogin.Login(txtEmail.Text.Trim(), txtClave.Text.Trim());

            if(tabla.Rows.Count == 0)
            {
                MessageBox.Show("El Correo o la contrasena son incorrectos", " Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToBoolean(tabla.Rows[0][4]) == false)
                {
                    MessageBox.Show("El usuario esta inactivo", " Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Permitir que acceda al programa 
                    frmPrincipal frm = new frmPrincipal();
                    frm.IdUsuario = Convert.ToInt32(tabla.Rows[0][0]);
                    Variables.idUsuario = Convert.ToInt32(tabla.Rows[0][0]);
                    frm.IdRol = Convert.ToInt32(tabla.Rows[0][1]);
                    frm.Rol = Convert.ToString(tabla.Rows[0][2]);
                    frm.Nombre = Convert.ToString(tabla.Rows[0][3]);
                    frm.Estado = Convert.ToBoolean(tabla.Rows[0][4]);
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
