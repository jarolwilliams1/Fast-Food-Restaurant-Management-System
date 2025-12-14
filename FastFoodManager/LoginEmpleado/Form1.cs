
using FastFoodManagerApp.Interfaces;
using FastFoodManagerApp.Services;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using FastFoodPlataformPersistencia.Repositories;
using Menu;
using Microsoft.EntityFrameworkCore;

namespace LoginEmpleado
{

    public partial class Form1 : Form
    {
        private readonly CajaService cajaService;
        private readonly IProductoService _productoService;
        private readonly ICajaService _cajaService;
        private readonly int _empleadoLogueadoId;
        private readonly ProductRepository productRepository;
        private readonly IRegistrarServices _IregistrarServices;
        private readonly RegistrarEmpleados _services;
        private readonly EmployeeRepository _employeeRepository;
        private readonly FastFoodManagerDBContext _dbContext;
        private readonly IPromocionService promocionService;
        int empleadoLogueadoId = 1;

        // private Empleado emp = new Empleado();




        //private bool VerContraseña = false;



        public Form1()
        {

            InitializeComponent();
            _dbContext = new FastFoodManagerDBContext();
            _employeeRepository = new EmployeeRepository(_dbContext);
            _services = new RegistrarEmpleados(_employeeRepository);
        }
        


      

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            var ususario = textBox1.Text.Trim();
            var contraseña = textBox2.Text.Trim();
            RegistrarEmpleados logear = new RegistrarEmpleados(_employeeRepository);
            bool v = logear.IntentarLogin(ususario, contraseña);

            if (!v)
            {
                this.Hide();
                Menus menu = new Menus((IProductoService)promocionService, (ICajaService)_productoService, (IPedidoService)cajaService, empleadoLogueadoId); ;
                menu.Show();
            }
            else if (!v)
            {
                MessageBox.Show("ususario o contraseña incorrecto");
            }
            //var contraseña = textBox2.Show;
            //var  contraseña = "";

            //VerContraseña = true; 

            //if (VerContraseña)
            //{
            //    textBox2.PasswordChar = '*';
            //    VerContraseña = false;
            //}


        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //var  ResgistarNuevos = new ResgistarNuevos();
            //var ren = ResgistarNuevos.ActiveForm;
           this.Hide();

            var ResgistarNuevos = new ResgistarNuevos();
                ResgistarNuevos.Show();

        

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
