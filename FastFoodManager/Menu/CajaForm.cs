using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerApp.Services;

namespace Menu
{
    public partial class CajaForm : Form
    {
        private readonly ICajaService _cajaService;
        private List<CarritoItemDTO> cart;
        private int empleadoId;
        private int clienteId;

        // Controles de la interfaz
        private Panel panelHeader;
        private Panel panelProductos;
        private FlowLayoutPanel flowCarrito;
        private Label lblTotal;
        private TextBox txtPago;
        private Label lblCambio;
        private Button btnCompletarVenta;
        private Label lblCarritoVacio;

        public CajaForm(ICajaService cajaService, int empleadoId, int clienteId = 1)
        {
            InitializeComponent();
            _cajaService = cajaService;
            this.empleadoId = empleadoId;
            this.clienteId = clienteId;
            cart = new List<CarritoItemDTO>();
        }

        private async void CajaForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            await LoadProductsFromService();
            UpdateCart();
        }

        //private void InitializeComponent()
        //{
        //    this.Text = "Caja";
        //    this.WindowState = FormWindowState.Maximized;
        //    this.BackColor = Color.FromArgb(245, 245, 245);
        //    this.FormBorderStyle = FormBorderStyle.None;
        //}

        private void InitializeUI()
        {
            // Header rojo
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(220, 20, 60)
            };
            this.Controls.Add(panelHeader);

            Label lblTitulo = new Label
            {
                Text = "Caja",
                Location = new Point(30, 25),
                Size = new Size(200, 35),
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White
            };
            panelHeader.Controls.Add(lblTitulo);

