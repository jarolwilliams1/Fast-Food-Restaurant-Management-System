namespace Menu
{
    partial class UcPedidos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            NumOrder = new Label();
            Hora = new Label();
            label1 = new Label();
            Items = new Label();
            Estado = new Label();
            Accion = new Button();
            SuspendLayout();
            // 
            // NumOrder
            // 
            NumOrder.AutoSize = true;
            NumOrder.Location = new Point(43, 23);
            NumOrder.Name = "NumOrder";
            NumOrder.Size = new Size(78, 32);
            NumOrder.TabIndex = 0;
            NumOrder.Text = "label1";
            // 
            // Hora
            // 
            Hora.AutoSize = true;
            Hora.Location = new Point(43, 75);
            Hora.Name = "Hora";
            Hora.Size = new Size(78, 32);
            Hora.TabIndex = 1;
            Hora.Text = "label1";
            Hora.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 121);
            label1.Name = "label1";
            label1.Size = new Size(77, 32);
            label1.TabIndex = 2;
            label1.Text = "Items:";
            // 
            // Items
            // 
            Items.AutoSize = true;
            Items.Location = new Point(43, 173);
            Items.Name = "Items";
            Items.Size = new Size(78, 32);
            Items.TabIndex = 3;
            Items.Text = "label2";
            // 
            // Estado
            // 
            Estado.AutoSize = true;
            Estado.Location = new Point(816, 56);
            Estado.Name = "Estado";
            Estado.Size = new Size(78, 32);
            Estado.TabIndex = 4;
            Estado.Text = "label2";
            // 
            // Accion
            // 
            Accion.Location = new Point(744, 378);
            Accion.Name = "Accion";
            Accion.Size = new Size(150, 46);
            Accion.TabIndex = 5;
            Accion.Text = "Preparar";
            Accion.UseVisualStyleBackColor = true;
            // 
            // UcPedidos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Accion);
            Controls.Add(Estado);
            Controls.Add(Items);
            Controls.Add(label1);
            Controls.Add(Hora);
            Controls.Add(NumOrder);
            Name = "UcPedidos";
            Size = new Size(972, 501);
            Load += UcPedidos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NumOrder;
        private Label Hora;
        private Label label1;
        private Label Items;
        private Label Estado;
        private Button Accion;
    }
}
