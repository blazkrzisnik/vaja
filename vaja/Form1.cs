using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vaja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 75;
            dataGridView1.Rows.Add(Image.FromFile("images (1).png"), "Bitcoin", "BTC", 50000, 0.5, 25000, "Uredi");
            dataGridView1.Rows.Add(Image.FromFile("images (2).png"), "Ethereum", "ETH", 4000, 2, 8000, "Uredi");
        }

        private void kupiNovoKriptovalutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 podobrazec = new Form2();
            if (podobrazec.ShowDialog() == DialogResult.OK)
            {
                // Add new cryptocurrency to the DataGridView
                string name = podobrazec.comboBox1.SelectedItem.ToString();
                string[] kratica = name.Split(' ');
                string naziv = kratica[0];
                string kraticaValute = kratica[1];
                dataGridView1.Rows.Add(podobrazec.pictureBox1.Image,naziv,kraticaValute, podobrazec.textBox1.Text, podobrazec.textBox2.Text, podobrazec.textBox3.Text, "Uredi");
            }
            
        }

        private void skupnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double znesek = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                znesek += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }   
            MessageBox.Show("Skupna vrednost portfelja: " + znesek.ToString() + " USD");
        }
    }
}
