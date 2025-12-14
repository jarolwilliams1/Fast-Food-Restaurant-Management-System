using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hola");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           // groupBox1.Visible = false;
            // groupBox1.Validated = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
             

            //if (!groupBox1.Visible)
            //{
            //    groupBox1.Visible = true;

            //}
            //else
            //{
            //    groupBox1.Visible = false;
            //}

            //if (!groupBox1.Bounds.Contains(this.PointToClient(Cursor.Position)))
            //{
            //    groupBox1.Visible = true;
            //}
            groupBox1.Visible = !groupBox1.Visible;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
