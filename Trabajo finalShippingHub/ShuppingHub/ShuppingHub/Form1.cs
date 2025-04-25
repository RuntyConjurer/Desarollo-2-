using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShuppingHub
{
    public partial class Form1 : Form
    {
        private List<Package> packages = new List<Package>();
        private int currentIndex = -1;

        public Form1()
        {
            InitializeComponent();
           

        }


        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtArrivedAt_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblArrivedAt_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblPackageNumber_Click(object sender, EventArgs e)
        {

        }

        private void txtPackageNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCity_Click(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void lblState_Click(object sender, EventArgs e)
        {

        }

        private void lblZip_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayPackage(packages[currentIndex]);
            }
        }


        private void btnScanNew_Click(object sender, EventArgs e)
        {
            Package newPackage = new Package();
            packages.Add(newPackage);
            currentIndex = packages.Count - 1;

            txtPackageNumber.Text = newPackage.PackageNumber.ToString();
            txtArrivedAt.Text = newPackage.ArrivedAt.ToString("g");
            txtAddress.Clear();
            txtCity.Clear();
            txtZip.Clear();
            cmbState.SelectedIndex = -1;

            MessageBox.Show("Nuevo paquete escaneado. Ahora puedes ingresar la información de destino.");
        


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentIndex == -1)
            {
                MessageBox.Show("Debes escanear un paquete antes de guardarlo. Haz clic en 'Scan New'.");
                return;
            }

            if (!ValidateInputs())
                return;

            Package pkg = packages[currentIndex];
            pkg.Address = txtAddress.Text;
            pkg.City = txtCity.Text;
            pkg.State = cmbState.SelectedItem.ToString();
            pkg.Zip = int.Parse(txtZip.Text);

            RefreshPackageList();
            MessageBox.Show("Paquete guardado exitosamente.");
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("La dirección no puede estar vacía.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("La ciudad no puede estar vacía.");
                return false;
            }

            if (cmbState.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor selecciona un estado válido.");
                return false;
            }

            if (!int.TryParse(txtZip.Text, out int zip) || txtZip.Text.Length != 5)
            {
                MessageBox.Show("El código ZIP debe contener exactamente 5 dígitos numéricos.");
                return false;
            }

            return true;
        }


        private void RefreshPackageList()
        {
            lstPackages.Items.Clear();
            foreach (var pkg in packages)
            {
                lstPackages.Items.Add(pkg.ToString());
            }
        }

        private void DisplayPackage(Package pkg)
        {
            txtPackageNumber.Text = pkg.PackageNumber.ToString();
            txtArrivedAt.Text = pkg.ArrivedAt.ToString("g");
            txtAddress.Text = pkg.Address;
            txtCity.Text = pkg.City;
            cmbState.SelectedItem = pkg.State;
            txtZip.Text = pkg.Zip.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < packages.Count)
            {
                var confirm = MessageBox.Show("¿Estás seguro de eliminar este paquete?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    packages.RemoveAt(currentIndex);
                    currentIndex = packages.Count > 0 ? packages.Count - 1 : -1;

                    RefreshPackageList();

                    if (currentIndex >= 0)
                        DisplayPackage(packages[currentIndex]);
                    else
                        ClearInputs();
                }
            }
        }


        private void ClearInputs()
        {
            txtPackageNumber.Clear();
            txtArrivedAt.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtZip.Clear();
            cmbState.SelectedIndex = -1;
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (currentIndex == -1)
            {
                MessageBox.Show("Primero selecciona o escanea un paquete para editarlo.");
                return;
            }

            if (!ValidateInputs())
                return;

            Package pkg = packages[currentIndex];
            pkg.Address = txtAddress.Text;
            pkg.City = txtCity.Text;
            pkg.State = cmbState.SelectedItem.ToString();
            pkg.Zip = int.Parse(txtZip.Text);

            RefreshPackageList();
            MessageBox.Show("Paquete actualizado correctamente.");
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < packages.Count - 1)
            {
                currentIndex++;
                DisplayPackage(packages[currentIndex]);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmbFilterState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string state = cmbFilterState.SelectedItem.ToString();
            lstPackages.Items.Clear();

            foreach (var pkg in packages)
            {
                if (pkg.State == state)
                {
                    lstPackages.Items.Add(pkg.ToString());
                }
            }
        }


        private void lstPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPackages.SelectedIndex >= 0)
            {
                string selectedText = lstPackages.SelectedItem.ToString();
                int id = int.Parse(selectedText.Split('-')[0].Trim('#', ' '));
                var pkg = packages.Find(p => p.PackageNumber == id);
                currentIndex = packages.IndexOf(pkg);
                DisplayPackage(pkg);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
         
                string[] states = { "AL", "FL", "GA", "KY", "MS", "NC", "SC", "TN", "WV", "VA" };
                cmbState.Items.AddRange(states);
                cmbFilterState.Items.AddRange(states);
         
        }
    }
}
