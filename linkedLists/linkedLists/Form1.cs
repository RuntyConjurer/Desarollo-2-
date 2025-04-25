using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace linkedLists
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string itemMove = listBox1.SelectedItem.ToString();
                listBox2.Items.Add(itemMove);
                listBox1.Items.Remove(itemMove);
                SortOrderedList();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string nuevoElemento = textBox2.Text;
            if (!string.IsNullOrEmpty(nuevoElemento))
            {
                listBox2.Items.Add(nuevoElemento);
                SortOrderedList();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string itemMove2 = listBox2.SelectedItem.ToString();
                listBox1.Items.Add(itemMove2);
                listBox2.Items.Remove(itemMove2);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }
        private void SortOrderedList()
        {
            var items = new List<string>();
            foreach (var item in listBox2.Items)
            {
                items.Add(item.ToString());
            }
            items.Sort();
            listBox2.Items.Clear();
            foreach (var item in items)
            {
                listBox2.Items.Add(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }
    }
}
