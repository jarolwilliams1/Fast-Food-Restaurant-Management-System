using FastFoodManagerApp.Services;
using FastFoodManagerPlataformDomain.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Menu
{
    public partial class Pedidos : Form
    {
        private readonly IPedidoService _pedidoService;
        private readonly int _empleadoId;

        // Controles principales
        private Panel panelOrders;
        private Button btnNuevoPedido;
        private Panel panelFormulario;

        // Controles del formulario
        private TextBox txtNumeroOrden;
        private TextBox txtTotal;
        private TextBox txtItems;
        private Button btnGuardar;
        private Button btnCancelar;

        // Nuevos Controles de Diseño
        private Panel panelHeader;
        private Label lblMainTitle;
        private Button btnClose;


        public Pedidos(IPedidoService pedidoService, int empleadoId = 1)
        {
            _pedidoService = pedidoService;
            _empleadoId = empleadoId;
            InitializeComponent();
            this.Text = "Gestión de Pedidos";
            this.Size = new Size(1400, 800);
            this.BackColor = Color.White;
            this.AutoScroll = false; // Cambiado a False para controlar el scroll del panel de pedidos
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // Quitar la barra de título por defecto para usar la custom

            InitializeModernUI();
            this.Load += Pedidos_Load;
        }



        private async void Pedidos_Load(object sender, EventArgs e)
        {
            await CargarPedidosAsync();
        }

        private void InitializeModernUI()
        {
            // --- 1. BARRA DE TÍTULO ROJA (Header) ---
            panelHeader = new Panel
            {
                BackColor = Color.FromArgb(220, 38, 38),
                Dock = DockStyle.Top,
                Height = 40,
                Location = new Point(0, 0)
            };
            this.Controls.Add(panelHeader);

            lblMainTitle = new Label
            {
                Text = "Gestión de Pedidos",
                Location = new Point(10, 8),
                Size = new Size(300, 25),
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            panelHeader.Controls.Add(lblMainTitle);

            // Botón de Cerrar (X)
            btnClose = new Button
            {
                Text = "✕",
                Size = new Size(40, 40),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Dock = DockStyle.Right;
            btnClose.Click += (s, e) => this.Close();
            panelHeader.Controls.Add(btnClose);

            // --- 2. CONTENIDO PRINCIPAL (Debajo del Header, Margen Superior de 40px) ---

            // Título Principal
            Label lblTitle = new Label
            {
                Text = "Gestión de Pedidos",
                Location = new Point(20, 60), // Y ajustado para dejar espacio al panelHeader (40) + margen
                Size = new Size(400, 30),
                Font = new Font("Arial", 15, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(lblTitle);

            Label lblSubtitle = new Label
            {
                Text = "Administra todos los pedidos activos",
                Location = new Point(20, 90),
                Size = new Size(400, 20),
                ForeColor = Color.Gray,
                Font = new Font("Arial", 10)
            };
            this.Controls.Add(lblSubtitle);

            // Botón Nuevo Pedido 
            btnNuevoPedido = new Button
            {
                Text = "+ Nuevo Pedido",
                Location = new Point(this.ClientSize.Width - 200, 70), // Reposicionado
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                Font = new Font("Arial", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnNuevoPedido.FlatAppearance.BorderSize = 0;
            btnNuevoPedido.Click += BtnNuevoPedido_Click;
            this.Controls.Add(btnNuevoPedido);

            // Panel del formulario (inicialmente oculto)
            CrearPanelFormulario();

            // Panel de pedidos (ajustado el Y y el tamaño inicial)
            panelOrders = new Panel
            {
                Location = new Point(20, 130), // Y inicial ajustado
                Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 150),
                BorderStyle = BorderStyle.None,
                AutoScroll = true,
                BackColor = Color.White
            };
            this.Controls.Add(panelOrders);
        }

        private void CrearPanelFormulario()
        {
            panelFormulario = new Panel
            {
                Location = new Point(20, 130), // Y inicial ajustado
                Size = new Size(this.ClientSize.Width - 40, 260), // Mayor altura para acomodar todos los campos
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Visible = false
            };
            this.Controls.Add(panelFormulario);
            panelFormulario.BringToFront();

            // Título del formulario
            Label lblFormTitle = new Label
            {
                Text = "Crear Nuevo Pedido",
                Location = new Point(20, 15),
                Size = new Size(250, 25),
                Font = new Font("Arial", 13, FontStyle.Bold)
            };
            panelFormulario.Controls.Add(lblFormTitle);

            // Número de Orden
            txtNumeroOrden = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(400, 30),
                Font = new Font("Arial", 11),
                PlaceholderText = "Número de orden"
            };
            panelFormulario.Controls.Add(txtNumeroOrden);

            // Total
            txtTotal = new TextBox
            {
                Location = new Point(440, 50), // Separado a la derecha de Número de orden
                Size = new Size(400, 30),
                Font = new Font("Arial", 11),
                PlaceholderText = "Total"
            };
            panelFormulario.Controls.Add(txtTotal);

            // Items del pedido (TextBox Multilínea Grande)
            txtItems = new TextBox
            {
                Location = new Point(20, 95),
                Size = new Size(panelFormulario.Width - 40, 90), // Mucha más altura
                Font = new Font("Arial", 10),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                PlaceholderText = "Items del pedido (uno por línea)"
            };
            panelFormulario.Controls.Add(txtItems);

            // Botones del formulario
            btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(20, 195), // Posicionado debajo de Items
                Size = new Size(110, 35),
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;
            panelFormulario.Controls.Add(btnGuardar);

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(140, 195), // Al lado de Guardar
                Size = new Size(110, 35),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += BtnCancelar_Click;
            panelFormulario.Controls.Add(btnCancelar);
        }

        private void BtnNuevoPedido_Click(object sender, EventArgs e)
        {
            panelFormulario.Visible = !panelFormulario.Visible;
            int formHeight = panelFormulario.Height; // 260px

            if (panelFormulario.Visible)
            {
                // Mover el panel de pedidos hacia abajo
                panelOrders.Location = new Point(20, 130 + formHeight + 10);
                panelOrders.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - (130 + formHeight + 20));
            }
            else
            {
                // Restaurar la posición y tamaño original
                panelOrders.Location = new Point(20, 130);
                panelOrders.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 150);
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // LÓGICA DE NEGOCIO (SIN MODIFICAR)

                // Validaciones
                if (string.IsNullOrWhiteSpace(txtNumeroOrden.Text))
                {
                    MessageBox.Show("El número de orden no puede estar vacío",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTotal.Text) || !decimal.TryParse(txtTotal.Text, out decimal total))
                {
                    MessageBox.Show("Ingrese un total válido",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtItems.Text))
                {
                    MessageBox.Show("Debe agregar al menos un item",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Separar items por comas o saltos de línea
                var itemsLista = txtItems.Text
                    .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim())
                    .Where(i => !string.IsNullOrWhiteSpace(i))
                    .ToList();

                // Crear el DTO
                var nuevoPedido = new CrearPedidoDTO
                {
                    NumeroOrden = txtNumeroOrden.Text.Trim(),
                    ItemsTexto = itemsLista,
                    Total = total,
                    ClienteId = 1, // Cliente genérico
                    EmpleadoId = _empleadoId
                };

                // Guardar en la base de datos
               // string codigoPedido = await _pedidoService.CrearNuevoPedidoAsync(nuevoPedido);

                string codigoPedido = nuevoPedido.NumeroOrden.StartsWith("#")
    ? nuevoPedido.NumeroOrden
    : $"#{nuevoPedido.NumeroOrden}";

                var pedido = new Pedido
                {
                    Fecha = DateTime.Now,
                    ClienteId = nuevoPedido.ClienteId,
                    EmpleadoId = nuevoPedido.EmpleadoId,
                    Total = nuevoPedido.Total,
                    Estado = "Pendiente",
                };
                var p = new PedidoItem() {
                    CodigoPedido = codigoPedido   // ← CLAVE
                };



                MessageBox.Show($"¡Pedido {codigoPedido} creado exitosamente!",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar formulario y ocultar
                LimpiarFormulario();
                panelFormulario.Visible = false;
                panelOrders.Location = new Point(20, 130);
                panelOrders.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 150);

                // Recargar pedidos
                await CargarPedidosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear pedido: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // LÓGICA DE NEGOCIO (SIN MODIFICAR)
            LimpiarFormulario();
            panelFormulario.Visible = false;
            panelOrders.Location = new Point(20, 130);
            panelOrders.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 150);
        }

        private void LimpiarFormulario()
        {
            // LÓGICA DE NEGOCIO (SIN MODIFICAR)
            txtNumeroOrden.Clear();
            txtTotal.Clear();
            txtItems.Clear();
        }

        private async System.Threading.Tasks.Task CargarPedidosAsync()
        {
            // LÓGICA DE NEGOCIO
            try
            {
                panelOrders.Controls.Clear();
                Label lblCargando = new Label
                {
                    Text = "Cargando pedidos...",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 12),
                    ForeColor = Color.Gray
                };
                panelOrders.Controls.Add(lblCargando);

                var pedidos = await _pedidoService.ObtenerPedidosDelDiaAsync();
                RenderOrders(pedidos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pedidos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderOrders(List<PedidoDTO> pedidos)
        {
            // LÓGICA DE NEGOCIO 
            panelOrders.Controls.Clear();

            if (pedidos == null || pedidos.Count == 0)
            {
                Label lblVacio = new Label
                {
                    Text = "No hay pedidos para mostrar",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 12),
                    ForeColor = Color.Gray
                };
                panelOrders.Controls.Add(lblVacio);
                return;
            }

            // AJUSTE DE COLUMNAS (MANTENER 2 COLUMNAS POR FILA)
            int y = 10;
            int x = 10;
            int col = 0;
            // Redefinir el ancho de la tarjeta
            int cardWidth = (panelOrders.Width / 2) - 15;

            foreach (var pedido in pedidos)
            {
                Panel orderCard = CreateOrderCard(pedido, cardWidth);
                orderCard.Location = new Point(x, y);
                panelOrders.Controls.Add(orderCard);

                col++;
                if (col == 2)
                {
                    col = 0;
                    y += 210;
                    x = 10;
                }
                else
                {
                    x += cardWidth + 10;
                }
            }
        }

        // Diseño de la tarjeta de pedido (ajustado para la imagen final)
        private Panel CreateOrderCard(PedidoDTO pedido, int width)
        {
            Panel card = new Panel
            {
                Size = new Size(width, 200),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Número de orden
            Label lblOrderNum = new Label
            {
                Text = pedido.CodigoPedido,
                Location = new Point(15, 15),
                Size = new Size(150, 30),
                Font = new Font("Arial", 16, FontStyle.Bold)
            };
            card.Controls.Add(lblOrderNum);

            // Hora
            Label lblTime = new Label
            {
                Text = "🕐 " + pedido.Hora, // Volvemos a incluir el emoji para más detalle
                Location = new Point(15, 45),
                Size = new Size(150, 20),
                ForeColor = Color.Gray,
                Font = new Font("Arial", 10)
            };
            card.Controls.Add(lblTime);

            // Estado (Etiqueta de color)
            Label lblStatus = new Label
            {
                Text = pedido.Estado,
                Location = new Point(card.Width - 145, 15),
                Size = new Size(130, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold),
                BorderStyle = BorderStyle.None
            };
            lblStatus.Padding = new Padding(5, 5, 5, 5);

            switch (pedido.Estado)
            {
                case "Pendiente":
                    lblStatus.BackColor = Color.FromArgb(254, 249, 195);
                    lblStatus.ForeColor = Color.FromArgb(161, 98, 7);
                    break;
                case "Preparando":
                case "En Preparación":
                    lblStatus.BackColor = Color.FromArgb(219, 234, 254);
                    lblStatus.ForeColor = Color.FromArgb(30, 64, 175);
                    break;
                case "Listo":
                    lblStatus.BackColor = Color.FromArgb(220, 252, 231);
                    lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                    break;
                case "Entregado":
                case "Completado":
                    lblStatus.BackColor = Color.FromArgb(243, 244, 246);
                    lblStatus.ForeColor = Color.FromArgb(75, 85, 99);
                    break;
            }
            card.Controls.Add(lblStatus);

            // Línea separadora 
            Panel separator = new Panel
            {
                Location = new Point(15, 70),
                Size = new Size(card.Width - 30, 1),
                BackColor = Color.LightGray
            };
            card.Controls.Add(separator);


            // Items (Título)
            Label lblItemsTitle = new Label
            {
                Text = "Items:",
                Location = new Point(15, 80),
                Size = new Size(100, 20),
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            card.Controls.Add(lblItemsTitle);

            // Items (Lista con viñetas)
            // Aseguramos que la lista se muestre con viñetas
            string itemsTextFormatted = string.Join(Environment.NewLine, pedido.ItemsTexto.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(i => "• " + i.Trim()));

            Label lblItems = new Label
            {
                Text = itemsTextFormatted,
                Location = new Point(15, 105),
                Size = new Size(card.Width - 30, 50),
                Font = new Font("Arial", 10),
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false, // Necesario para que respete el tamaño y muestre los puntos suspensivos si es muy largo
                AutoEllipsis = true,
                MaximumSize = new Size(card.Width - 30, 50)
            };
            card.Controls.Add(lblItems);

            // Total
            Label lblTotal = new Label
            {
                Text = "Total: $" + pedido.Total.ToString("0.00"),
                Location = new Point(15, 165),
                Size = new Size(200, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black
            };
            card.Controls.Add(lblTotal);

            // Botón cambiar estado
            if (pedido.Estado != "Entregado" && pedido.Estado != "Completado")
            {
                Button btnCambiar = new Button
                {
                    Location = new Point(card.Width - 165, 160),
                    Size = new Size(150, 30),
                    Text = GetNextStatusText(pedido.Estado),
                    BackColor = GetStatusButtonColor(pedido.Estado),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Tag = pedido
                };
                btnCambiar.FlatAppearance.BorderSize = 0;
                btnCambiar.Click += BtnCambiarEstado_Click;
                card.Controls.Add(btnCambiar);
            }
            else
            {
                // Botón deshabilitado para pedidos completados
                Button btnCompletado = new Button
                {
                    Location = new Point(card.Width - 165, 160),
                    Size = new Size(150, 30),
                    Text = "Entregado",
                    BackColor = Color.FromArgb(209, 213, 219),
                    ForeColor = Color.FromArgb(75, 85, 99),
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Enabled = false
                };
                btnCompletado.FlatAppearance.BorderSize = 0;
                card.Controls.Add(btnCompletado);
            }

            return card;
        }

        private string GetNextStatusText(string currentStatus)
        {
            return currentStatus switch
            {
                "Pendiente" => "Preparar",
                "Preparando" => "Marcar Listo",
                "En Preparación" => "Marcar Listo",
                "Listo" => "Entregar",
                _ => ""
            };
        }

        private Color GetStatusButtonColor(string currentStatus)
        {
            return currentStatus switch
            {
                "Pendiente" => Color.FromArgb(37, 99, 235),
                "Preparando" => Color.FromArgb(34, 197, 94),
                "En Preparación" => Color.FromArgb(34, 197, 94),
                "Listo" => Color.FromArgb(75, 85, 99),
                _ => Color.Gray
            };
        }

        private async void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                PedidoDTO pedido = (PedidoDTO)btn.Tag;

                string nuevoEstado = await _pedidoService.ObtenerSiguienteEstadoAsync(pedido.Estado);
                bool resultado = await _pedidoService.CambiarEstadoPedidoAsync(pedido.Id, nuevoEstado);

                if (resultado)
                {
                    await CargarPedidosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Pedidos
            // 
            ClientSize = new Size(2564, 1399);
            Name = "Pedidos";
            Load += Pedidos_Load_1;
            ResumeLayout(false);

        }

        private void Pedidos_Load_1(object sender, EventArgs e)
        {
           
        }
    }
}
