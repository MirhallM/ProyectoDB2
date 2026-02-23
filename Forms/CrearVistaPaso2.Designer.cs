namespace ProyectoDB2.Forms
{
    partial class CrearVistaPaso2
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
            panel1 = new Panel();
            pnlBotones = new Panel();
            btnAtras = new Button();
            btnFinalizar = new Button();
            btnCancelar = new Button();
            chkDistinct = new CheckBox();
            btnQuitarTodo = new Button();
            btnAgregarTodo = new Button();
            btnQuitar = new Button();
            btnAgregar = new Button();
            lbIncluidas = new ListBox();
            lbDisponibles = new ListBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pnlBotones);
            panel1.Controls.Add(chkDistinct);
            panel1.Controls.Add(btnQuitarTodo);
            panel1.Controls.Add(btnAgregarTodo);
            panel1.Controls.Add(btnQuitar);
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(lbIncluidas);
            panel1.Controls.Add(lbDisponibles);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(585, 394);
            panel1.TabIndex = 0;
            // 
            // pnlBotones
            // 
            pnlBotones.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlBotones.Controls.Add(btnAtras);
            pnlBotones.Controls.Add(btnFinalizar);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Location = new Point(317, 349);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(256, 33);
            pnlBotones.TabIndex = 10;
            // 
            // btnAtras
            // 
            btnAtras.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtras.Location = new Point(13, 7);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(75, 23);
            btnAtras.TabIndex = 2;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFinalizar.Location = new Point(175, 7);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(75, 23);
            btnFinalizar.TabIndex = 1;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(94, 7);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // chkDistinct
            // 
            chkDistinct.AutoSize = true;
            chkDistinct.Location = new Point(11, 342);
            chkDistinct.Name = "chkDistinct";
            chkDistinct.Size = new Size(119, 19);
            chkDistinct.TabIndex = 9;
            chkDistinct.Text = "SELECT DISTINCT";
            chkDistinct.UseVisualStyleBackColor = true;
            // 
            // btnQuitarTodo
            // 
            btnQuitarTodo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuitarTodo.Location = new Point(271, 217);
            btnQuitarTodo.Name = "btnQuitarTodo";
            btnQuitarTodo.Size = new Size(48, 33);
            btnQuitarTodo.TabIndex = 8;
            btnQuitarTodo.Text = "<<";
            btnQuitarTodo.UseVisualStyleBackColor = true;
            btnQuitarTodo.Click += btnQuitarTodo_Click;
            // 
            // btnAgregarTodo
            // 
            btnAgregarTodo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarTodo.Location = new Point(271, 178);
            btnAgregarTodo.Name = "btnAgregarTodo";
            btnAgregarTodo.Size = new Size(48, 33);
            btnAgregarTodo.TabIndex = 7;
            btnAgregarTodo.Text = ">>";
            btnAgregarTodo.UseVisualStyleBackColor = true;
            btnAgregarTodo.Click += btnAgregarTodo_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuitar.Location = new Point(271, 139);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(48, 33);
            btnQuitar.TabIndex = 6;
            btnQuitar.Text = "<";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(271, 100);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(48, 33);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = ">";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lbIncluidas
            // 
            lbIncluidas.FormattingEnabled = true;
            lbIncluidas.ItemHeight = 15;
            lbIncluidas.Location = new Point(325, 47);
            lbIncluidas.Name = "lbIncluidas";
            lbIncluidas.Size = new Size(244, 289);
            lbIncluidas.TabIndex = 4;
            lbIncluidas.SelectedIndexChanged += lbIncluidas_SelectedIndexChanged;
            // 
            // lbDisponibles
            // 
            lbDisponibles.FormattingEnabled = true;
            lbDisponibles.ItemHeight = 15;
            lbDisponibles.Location = new Point(11, 47);
            lbDisponibles.Name = "lbDisponibles";
            lbDisponibles.Size = new Size(254, 289);
            lbDisponibles.TabIndex = 3;
            lbDisponibles.SelectedIndexChanged += lbDisponibles_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(402, 29);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
            label3.Text = "Incluidas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 29);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 1;
            label2.Text = "Disponibles";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(183, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecciona columnas para la vista";
            // 
            // CrearVistaPaso2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 394);
            Controls.Add(panel1);
            Name = "CrearVistaPaso2";
            Text = "CrearVistaPaso2";
            Load += CrearVistaPaso2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ListBox lbIncluidas;
        private ListBox lbDisponibles;
        private Label label3;
        private Label label2;
        private Button btnAgregar;
        private Button btnQuitarTodo;
        private Button btnAgregarTodo;
        private Button btnQuitar;
        private CheckBox chkDistinct;
        private Panel pnlBotones;
        private Button btnAtras;
        private Button btnFinalizar;
        private Button btnCancelar;
    }
}