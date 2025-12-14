using FastFoodManagerApp.Services; // ✅ IMPORTANTE: Para acceder a servicios y DTOs
using FastFoodManagerApp.Services.DTOs;
using FastFoodManagerPlataformDomain.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class PromocionesForm : Form
    {
        private readonly IPromocionService _promocionService;
        private readonly IProductoService _productoService;

        // Controles principales
        private Panel panelCombos;
        private Panel panelDescuentos;
        private Panel panelForm;
        private Button btnNuevaPromocion;
        private RadioButton rbCombo;
        private RadioButton rbDescuento;
        private TextBox txtNombre;
        private CheckedListBox chkProductos;
        private TextBox txtValor;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblValor;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private CheckBox chkFechaFin;

        public PromocionesForm(IPromocionService promocionService, IProductoService productoService)
        {
            _promocionService = promocionService;
            _productoService = productoService;

           InitializeComponent();
            InitializeUI();
            _ = CargarPromociones();
        }

     

        private void PromocionesForm_Load(object sender, EventArgs e)
        {
            // Este método se ejecuta cuando el formulario se carga
            // El método async CargarPromociones() ya se llama en el constructor
        }

        // Si prefieres cargar en el Load en lugar del constructor:
      

        //private void InitializeComponent()
        //{
        //    this.Text = "Promociones y Combos";
        //    this.Size = new Size(1000, 700);
        //    this.BackColor = Color.White;
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    this.AutoScroll = true;
        //}

        private void InitializeUI()
        {
            // Header
            Label lblTitle = new Label
            {
                Text = "Promociones y Combos",
                Location = new Point(20, 20),
                Size = new Size(400, 30),
                Font = new Font("Arial", 14, FontStyle.Bold)
            };
            this.Controls.Add(lblTitle);

            Label lblSubtitle = new Label
            {
                Text = "Administra ofertas y paquetes especiales",
                Location = new Point(20, 50),
                Size = new Size(400, 20),
                ForeColor = Color.Gray
            };
            this.Controls.Add(lblSubtitle);

            // Botón Nueva Promoción
            btnNuevaPromocion = new Button
            {
                Text = "Nueva Promoción",
                Location = new Point(820, 20),
                Size = new Size(150, 35),
                BackColor = Color.MediumPurple,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnNuevaPromocion.Click += BtnNuevaPromocion_Click;
            this.Controls.Add(btnNuevaPromocion);

            // Panel del formulario (inicialmente oculto)
            CreateFormPanel();

            // Panel para Combos
            Label lblCombos = new Label
            {
                Text = "COMBOS DISPONIBLES",
                Location = new Point(20, 80),
                Size = new Size(300, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.MediumPurple
            };
            this.Controls.Add(lblCombos);

            panelCombos = new Panel
            {
                Location = new Point(20, 110),
                Size = new Size(940, 250),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true,
                BackColor = Color.WhiteSmoke
            };
            this.Controls.Add(panelCombos);

            // Panel para Descuentos
            Label lblDescuentos = new Label
            {
                Text = "DESCUENTOS ACTIVOS",
                Location = new Point(20, 370),
                Size = new Size(300, 25),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.MediumPurple
            };
            this.Controls.Add(lblDescuentos);

            panelDescuentos = new Panel
            {
                Location = new Point(20, 400),
                Size = new Size(940, 250),
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true,
                BackColor = Color.WhiteSmoke
            };
            this.Controls.Add(panelDescuentos);
        }

        private void CreateFormPanel()
        {
            panelForm = new Panel
            {
                Location = new Point(20, 80),
                Size = new Size(940, 400),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Visible = false
            };
            this.Controls.Add(panelForm);

            Label lblFormTitle = new Label
            {
                Text = "Nueva Promoción",
                Location = new Point(10, 10),
                Size = new Size(200, 25),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            panelForm.Controls.Add(lblFormTitle);

            // Tipo de promoción
            Label lblTipo = new Label
            {
                Text = "Tipo:",
                Location = new Point(10, 45),
                Size = new Size(100, 20)
            };
            panelForm.Controls.Add(lblTipo);

            rbCombo = new RadioButton
            {
                Text = "Combo",
                Location = new Point(10, 70),
                Size = new Size(150, 30),
                Checked = true,
                BackColor = Color.MediumPurple,
                ForeColor = Color.White,
                Appearance = Appearance.Button,
                TextAlign = ContentAlignment.MiddleCenter
            };
            rbCombo.CheckedChanged += RbTipo_CheckedChanged;
            panelForm.Controls.Add(rbCombo);

            rbDescuento = new RadioButton
            {
                Text = "Descuento",
                Location = new Point(170, 70),
                Size = new Size(150, 30),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Appearance = Appearance.Button,
                TextAlign = ContentAlignment.MiddleCenter
            };
            rbDescuento.CheckedChanged += RbTipo_CheckedChanged;
            panelForm.Controls.Add(rbDescuento);

            // Nombre
            Label lblNombre = new Label
            {
                Text = "Nombre:",
                Location = new Point(10, 110),
                Size = new Size(100, 20)
            };
            panelForm.Controls.Add(lblNombre);

            txtNombre = new TextBox
            {
                Location = new Point(10, 135),
                Size = new Size(450, 25),
                Font = new Font("Arial", 10)
            };
            panelForm.Controls.Add(txtNombre);

            // Valor (Precio o Descuento)
            lblValor = new Label
            {
                Text = "Precio del Combo:",
                Location = new Point(480, 110),
                Size = new Size(150, 20)
            };
            panelForm.Controls.Add(lblValor);

            txtValor = new TextBox
            {
                Location = new Point(480, 135),
                Size = new Size(200, 25),
                Font = new Font("Arial", 10)
            };
            panelForm.Controls.Add(txtValor);

            // Productos (CheckedListBox)
            Label lblProductos = new Label
            {
                Text = "Productos:",
                Location = new Point(10, 170),
                Size = new Size(100, 20)
            };
            panelForm.Controls.Add(lblProductos);

            chkProductos = new CheckedListBox
            {
                Location = new Point(10, 195),
                Size = new Size(450, 120),
                Font = new Font("Arial", 9),
                CheckOnClick = true
            };
            panelForm.Controls.Add(chkProductos);

            // Descripción
            Label lblDescripcionLabel = new Label
            {
                Text = "Descripción:",
                Location = new Point(480, 170),
                Size = new Size(100, 20)
            };
            panelForm.Controls.Add(lblDescripcionLabel);

            txtDescripcion = new TextBox
            {
                Location = new Point(480, 195),
                Size = new Size(440, 60),
                Font = new Font("Arial", 10),
                Multiline = true
            };
            panelForm.Controls.Add(txtDescripcion);

            // Fecha Inicio
            Label lblFechaInicio = new Label
            {
                Text = "Fecha Inicio:",
                Location = new Point(480, 265),
                Size = new Size(100, 20)
            };
            panelForm.Controls.Add(lblFechaInicio);

            dtpFechaInicio = new DateTimePicker
            {
                Location = new Point(480, 290),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short
            };
            panelForm.Controls.Add(dtpFechaInicio);

            // Fecha Fin (opcional)
            chkFechaFin = new CheckBox
            {
                Text = "Fecha Fin:",
                Location = new Point(700, 265),
                Size = new Size(100, 20)
            };
            chkFechaFin.CheckedChanged += (s, e) => dtpFechaFin.Enabled = chkFechaFin.Checked;
            panelForm.Controls.Add(chkFechaFin);

            dtpFechaFin = new DateTimePicker
            {
                Location = new Point(700, 290),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short,
                Enabled = false
            };
            panelForm.Controls.Add(dtpFechaFin);

            // Botones
            btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(10, 330),
                Size = new Size(120, 35),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnGuardar.Click += BtnGuardar_Click;
            panelForm.Controls.Add(btnGuardar);

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(140, 330),
                Size = new Size(120, 35),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10),
                FlatStyle = FlatStyle.Flat
            };
            btnCancelar.Click += BtnCancelar_Click;
            panelForm.Controls.Add(btnCancelar);
        }

        private async void BtnNuevaPromocion_Click(object sender, EventArgs e)
        {
            panelForm.Visible = !panelForm.Visible;

            if (panelForm.Visible)
            {
                await CargarProductosEnFormulario();
                panelCombos.Location = new Point(20, 490);
                panelDescuentos.Visible = false;
            }
            else
            {
                panelCombos.Location = new Point(20, 110);
                panelDescuentos.Visible = true;
            }
        }

        private async Task CargarProductosEnFormulario()
        {
            try
            {
                var productos = await _productoService.ObtenerProductosDisponiblesAsync();

                chkProductos.Items.Clear();

                foreach (var producto in productos)
                {
                    chkProductos.Items.Add(new ProductoItem
                    {
                        Id = producto.Id,
                        Nombre = $"{producto.Nombre} - ${producto.Precio:F2}"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RbTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCombo.Checked)
            {
                rbCombo.BackColor = Color.MediumPurple;
                rbCombo.ForeColor = Color.White;
                rbDescuento.BackColor = Color.LightGray;
                rbDescuento.ForeColor = Color.Black;
                lblValor.Text = "Precio del Combo:";
            }
            else
            {
                rbDescuento.BackColor = Color.MediumPurple;
                rbDescuento.ForeColor = Color.White;
                rbCombo.BackColor = Color.LightGray;
                rbCombo.ForeColor = Color.Black;
                lblValor.Text = "Descuento (%):";
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtValor.Text, out decimal valor) || valor <= 0)
                {
                    MessageBox.Show("Ingrese un valor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var productosIds = chkProductos.CheckedItems
                    .Cast<ProductoItem>()
                    .Select(p => p.Id)
                    .ToList();

                if (!productosIds.Any())
                {
                    MessageBox.Show("Debe seleccionar al menos un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = rbCombo.Checked ? "COMBO" : "DESCUENTO";
                DateTime? fechaFin = chkFechaFin.Checked ? (DateTime?)dtpFechaFin.Value : null;

                bool resultado = await _promocionService.CrearPromocionAsync(
                    txtNombre.Text,
                    tipo,
                    valor,
                    txtDescripcion.Text,
                    productosIds,
                    dtpFechaInicio.Value,
                    fechaFin
                );

                if (resultado)
                {
                    MessageBox.Show("Promoción creada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    panelForm.Visible = false;
                    panelCombos.Location = new Point(20, 110);
                    panelDescuentos.Visible = true;
                    await CargarPromociones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            panelForm.Visible = false;
            panelCombos.Location = new Point(20, 110);
            panelDescuentos.Visible = true;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtValor.Clear();
            txtDescripcion.Clear();
            chkProductos.Items.Clear();
            for (int i = 0; i < chkProductos.Items.Count; i++)
            {
                chkProductos.SetItemChecked(i, false);
            }
            rbCombo.Checked = true;
            chkFechaFin.Checked = false;
            dtpFechaInicio.Value = DateTime.Now;
        }

        private async Task CargarPromociones()
        {
            try
            {
                var promociones = await _promocionService.ObtenerTodasPromocionesAsync();
                RenderPromotions(promociones);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar promociones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderPromotions(List<PromocionDTO> promociones)
        {
            panelCombos.Controls.Clear();
            panelDescuentos.Controls.Clear();

            var combos = promociones.Where(p => p.Tipo == "COMBO").ToList();
            int y = 10;
            int x = 10;
            int col = 0;

            foreach (var combo in combos)
            {
                Panel comboPanel = CreateComboCard(combo);
                comboPanel.Location = new Point(x, y);
                panelCombos.Controls.Add(comboPanel);

                col++;
                if (col == 2)
                {
                    col = 0;
                    y += 180;
                    x = 10;
                }
                else
                {
                    x += 470;
                }
            }

            var descuentos = promociones.Where(p => p.Tipo == "DESCUENTO").ToList();
            y = 10;

            foreach (var descuento in descuentos)
            {
                Panel descuentoPanel = CreateDescuentoRow(descuento);
                descuentoPanel.Location = new Point(10, y);
                panelDescuentos.Controls.Add(descuentoPanel);
                y += 60;
            }
        }

        private Panel CreateComboCard(PromocionDTO combo)
        {
            Panel card = new Panel
            {
                Size = new Size(450, 160),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = combo.Activa ? Color.FromArgb(243, 232, 255) : Color.White
            };

            Label lblNombre = new Label
            {
                Text = combo.Name,
                Location = new Point(10, 10),
                Size = new Size(320, 25),
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            card.Controls.Add(lblNombre);

            Button btnEstado = new Button
            {
                Text = combo.Activa ? "Activo" : "Inactivo",
                Location = new Point(340, 10),
                Size = new Size(90, 25),
                BackColor = combo.Activa ? Color.FromArgb(220, 252, 231) : Color.LightGray,
                ForeColor = combo.Activa ? Color.Green : Color.Gray,
                FlatStyle = FlatStyle.Flat,
                Tag = combo.Id
            };
            btnEstado.Click += async (s, e) => await CambiarEstadoPromocion((int)((Button)s).Tag);
            card.Controls.Add(btnEstado);

            Label lblIncluye = new Label
            {
                Text = "Incluye:",
                Location = new Point(10, 40),
                Size = new Size(100, 20),
                ForeColor = Color.Gray
            };
            card.Controls.Add(lblIncluye);

            Label lblProductos = new Label
            {
                Text = "• " + string.Join("\n• ", combo.Name),
                Location = new Point(10, 60),
                Size = new Size(430, 70),
                Font = new Font("Arial", 9)
            };
            card.Controls.Add(lblProductos);

            Label lblPrecio = new Label
            {
                Text = "$" + combo.DiscountValue,
                Location = new Point(10, 135),
                Size = new Size(100, 20),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.MediumPurple
            };
            card.Controls.Add(lblPrecio);

            return card;
        }

        private Panel CreateDescuentoRow(PromocionDTO descuento)
        {
            Panel row = new Panel
            {
                Size = new Size(900, 50),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Label lblNombre = new Label
            {
                Text = descuento.Name,
                Location = new Point(10, 15),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            row.Controls.Add(lblNombre);

            Label lblDescuento = new Label
            {
                Text = descuento.DiscountValue + "%",
                Location = new Point(220, 15),
                Size = new Size(60, 20),
                ForeColor = Color.MediumPurple,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };
            row.Controls.Add(lblDescuento);

            Label lblProductos = new Label
            {
                Text = string.Join(", ", descuento.Name),
                Location = new Point(290, 15),
                Size = new Size(400, 20)
            };
            row.Controls.Add(lblProductos);

            Button btnEstado = new Button
            {
                Text = descuento.Activa ? "Activo" : "Inactivo",
                Location = new Point(700, 12),
                Size = new Size(80, 25),
                BackColor = descuento.Activa ? Color.FromArgb(220, 252, 231) : Color.LightGray,
                ForeColor = descuento.Activa ? Color.Green : Color.Gray,
                FlatStyle = FlatStyle.Flat,
                Tag = descuento.Id
            };
            btnEstado.Click += async (s, e) => await CambiarEstadoPromocion((int)((Button)s).Tag);
            row.Controls.Add(btnEstado);

            Button btnEliminar = new Button
            {
                Text = "Eliminar",
                Location = new Point(790, 12),
                Size = new Size(80, 25),
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = descuento.Id
            };
            btnEliminar.Click += async (s, e) => await EliminarPromocion((int)((Button)s).Tag);
            row.Controls.Add(btnEliminar);

            return row;
        }

        private async Task CambiarEstadoPromocion(int id)
        {
            try
            {
                bool resultado = await _promocionService.CambiarEstadoPromocionAsync(id);
                if (resultado)
                {
                    await CargarPromociones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarPromocion(int id)
        {
            try
            {
                var confirmacion = MessageBox.Show(
                    "¿Está seguro de eliminar esta promoción?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    bool resultado = await _promocionService.EliminarPromocionAsync(id);
                    if (resultado)
                    {
                        MessageBox.Show("Promoción eliminada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarPromociones();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ProductoItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }
    }
}