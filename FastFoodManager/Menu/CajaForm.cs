using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerApp.Services; // ✅ IMPORTANTE: Para acceder a ICajaService, CarritoItemDTO, VentaDTO

namespace Menu
{
    public partial class CajaForm : Form
    {
        private readonly ICajaService _cajaService;
        private readonly int _empleadoId;
        private readonly int _clienteId;

        private FlowLayoutPanel flowProductos;
        private FlowLayoutPanel flowCarrito;
        private Label lblTotal;
        private TextBox txtPago;
        private Label lblCambio;
        private Button btnCompletarVenta;
        private Button btnCerrar;

        private List<CarritoItemDTO> carrito = new List<CarritoItemDTO>();

        public CajaForm(ICajaService cajaService, int empleadoId, int clienteId = 1)
        {
            _cajaService = cajaService;
            _empleadoId = empleadoId;
            _clienteId = clienteId;

            InitializeComponent();
            InitializeUI();
            _ = CargarProductos();
        }

       
        private void CajaForm_Load(object sender, EventArgs e)
        {
            // Este método se ejecuta cuando el formulario se carga
            // El método async CargarPromociones() ya se llama en el constructor
        }

        // Si prefieres cargar en el Load en lugar del constructor:
        

        //private void InitializeComponent()
        //{
        //    this.Text = "Punto de Venta";
        //    this.WindowState = FormWindowState.Maximized;
        //    this.BackColor = Color.White;
        //    this.FormBorderStyle = FormBorderStyle.None;
        //}

        private void InitializeUI()
        {
            // Panel Header Rojo
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(220, 38, 38)
            };
            this.Controls.Add(headerPanel);

            Label lblTitulo = new Label
            {
                Text = "PUNTO DE VENTA",
                Location = new Point(20, 15),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White
            };
            headerPanel.Controls.Add(lblTitulo);

            btnCerrar = new Button
            {
                Text = "✕",
                Location = new Point(headerPanel.Width - 60, 10),
                Size = new Size(40, 40),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => this.Close();
            headerPanel.Controls.Add(btnCerrar);

            // Panel principal dividido
            Panel mainPanel = new Panel
            {
                Location = new Point(0, 60),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 60),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            this.Controls.Add(mainPanel);

            // Panel izquierdo - Productos
            Panel leftPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(mainPanel.Width / 2, mainPanel.Height),
                BackColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left
            };
            mainPanel.Controls.Add(leftPanel);

            Label lblProductos = new Label
            {
                Text = "PRODUCTOS",
                Location = new Point(20, 10),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };
            leftPanel.Controls.Add(lblProductos);

