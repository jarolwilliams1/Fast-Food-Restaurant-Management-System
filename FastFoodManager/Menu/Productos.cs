using System;
using System.Windows.Forms;
using FastFoodManagerApp.Services;

namespace Menu
{
    public partial class Productos : Form
    {
        // ✅ CORRECTO: Usar SERVICIO, no repositorio
        private readonly IProductoService _productoService;

        // Constructor con inyección de dependencias del SERVICIO
        public Productos(IProductoService productoService)
        {
            InitializeComponent();
            _productoService = productoService;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar/Ocultar el formulario de agregar producto
            groupBox1.Visible = !groupBox1.Visible;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores de los controles
                string nombre = NombreProducto.Text.Trim();
                string precioproduct = PrecioProducto.Text.Trim();
                string categoria = categoriaProducto.Text.Trim();
                string descripcion = DescripcionProducto.Text.Trim();
                string estadoTexto = EstadoProducto.Text.Trim();

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre del producto no puede estar vacío",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NombreProducto.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(precioproduct))
                {
                    MessageBox.Show("El precio del producto no puede estar vacío",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PrecioProducto.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(categoria))
                {
                    MessageBox.Show("La categoría del producto no puede estar vacía",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    categoriaProducto.Focus();
                    return;
                }

                // Convertir precio
                if (!decimal.TryParse(precioproduct, out decimal precio))
                {
                    MessageBox.Show("El precio debe ser un número válido",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PrecioProducto.Focus();
                    return;
                }

                if (precio <= 0)
                {
                    MessageBox.Show("El precio debe ser mayor a cero",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PrecioProducto.Focus();
                    return;
                }

                // Determinar estado de disponibilidad
                bool disponible = estadoTexto != "No Disponible";

                // ✅ USAR EL SERVICIO para agregar el producto
                bool resultado = await _productoService.AgregarProductoAsync(
                    nombre,
                    categoria,
                    precio,
                    descripcion,
                    disponible
                );

                if (resultado)
                {
                    MessageBox.Show("¡Producto agregado con éxito!",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar campos
                    LimpiarCampos();

                    // Ocultar el groupbox
                    groupBox1.Visible = false;

                    // Opcional: Recargar lista de productos si tienes un DataGridView
                    // await CargarProductosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario sin guardar
            groupBox1.Visible = false;
            LimpiarCampos();
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private async void Productos_Load(object sender, EventArgs e)
        {
            try
            {
                // Opcional: Cargar productos existentes al iniciar el formulario
                // await CargarProductosAsync();

                // Opcional: Cargar categorías en un ComboBox si lo tienes
                // await CargarCategoriasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            NombreProducto.Clear();
            PrecioProducto.Clear();
            categoriaProducto.Text = "";
            DescripcionProducto.Clear();
            EstadoProducto.Text = "Disponible"; // o el valor por defecto que tengas
        }

        // Opcional: Si tienes un DataGridView para mostrar productos
        private async System.Threading.Tasks.Task CargarProductosAsync()
        {
            try
            {
                var productos = await _productoService.ObtenerTodosProductosAsync();

                // Si tienes un DataGridView:
                // dataGridViewProductos.DataSource = null;
                // dataGridViewProductos.DataSource = productos;

                // O si tienes un ListBox:
                // listBoxProductos.DataSource = null;
                // listBoxProductos.DataSource = productos;
                // listBoxProductos.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar productos: {ex.Message}");
            }
        }

        // Opcional: Si quieres cargar las categorías en un ComboBox
        private async System.Threading.Tasks.Task CargarCategoriasAsync()
        {
            try
            {
                var categorias = await _productoService.ObtenerCategoriasAsync();

                // Si tienes un ComboBox de categorías:
                // comboBoxCategorias.DataSource = null;
                // comboBoxCategorias.DataSource = categorias;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar categorías: {ex.Message}");
            }
        }
    }
}
