namespace aplicacionInformeVentas
{
    public partial class Form1 : Form
    {
        private decimal totalGeneral = 0;
        private int contadorItems = 0;
        private const int maxItems = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (contadorItems >= maxItems)
            {
                MessageBox.Show("Ya se han registrado los 10 artículos máximos permitidos.");
                return;
            }

            
            string item = txtItem.Text;
            decimal mon = decimal.Parse(txtMon.Text);
            decimal tue = decimal.Parse(txtTue.Text);
            decimal wed = decimal.Parse(txtWed.Text);
            decimal thu = decimal.Parse(txtThu.Text);
            decimal fri = decimal.Parse(txtFri.Text);
            decimal price = decimal.Parse(txtPrice.Text);

        
            decimal totalArticulo = mon + tue + wed + thu + fri;

            
            dataGridView1.Rows.Add(
                item,
                mon,
                tue,
                wed,
                thu,
                fri,
                price.ToString("C"),
                totalArticulo.ToString("C")
            );

           
            totalGeneral += totalArticulo;
            lblTotalGeneral.Text = "Gran Total: " + totalGeneral.ToString("C");

            contadorItems++;

           
            txtItem.Clear();
            txtMon.Clear();
            txtTue.Clear();
            txtWed.Clear();
            txtThu.Clear();
            txtFri.Clear();
            txtPrice.Clear();
            txtItem.Focus();
        }

        private void lvSalesReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Item";
            dataGridView1.Columns[1].Name = "Mon";
            dataGridView1.Columns[2].Name = "Tue";
            dataGridView1.Columns[3].Name = "Wed";
            dataGridView1.Columns[4].Name = "Thu";
            dataGridView1.Columns[5].Name = "Fri";
            dataGridView1.Columns[6].Name = "Price";
            dataGridView1.Columns[7].Name = "Total";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}
