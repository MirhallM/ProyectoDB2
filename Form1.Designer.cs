namespace ProyectoDB2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProbarConexion = new Button();
            TablaResultados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)TablaResultados).BeginInit();
            SuspendLayout();
            // 
            // btnProbarConexion
            // 
            btnProbarConexion.Location = new Point(21, 22);
            btnProbarConexion.Name = "btnProbarConexion";
            btnProbarConexion.Size = new Size(143, 51);
            btnProbarConexion.TabIndex = 0;
            btnProbarConexion.Text = "Probar Conexion";
            btnProbarConexion.UseVisualStyleBackColor = true;
            btnProbarConexion.Click += btnProbarConexion_Click;
            // 
            // TablaResultados
            // 
            TablaResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TablaResultados.Dock = DockStyle.Bottom;
            TablaResultados.Location = new Point(0, 91);
            TablaResultados.Name = "TablaResultados";
            TablaResultados.Size = new Size(800, 409);
            TablaResultados.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(TablaResultados);
            Controls.Add(btnProbarConexion);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)TablaResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnProbarConexion;
        private DataGridView TablaResultados;
    }
}
