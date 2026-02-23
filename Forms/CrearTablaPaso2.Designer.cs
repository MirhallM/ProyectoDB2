namespace ProyectoDB2.Forms
{
    partial class CrearTablaPaso2
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
            dgvColumnas = new DataGridView();
            btnAgregarColumnas = new Button();
            lblTituloTabla = new Label();
            pnlBotones = new Panel();
            btnAtras = new Button();
            btnFinalizar = new Button();
            btnCancelar = new Button();
            btnEliminarColumna = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvColumnas).BeginInit();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // dgvColumnas
            // 
            dgvColumnas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColumnas.Location = new Point(12, 42);
            dgvColumnas.Name = "dgvColumnas";
            dgvColumnas.Size = new Size(530, 396);
            dgvColumnas.TabIndex = 0;
            // 
            // btnAgregarColumnas
            // 
            btnAgregarColumnas.Location = new Point(548, 42);
            btnAgregarColumnas.Name = "btnAgregarColumnas";
            btnAgregarColumnas.Size = new Size(134, 23);
            btnAgregarColumnas.TabIndex = 1;
            btnAgregarColumnas.Text = "Agregar Columna";
            btnAgregarColumnas.UseVisualStyleBackColor = true;
            btnAgregarColumnas.Click += btnAgregarColumnas_Click;
            // 
            // lblTituloTabla
            // 
            lblTituloTabla.AutoSize = true;
            lblTituloTabla.Location = new Point(16, 13);
            lblTituloTabla.Name = "lblTituloTabla";
            lblTituloTabla.Size = new Size(38, 15);
            lblTituloTabla.TabIndex = 2;
            lblTituloTabla.Text = "label1";
            // 
            // pnlBotones
            // 
            pnlBotones.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlBotones.Controls.Add(btnAtras);
            pnlBotones.Controls.Add(btnFinalizar);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Location = new Point(539, 397);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(249, 41);
            pnlBotones.TabIndex = 5;
            // 
            // btnAtras
            // 
            btnAtras.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtras.Location = new Point(9, 15);
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
            btnFinalizar.Location = new Point(171, 15);
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
            btnCancelar.Location = new Point(90, 15);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEliminarColumna
            // 
            btnEliminarColumna.Location = new Point(548, 71);
            btnEliminarColumna.Name = "btnEliminarColumna";
            btnEliminarColumna.Size = new Size(134, 23);
            btnEliminarColumna.TabIndex = 6;
            btnEliminarColumna.Text = "Eliminar Columna";
            btnEliminarColumna.UseVisualStyleBackColor = true;
            btnEliminarColumna.Click += btnEliminarColumna_Click;
            // 
            // CrearTablaPaso2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvColumnas);
            Controls.Add(btnEliminarColumna);
            Controls.Add(pnlBotones);
            Controls.Add(lblTituloTabla);
            Controls.Add(btnAgregarColumnas);
            Name = "CrearTablaPaso2";
            Text = "CrearTablaPaso2";
            Load += CrearTablaPaso2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvColumnas).EndInit();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvColumnas;
        private Button btnAgregarColumnas;
        private Label lblTituloTabla;
        private Panel pnlBotones;
        private Button btnAtras;
        private Button btnFinalizar;
        private Button btnCancelar;
        private Button btnEliminarColumna;
    }
}