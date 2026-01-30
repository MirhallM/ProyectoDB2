namespace ProyectoDB2
{
    partial class Login
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
            splitContainer1 = new SplitContainer();
            PanelBotones = new FlowLayoutPanel();
            btnNueva = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            listaConexiones = new ListBox();
            TitlePanel = new Panel();
            lblTitulo = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            lblPuerto = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbNombre = new TextBox();
            tbServidor = new TextBox();
            tbPuerto = new TextBox();
            tbBDD = new TextBox();
            tbUsuario = new TextBox();
            tbContra = new TextBox();
            pnlTitulo2 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            PanelBotones.SuspendLayout();
            TitlePanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlTitulo2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(PanelBotones);
            splitContainer1.Panel1.Controls.Add(listaConexiones);
            splitContainer1.Panel1.Controls.Add(TitlePanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel2.Controls.Add(pnlTitulo2);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(808, 378);
            splitContainer1.SplitterDistance = 268;
            splitContainer1.TabIndex = 0;
            // 
            // PanelBotones
            // 
            PanelBotones.Controls.Add(btnNueva);
            PanelBotones.Controls.Add(btnEditar);
            PanelBotones.Controls.Add(btnEliminar);
            PanelBotones.Dock = DockStyle.Bottom;
            PanelBotones.FlowDirection = FlowDirection.TopDown;
            PanelBotones.Location = new Point(0, 260);
            PanelBotones.Name = "PanelBotones";
            PanelBotones.Padding = new Padding(10);
            PanelBotones.Size = new Size(268, 118);
            PanelBotones.TabIndex = 2;
            // 
            // btnNueva
            // 
            btnNueva.Location = new Point(13, 13);
            btnNueva.Name = "btnNueva";
            btnNueva.Size = new Size(252, 23);
            btnNueva.TabIndex = 0;
            btnNueva.Text = "Nueva";
            btnNueva.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(13, 42);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(252, 23);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(13, 71);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(252, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // listaConexiones
            // 
            listaConexiones.Dock = DockStyle.Fill;
            listaConexiones.FormattingEnabled = true;
            listaConexiones.ItemHeight = 15;
            listaConexiones.Location = new Point(0, 40);
            listaConexiones.Name = "listaConexiones";
            listaConexiones.Size = new Size(268, 338);
            listaConexiones.TabIndex = 1;
            // 
            // TitlePanel
            // 
            TitlePanel.BackColor = SystemColors.ControlLight;
            TitlePanel.Controls.Add(lblTitulo);
            TitlePanel.Dock = DockStyle.Top;
            TitlePanel.Location = new Point(0, 0);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Padding = new Padding(10);
            TitlePanel.Size = new Size(268, 40);
            TitlePanel.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(13, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(217, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Conexiones Guardadas";
            lblTitulo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 250);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(536, 46);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(438, 13);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Conectar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(357, 13);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(220, 13);
            button3.Name = "button3";
            button3.Size = new Size(131, 23);
            button3.TabIndex = 2;
            button3.Text = "Probar Conexion";
            button3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(lblPuerto, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(tbNombre, 1, 0);
            tableLayoutPanel1.Controls.Add(tbServidor, 1, 1);
            tableLayoutPanel1.Controls.Add(tbPuerto, 1, 2);
            tableLayoutPanel1.Controls.Add(tbBDD, 1, 3);
            tableLayoutPanel1.Controls.Add(tbUsuario, 1, 4);
            tableLayoutPanel1.Controls.Add(tbContra, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.Size = new Size(536, 210);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ImageAlign = ContentAlignment.MiddleRight;
            label2.Location = new Point(86, 7);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 0;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ImageAlign = ContentAlignment.MiddleRight;
            label3.Location = new Point(85, 42);
            label3.Name = "label3";
            label3.Size = new Size(72, 21);
            label3.TabIndex = 1;
            label3.Text = "Servidor:";
            // 
            // lblPuerto
            // 
            lblPuerto.Anchor = AnchorStyles.Right;
            lblPuerto.AutoSize = true;
            lblPuerto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPuerto.Location = new Point(98, 77);
            lblPuerto.Name = "lblPuerto";
            lblPuerto.Size = new Size(59, 21);
            lblPuerto.TabIndex = 2;
            lblPuerto.Text = "Puerto:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(45, 112);
            label4.Name = "label4";
            label4.Size = new Size(112, 21);
            label4.TabIndex = 3;
            label4.Text = "Base De Datos:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(90, 147);
            label5.Name = "label5";
            label5.Size = new Size(67, 21);
            label5.TabIndex = 4;
            label5.Text = "Usuario:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(65, 182);
            label6.Name = "label6";
            label6.Size = new Size(92, 21);
            label6.TabIndex = 5;
            label6.Text = "Contraseña:";
            // 
            // tbNombre
            // 
            tbNombre.Font = new Font("Segoe UI", 12F);
            tbNombre.Location = new Point(163, 3);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(370, 29);
            tbNombre.TabIndex = 6;
            // 
            // tbServidor
            // 
            tbServidor.Font = new Font("Segoe UI", 12F);
            tbServidor.Location = new Point(163, 38);
            tbServidor.Name = "tbServidor";
            tbServidor.Size = new Size(370, 29);
            tbServidor.TabIndex = 7;
            // 
            // tbPuerto
            // 
            tbPuerto.Font = new Font("Segoe UI", 12F);
            tbPuerto.Location = new Point(163, 73);
            tbPuerto.Name = "tbPuerto";
            tbPuerto.Size = new Size(370, 29);
            tbPuerto.TabIndex = 8;
            tbPuerto.Text = "50000";
            // 
            // tbBDD
            // 
            tbBDD.Font = new Font("Segoe UI", 12F);
            tbBDD.Location = new Point(163, 108);
            tbBDD.Name = "tbBDD";
            tbBDD.Size = new Size(370, 29);
            tbBDD.TabIndex = 9;
            // 
            // tbUsuario
            // 
            tbUsuario.Font = new Font("Segoe UI", 12F);
            tbUsuario.Location = new Point(163, 143);
            tbUsuario.Name = "tbUsuario";
            tbUsuario.Size = new Size(370, 29);
            tbUsuario.TabIndex = 10;
            // 
            // tbContra
            // 
            tbContra.Font = new Font("Segoe UI", 12F);
            tbContra.Location = new Point(163, 178);
            tbContra.Name = "tbContra";
            tbContra.PasswordChar = '*';
            tbContra.Size = new Size(370, 29);
            tbContra.TabIndex = 11;
            // 
            // pnlTitulo2
            // 
            pnlTitulo2.BackColor = SystemColors.ControlLight;
            pnlTitulo2.Controls.Add(label1);
            pnlTitulo2.Dock = DockStyle.Top;
            pnlTitulo2.Location = new Point(0, 0);
            pnlTitulo2.Name = "pnlTitulo2";
            pnlTitulo2.Size = new Size(536, 40);
            pnlTitulo2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(219, 25);
            label1.TabIndex = 0;
            label1.Text = "Detalles de la Conexion";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 378);
            Controls.Add(splitContainer1);
            Name = "Login";
            Text = "Login";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            PanelBotones.ResumeLayout(false);
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlTitulo2.ResumeLayout(false);
            pnlTitulo2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private FlowLayoutPanel PanelBotones;
        private ListBox listaConexiones;
        private Panel TitlePanel;
        private Button btnNueva;
        private Button btnEditar;
        private Button btnEliminar;
        private Label lblTitulo;
        private Panel pnlTitulo2;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private Button button1;
        private Button button3;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label lblPuerto;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbNombre;
        private TextBox tbServidor;
        private TextBox tbPuerto;
        private TextBox tbBDD;
        private TextBox tbUsuario;
        private TextBox tbContra;
    }
}