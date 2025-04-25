namespace estudiantePOO
{
    public partial class Form1 : Form
    {
        Estudiante estudiante = new Estudiante();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                estudiante.introducirId(id);
            }

            if (double.TryParse(textBox2.Text, out double nota))
            {
                if (estudiante.introducirCalificaciones(nota))
                {
                    listBox1.Items.Add($"Calificacion {estudiante.cantidadCalificaciones()}: {nota}");
                    textBox2.Clear();
                }




            else
                {
                    MessageBox.Show("Ya se ingresaron 5 calificaciones. ");
                }

            }

            else
            {
                MessageBox.Show("Introducir una calificacion valida");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double promedio = estudiante.calcularPromedio();
            label3.Text = $"ID: {estudiante.ID} | Promedio: {promedio:F2}";

        }
    }
}
