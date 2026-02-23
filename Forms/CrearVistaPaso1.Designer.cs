namespace ProyectoDB2.Forms
{
    partial class CrearVistaPaso1
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSiguiente = new Button();
            btnAtras = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            cbEsquema = new ComboBox();
            label2 = new Label();
            tbNombreVista = new TextBox();
            label3 = new Label();
            cbTablaBase = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.15609F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.84391F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cbEsquema, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(tbNombreVista, 1, 1);
            tableLayoutPanel1.Controls.Add(cbTablaBase, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(595, 322);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSiguiente);
            flowLayoutPanel1.Controls.Add(btnAtras);
            flowLayoutPanel1.Controls.Add(btnCancelar);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(147, 272);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(433, 35);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(355, 3);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 23);
            btnSiguiente.TabIndex = 0;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += this.btnSiguiente_Click;
            // 
            // btnAtras
            // 
            btnAtras.Enabled = false;
            btnAtras.Location = new Point(274, 3);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(75, 23);
            btnAtras.TabIndex = 1;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(193, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += this.btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Location = new Point(80, 12);
            label1.Name = "label1";
            label1.Size = new Size(61, 29);
            label1.TabIndex = 1;
            label1.Text = "Esquema: ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbEsquema
            // 
            cbEsquema.Dock = DockStyle.Fill;
            cbEsquema.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEsquema.FormattingEnabled = true;
            cbEsquema.Location = new Point(147, 15);
            cbEsquema.Name = "cbEsquema";
            cbEsquema.Size = new Size(433, 23);
            cbEsquema.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Right;
            label2.Location = new Point(28, 41);
            label2.Name = "label2";
            label2.Size = new Size(113, 29);
            label2.TabIndex = 3;
            label2.Text = "Nombre de la Vista: ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbNombreVista
            // 
            tbNombreVista.Dock = DockStyle.Fill;
            tbNombreVista.Location = new Point(147, 44);
            tbNombreVista.Name = "tbNombreVista";
            tbNombreVista.Size = new Size(433, 23);
            tbNombreVista.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Right;
            label3.Location = new Point(73, 70);
            label3.Name = "label3";
            label3.Size = new Size(68, 29);
            label3.TabIndex = 5;
            label3.Text = "Tabla Base: ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbTablaBase
            // 
            cbTablaBase.Dock = DockStyle.Fill;
            cbTablaBase.FormattingEnabled = true;
            cbTablaBase.Location = new Point(147, 73);
            cbTablaBase.Name = "cbTablaBase";
            cbTablaBase.Size = new Size(433, 23);
            cbTablaBase.TabIndex = 6;
            // 
            // CrearVistaPaso1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 322);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CrearVistaPaso1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Crear Vista";
            Load += this.CrearVistaPaso1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSiguiente;
        private Button btnAtras;
        private Button btnCancelar;
        private Label label1;
        private ComboBox cbEsquema;
        private Label label2;
        private TextBox tbNombreVista;
        private ComboBox cbTablaBase;
        private Label label3;
    }
}