namespace ProyectoDB2.Forms
{
    partial class CrearTablaPaso1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            cbEsquema = new ComboBox();
            label2 = new Label();
            tbNombreTabla = new TextBox();
            pnlBotones = new Panel();
            btnCancelar = new Button();
            btnSiguiente = new Button();
            btnAtras = new Button();
            tableLayoutPanel1.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cbEsquema, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(tbNombreTabla, 1, 1);
            tableLayoutPanel1.Controls.Add(pnlBotones, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(572, 329);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(15, 68);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 0;
            label1.Text = "Esquema:";
            label1.UseMnemonic = false;
            // 
            // cbEsquema
            // 
            cbEsquema.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbEsquema.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEsquema.FormattingEnabled = true;
            cbEsquema.Location = new Point(134, 64);
            cbEsquema.Name = "cbEsquema";
            cbEsquema.Size = new Size(423, 23);
            cbEsquema.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(15, 195);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre de la Tabla:";
            // 
            // tbNombreTabla
            // 
            tbNombreTabla.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbNombreTabla.Location = new Point(134, 191);
            tbNombreTabla.Name = "tbNombreTabla";
            tbNombreTabla.Size = new Size(423, 23);
            tbNombreTabla.TabIndex = 3;
            // 
            // pnlBotones
            // 
            pnlBotones.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlBotones.Controls.Add(btnAtras);
            pnlBotones.Controls.Add(btnSiguiente);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Location = new Point(283, 269);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(274, 45);
            pnlBotones.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(34, 19);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSiguiente.Location = new Point(196, 19);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 23);
            btnSiguiente.TabIndex = 1;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAtras
            // 
            btnAtras.Enabled = false;
            btnAtras.Location = new Point(115, 19);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(75, 23);
            btnAtras.TabIndex = 2;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // CrearTablaPaso1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 329);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CrearTablaPaso1";
            Text = "Crear Tabla ";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ComboBox cbEsquema;
        private Label label2;
        private TextBox tbNombreTabla;
        private Panel pnlBotones;
        private Button btnSiguiente;
        private Button btnCancelar;
        private Button btnAtras;
    }
}