            flowProductos = new FlowLayoutPanel
            {
                Location = new Point(20, 50),
                Size = new Size(leftPanel.Width - 40, leftPanel.Height - 60),
                AutoScroll = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            leftPanel.Controls.Add(flowProductos);

            // Panel derecho - Carrito
            Panel rightPanel = new Panel
            {
                Location = new Point(mainPanel.Width / 2, 0),
                Size = new Size(mainPanel.Width / 2, mainPanel.Height),
                BackColor = Color.FromArgb(243, 244, 246),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right
            };
            mainPanel.Controls.Add(rightPanel);

            Label lblCarrito = new Label
            {
                Text = "CARRITO",
                Location = new Point(20, 10),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };
            rightPanel.Controls.Add(lblCarrito);

            flowCarrito = new FlowLayoutPanel
            {
                Location = new Point(20, 50),
                Size = new Size(rightPanel.Width - 40, rightPanel.Height - 300),
                AutoScroll = true,
                BackColor = Color.White,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            rightPanel.Controls.Add(flowCarrito);

            // Panel de totales
            Panel totalPanel = new Panel
            {
                Location = new Point(20, rightPanel.Height - 240),
                Size = new Size(rightPanel.Width - 40, 230),
                BackColor = Color.White,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            rightPanel.Controls.Add(totalPanel);

            Label lblTotalText = new Label
            {
                Text = "TOTAL:",
                Location = new Point(20, 20),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            totalPanel.Controls.Add(lblTotalText);

            lblTotal = new Label
            {
                Text = "$0.00",
                Location = new Point(totalPanel.Width - 120, 20),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 38, 38),
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            totalPanel.Controls.Add(lblTotal);

            Label lblPagoText = new Label
            {
                Text = "PAGO:",
                Location = new Point(20, 70),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            totalPanel.Controls.Add(lblPagoText);

            txtPago = new TextBox
            {
                Location = new Point(20, 100),
                Size = new Size(totalPanel.Width - 40, 30),
                Font = new Font("Segoe UI", 12),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            txtPago.TextChanged += TxtPago_TextChanged;
            totalPanel.Controls.Add(txtPago);

            Label lblCambioText = new Label
            {
                Text = "CAMBIO:",
                Location = new Point(20, 140),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10)
            };
            totalPanel.Controls.Add(lblCambioText);

            lblCambio = new Label
            {
                Text = "$0.00",
                Location = new Point(totalPanel.Width - 120, 140),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Green,
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            totalPanel.Controls.Add(lblCambio);

            btnCompletarVenta = new Button
            {
                Text = "COMPLETAR VENTA",
                Location = new Point(20, 180),
                Size = new Size(totalPanel.Width - 40, 40),
                BackColor = Color.FromArgb(34, 197, 94),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Enabled = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            btnCompletarVenta.FlatAppearance.BorderSize = 0;
            btnCompletarVenta.Click += BtnCompletarVenta_Click;
            totalPanel.Controls.Add(btnCompletarVenta);
        }

        private async Task CargarProductos()
        {
            try
            {
                var productos = await _cajaService.ObtenerProductosDisponiblesAsync();

                flowProductos.Controls.Clear();

                int x = 0;
                int y = 0;
                int col = 0;

                foreach (var producto in productos)
                {
                    Panel card = CrearTarjetaProducto(producto);
                    card.Location = new Point(x, y);
                    flowProductos.Controls.Add(card);

                    col++;
                    if (col == 2)
                    {
                        col = 0;
                        y += 120;
                        x = 0;
                    }
                    else
                    {
                        x += 240;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CrearTarjetaProducto(Producto producto)
        {
            Panel card = new Panel
            {
                Size = new Size(220, 100),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            Label lblNombre = new Label
            {
                Text = producto.Nombre,
                Location = new Point(10, 10),
                Size = new Size(200, 40),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            card.Controls.Add(lblNombre);

            Label lblPrecio = new Label
            {
                Text = "$" + producto.Precio.ToString("F2"),
                Location = new Point(10, 55),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 38, 38)
            };
            card.Controls.Add(lblPrecio);

            Button btnAgregar = new Button
            {
                Text = "+",
                Location = new Point(170, 50),
                Size = new Size(40, 40),
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.Click += (s, e) => AgregarAlCarrito(producto);
            card.Controls.Add(btnAgregar);

            return card;
        }

        private void AgregarAlCarrito(Producto producto)
        {
            var itemExistente = carrito.FirstOrDefault(i => i.ProductoId == producto.Id);

            if (itemExistente != null)
            {
                itemExistente.Cantidad++;
            }
            else
            {
                carrito.Add(new CarritoItemDTO
                {
                    ProductoId = producto.Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Cantidad = 1
                });
            }

            ActualizarCarrito();
        }

        private void ActualizarCarrito()
        {
            flowCarrito.Controls.Clear();

            int y = 0;
            foreach (var item in carrito)
            {
                Panel itemPanel = CrearItemCarrito(item);
                itemPanel.Location = new Point(0, y);
                flowCarrito.Controls.Add(itemPanel);
                y += 70;
            }

            ActualizarTotales();
        }

        private Panel CrearItemCarrito(CarritoItemDTO item)
        {
            Panel panel = new Panel
            {
                Size = new Size(flowCarrito.Width - 25, 60),
                BackColor = Color.FromArgb(249, 250, 251),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblNombre = new Label
            {
                Text = item.Nombre,
                Location = new Point(10, 10),
                Size = new Size(200, 20),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            panel.Controls.Add(lblNombre);

            Label lblPrecio = new Label
            {
                Text = "$" + item.Precio.ToString("F2"),
                Location = new Point(10, 30),
                Size = new Size(80, 20),
                Font = new Font("Segoe UI", 8)
            };
            panel.Controls.Add(lblPrecio);

            Label lblCantidad = new Label
            {
                Text = "x" + item.Cantidad,
                Location = new Point(100, 30),
                Size = new Size(50, 20),
                Font = new Font("Segoe UI", 8)
            };
            panel.Controls.Add(lblCantidad);

            Label lblSubtotal = new Label
            {
                Text = "$" + item.Subtotal.ToString("F2"),
                Location = new Point(panel.Width - 100, 20),
                Size = new Size(80, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 38, 38),
                TextAlign = ContentAlignment.MiddleRight
            };
            panel.Controls.Add(lblSubtotal);

            Button btnEliminar = new Button
            {
                Text = "✕",
                Location = new Point(panel.Width - 35, 15),
                Size = new Size(25, 25),
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Click += (s, e) => EliminarDelCarrito(item);
            panel.Controls.Add(btnEliminar);

            return panel;
        }

        private void EliminarDelCarrito(CarritoItemDTO item)
        {
            carrito.Remove(item);
            ActualizarCarrito();
        }

        private void ActualizarTotales()
        {
            decimal total = _cajaService.CalcularTotal(carrito);
            lblTotal.Text = "$" + total.ToString("F2");

            if (decimal.TryParse(txtPago.Text, out decimal pago))
            {
                decimal cambio = _cajaService.CalcularCambio(total, pago);
                lblCambio.Text = "$" + cambio.ToString("F2");
                btnCompletarVenta.Enabled = _cajaService.ValidarPago(total, pago);
            }
            else
            {
                lblCambio.Text = "$0.00";
                btnCompletarVenta.Enabled = false;
            }
        }

        private void TxtPago_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        private async void BtnCompletarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!carrito.Any())
                {
                    MessageBox.Show("El carrito está vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPago.Text, out decimal montoPagado))
                {
                    MessageBox.Show("Ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal total = _cajaService.CalcularTotal(carrito);
                decimal cambio = _cajaService.CalcularCambio(total, montoPagado);

                var venta = new VentaDTO
                {
                    EmpleadoId = _empleadoId,
                    ClienteId = _clienteId,
                    Items = carrito,
                    Total = total,
                    MontoPagado = montoPagado,
                    Cambio = cambio
                };

               // int pedidoId = await _cajaService.CompletarVentaAsync(venta);

                MessageBox.Show(
                    $"Venta completada exitosamente!\n\n" +
                    $"Pedido #: \n" +
                    $"Total: ${total:F2}\n" +
                    $"Pagado: ${montoPagado:F2}\n" +
                    $"Cambio: ${cambio:F2}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Limpiar
                carrito.Clear();
                txtPago.Clear();
                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al completar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //}
    }
}