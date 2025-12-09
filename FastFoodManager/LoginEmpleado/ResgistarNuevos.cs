using FastFoodManagerApp.Interfaces;
using FastFoodManagerApp.Services;
using FastFoodPlataformPersistencia.Context;
using FastFoodPlataformPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginEmpleado
{
    public partial class ResgistarNuevos : Form
    {
        
        //private readonly IRegistrarServices _servicio;
        private readonly FastFoodManagerDBContext _context;
        private readonly EmployeeRepository _repo;
       private readonly RegistrarEmpleados _servicio;
        public ResgistarNuevos()
        {
            InitializeComponent();
            //_servicio = servicio;
            _context = new FastFoodManagerDBContext();
            _repo = new EmployeeRepository(_context);
            _servicio = new RegistrarEmpleados(_repo);
        }

        private void ResgistarNuevos_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NombreNuevoUusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool confirmar = false;
            var Name = NombreNuevoUusuario.Text;
            var apellido = ApellidoNuevoUusuario.Text;
            var Pasword = ContraseñaNuevoUusuario.Text;
            var Rol = RolNuevoUusuario.Text;
            var usuario = UsuarioNuevoUusuario.Text;

            _servicio.Registrar( Name,  apellido,  Pasword,  Rol,  usuario, ref confirmar);

            if (confirmar)
            {
                MessageBox.Show("Empleado creado con exito");
                this.Hide();
                var Iniciar = new Form1();
                Iniciar.Show();


            }
            else
            {
                MessageBox.Show("No se puedo crear el empleado");

            }


        }
    }
}