            Button btnCerrar = new Button
            {
                Text = "✕",
                Location = new Point(this.Width - 70, 20),
                Size = new Size(40, 40),
                BackColor = Color.FromArgb(220, 20, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => this.Close();
            panelHeader.Controls.Add(btnCerrar);

            // Panel izquierdo - Productos
            Panel panelIzquierdo = new Panel
            {
                Location = new Point(0, 80),
                Size = new Size(this.Width / 2, this.Height - 80),
                BackColor = Color.White,
                Padding = new Padding(20)
            };
            this.Controls.Add(panelIzquierdo);

            Label lblProductos = new Label
            {
                Text = "Productos",
                Location = new Point(30, 20),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black
            };
            panelIzquierdo.Controls.Add(lblProductos);

            panelProductos = new Panel
            {
                Location = new Point(20, 60),
                Size = new Size(panelIzquierdo.Width - 40, panelIzquierdo.Height - 80),
                AutoScroll = true,
                BackColor = Color.White
            };
            panelIzquierdo.Controls.Add(panelProductos);

            // Panel derecho - Carrito
            Panel panelDerecho = new Panel
            {
                Location = new Point(this.Width / 2, 80),
                Size = new Size(this.Width / 2, this.Height - 80),
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(20)
            };
            this.Controls.Add(panelDerecho);

            Label lblCarritoTitulo = new Label
            {
                Text = "Carrito",
                Location = new Point(30, 20),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black
            };
            panelDerecho.Controls.Add(lblCarritoTitulo);

            // Área de carrito con scroll
            Panel areaCarrito = new Panel
            {
                Location = new Point(20, 60),
                Size = new Size(panelDerecho.Width - 40, 300),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
            panelDerecho.Controls.Add(areaCarrito);

            // FlowLayoutPanel para items del carrito
            flowCarrito = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(10)
            };
            areaCarrito.Controls.Add(flowCarrito);

            // Label "Carrito vacío"
            lblCarritoVacio = new Label
            {
                Text = "Carrito vacío",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                ForeColor = Color.Gray
            };
            flowCarrito.Controls.Add(lblCarritoVacio);

            // Panel Total
            Panel panelTotal = new Panel
            {
                Location = new Point(20, 370),
                Size = new Size(panelDerecho.Width - 40, 100),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            panelDerecho.Controls.Add(panelTotal);

            Label lblTotalLabel = new Label
            {
                Text = "Total a Pagar",
                Location = new Point(20, 15),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            panelTotal.Controls.Add(lblTotalLabel);

            lblTotal = new Label
            {
                Text = "$0.00",
                Location = new Point(20, 45),
                Size = new Size(300, 35),
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 0)
            };
            panelTotal.Controls.Add(lblTotal);

            // Panel Pago
            Panel panelPago = new Panel
            {
                Location = new Point(20, 480),
                Size = new Size(panelDerecho.Width - 40, 200),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            panelDerecho.Controls.Add(panelPago);

            Label lblPagoTitulo = new Label
            {
                Text = "Pago",
                Location = new Point(20, 15),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            panelPago.Controls.Add(lblPagoTitulo);

            Label lblMontoRecibido = new Label
            {
                Text = "Monto Recibido:",
                Location = new Point(20, 50),
                Size = new Size(150, 20),
                Font = new Font("Segoe UI", 10)
            };
            panelPago.Controls.Add(lblMontoRecibido);

            txtPago = new TextBox
            {
                Location = new Point(20, 75),
                Size = new Size(panelPago.Width - 40, 30),
                Font = new Font("Segoe UI", 12),
                Text = "0.00"
            };
            txtPago.TextChanged += TxtPago_TextChanged;
            panelPago.Controls.Add(txtPago);

            lblCambio = new Label
            {
                Text = "Cambio: $0.00",
                Location = new Point(20, 110),
                Size = new Size(panelPago.Width - 40, 25),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            panelPago.Controls.Add(lblCambio);

            btnCompletarVenta = new Button
            {
                Text = "Completar Venta",
                Location = new Point(20, 145),
                Size = new Size(panelPago.Width - 40, 40),
                BackColor = Color.FromArgb(180, 180, 180),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Enabled = false,
                Cursor = Cursors.Hand
            };
            btnCompletarVenta.FlatAppearance.BorderSize = 0;
            btnCompletarVenta.Click += BtnCompletarVenta_Click;
            panelPago.Controls.Add(btnCompletarVenta);
        }

        private async System.Threading.Tasks.Task LoadProductsFromService()
        {
            try
            {
                var productos = await _cajaService.ObtenerProductosDisponiblesAsync();

                int x = 10, y = 10;
                int col = 0;
                int buttonWidth = 320;
                int buttonHeight = 80;

                foreach (var producto in productos)
                {
                    Panel btnProducto = new Panel
                    {
                        Location = new Point(x, y),
                        Size = new Size(buttonWidth, buttonHeight),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = Cursors.Hand,
                        Tag = producto
                    };

                    Label lblNombre = new Label
                    {
                        Text = producto.Nombre,
                        Location = new Point(15, 15),
                        Size = new Size(buttonWidth - 30, 35),
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    btnProducto.Controls.Add(lblNombre);

                    Label lblPrecio = new Label
                    {
                        Text = "$" + producto.Precio.ToString("0.00"),
                        Location = new Point(15, 50),
                        Size = new Size(buttonWidth - 30, 20),
                        Font = new Font("Segoe UI", 10),
                        ForeColor = Color.FromArgb(0, 150, 0)
                    };
                    btnProducto.Controls.Add(lblPrecio);

                    btnProducto.Click += (s, e) => BtnProducto_Click(producto);
                    lblNombre.Click += (s, e) => BtnProducto_Click(producto);
                    lblPrecio.Click += (s, e) => BtnProducto_Click(producto);

                    panelProductos.Controls.Add(btnProducto);

                    col++;
                    if (col == 2)
                    {
                        col = 0;
                        y += buttonHeight + 10;
                        x = 10;
                    }
                    else
                    {
                        x += buttonWidth + 10;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProducto_Click(Producto producto)
        {
            var existingItem = cart.FirstOrDefault(item => item.ProductoId == producto.Id);
            if (existingItem != null)
            {
                existingItem.Cantidad++;
            }
            else
            {
                cart.Add(new CarritoItemDTO
                {
                    ProductoId = producto.Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Cantidad = 1
                });
            }

            UpdateCart();
        }

        private void UpdateCart()
        {
            flowCarrito.Controls.Clear();

            if (cart.Count == 0)
            {
                lblCarritoVacio.Visible = true;
                flowCarrito.Controls.Add(lblCarritoVacio);
            }
            else
            {
                lblCarritoVacio.Visible = false;

                foreach (var item in cart)
                {
                    Panel itemPanel = new Panel
                    {
                        Size = new Size(flowCarrito.Width - 30, 70),
                        BackColor = Color.FromArgb(250, 250, 250),
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(0, 0, 0, 5)
                    };

                    Label lblNombre = new Label
                    {
                        Text = item.Nombre,
                        Location = new Point(10, 10),
                        Size = new Size(itemPanel.Width - 100, 20),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    };
                    itemPanel.Controls.Add(lblNombre);

                    Label lblDetalle = new Label
                    {
                        Text = $"${item.Precio:0.00} x {item.Cantidad} = ${item.Subtotal:0.00}",
                        Location = new Point(10, 35),
                        Size = new Size(itemPanel.Width - 100, 20),
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gray
                    };
                    itemPanel.Controls.Add(lblDetalle);

                    Button btnEliminar = new Button
                    {
                        Text = "✕",
                        Location = new Point(itemPanel.Width - 40, 20),
                        Size = new Size(30, 30),
                        BackColor = Color.FromArgb(220, 20, 60),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Cursor = Cursors.Hand,
                        Tag = item
                    };
                    btnEliminar.FlatAppearance.BorderSize = 0;
                    btnEliminar.Click += (s, e) =>
                    {
                        cart.Remove(item);
                        UpdateCart();
                    };
                    itemPanel.Controls.Add(btnEliminar);

                    flowCarrito.Controls.Add(itemPanel);
                }
            }

            decimal total = _cajaService.CalcularTotal(cart);
            lblTotal.Text = "$" + total.ToString("0.00");

            CalculateCambio();
        }

        private void TxtPago_TextChanged(object sender, EventArgs e)
        {
            CalculateCambio();
        }

        private void CalculateCambio()
        {
            decimal total = _cajaService.CalcularTotal(cart);
            decimal pago = 0;

            if (decimal.TryParse(txtPago.Text, out pago))
            {
                decimal cambio = _cajaService.CalcularCambio(total, pago);
                lblCambio.Text = "Cambio: $" + Math.Abs(cambio).ToString("0.00");
                lblCambio.ForeColor = cambio >= 0 ? Color.Green : Color.Red;

                bool canComplete = _cajaService.ValidarPago(total, pago) && cart.Count > 0;
                btnCompletarVenta.Enabled = canComplete;
                btnCompletarVenta.BackColor = canComplete ?
                    Color.FromArgb(0, 150, 0) : Color.FromArgb(180, 180, 180);
            }
            else
            {
                lblCambio.Text = "Cambio: $0.00";
                btnCompletarVenta.Enabled = false;
                btnCompletarVenta.BackColor = Color.FromArgb(180, 180, 180);
            }
        }

        private async void BtnCompletarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = _cajaService.CalcularTotal(cart);
                decimal montoPagado = decimal.Parse(txtPago.Text);

                var venta = new VentaDTO
                {
                    ClienteId = clienteId,
                    EmpleadoId = empleadoId,
                    Items = cart,
                    Total = total,
                    MontoPagado = montoPagado,
                    Cambio = _cajaService.CalcularCambio(total, montoPagado)
                };

                string codigoPedido = await _cajaService.CompletarVentaAsync(venta);

                MessageBox.Show($"¡Venta completada exitosamente!\n\nCódigo: {codigoPedido}\nCambio: ${venta.Cambio:0.00}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cart.Clear();
                txtPago.Text = "0.00";
                UpdateCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al completar la venta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}