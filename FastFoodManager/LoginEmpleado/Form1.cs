
using FastFoodAplication.Services;

namespace LoginEmpleado
{
    public partial class Form1 : Form
    {
        public Form1()
        {

        InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Recolectas los datos de la UI
            string usuario = textBox1.Text;
            string contraseña = textBox2.Text;

            // 2. Creas la instancia del servicio AQUÍ MISMO (Hardcodeado)
            // Esto es la conexión directa:
            RegistrarEmpleados miServicio = new RegistrarEmpleados();

            // 3. Llamas al método del servicio
            miServicio.Registrar(usuario, contraseña);

            MessageBox.Show("Guardado!");
        }
    }
}
