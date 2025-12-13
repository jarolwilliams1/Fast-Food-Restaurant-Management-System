using FastFoodManagerApp.Services;
using FastFoodPlataformPersistencia.Repositories;
using Microsoft.Identity.Client;
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
    public partial class Productos : Form
    {
        private readonly ProductRepository _repo;

        public Productos(ProductRepository repo)
        {
            InitializeComponent();
            _repo = repo;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nombre = NombreProducto.Text;
            decimal precio = 0;
            decimal precioproducto = 0;
            string precioproduct = PrecioProducto.Text;
            if (decimal.TryParse(precioproduct, out precio))
            {
                precioproducto = precio;

            }
            var categoria = categoriaProducto.Text;
            bool estado = true;
            var descripcion = DescripcionProducto.Text;

            if (EstadoProducto.Text == "No Disponible")
            {
                estado = false;
            }

            if (nombre != null && precioproducto > 0 && categoria != null && descripcion != null)
            {


                var AgregarProduct = new MenuServices(_repo);
                AgregarProduct.AgregrarProducto(nombre, categoria, precioproducto, estado, descripcion);
                MessageBox.Show("Producto agregado con exito!");

            }
            else
            {
                MessageBox.Show("Ningun campo puede estar vacio");
            }


        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
