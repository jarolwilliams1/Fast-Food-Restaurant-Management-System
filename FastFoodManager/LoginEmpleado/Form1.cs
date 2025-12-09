
using FastFoodManagerApp.Interfaces;
using FastFoodManagerApp.Services;
using FastFoodPlataformPersistencia.Context;
using FastFoodPlataformPersistencia.Repositories;

namespace LoginEmpleado
{
    public partial class Form1 : Form
    {
        private readonly IRegistrarServices _registrarServices;
       

        //private bool VerContraseña = false;



        public Form1()
        {

            InitializeComponent();
            //_registrarServices = servicio;

        }


        private void button1_Click(object sender, EventArgs e)
        {

           
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
            //var contraseña = textBox2.Show;
            //var  contraseña = "";
            var contraseña = textBox2.Text.ToString();
            textBox2.Text = contraseña;
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

           // Application.Exit();




            //this.Hide();


            //this.Hide();
            //bool verEste = true;


            //this.Show();



            //this.Show();
            // ResgistarNuevos.ActiveForm

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
