namespace ProyectoDB2
{
    partial class PaginaPrincipal
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
            panel2 = new Panel();
            panel3 = new Panel();
            treeView1 = new TreeView();
            SQLBox = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(treeView1);
            panel1.Location = new Point(3, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(168, 589);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(SQLBox);
            panel2.Location = new Point(176, 90);
            panel2.Name = "panel2";
            panel2.Size = new Size(1084, 221);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Location = new Point(176, 320);
            panel3.Name = "panel3";
            panel3.Size = new Size(1084, 359);
            panel3.TabIndex = 2;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(0, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(165, 583);
            treeView1.TabIndex = 0;
            // 
            // SQLBox
            // 
            SQLBox.Location = new Point(3, 3);
            SQLBox.Name = "SQLBox";
            SQLBox.Size = new Size(1078, 23);
            SQLBox.TabIndex = 0;
            // 
            // PaginaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "PaginaPrincipal";
            Text = "PaginaPrincipal";
            Load += PaginaPrincipal_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TreeView treeView1;
        private Panel panel2;
        private Panel panel3;
        private TextBox SQLBox;
    }
}