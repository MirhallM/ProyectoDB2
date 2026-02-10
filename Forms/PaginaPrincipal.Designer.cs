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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginaPrincipal));
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            label1 = new Label();
            treeView1 = new TreeView();
            menuTreeView = new ContextMenuStrip(components);
            verDDLToolStripMenuItem = new ToolStripMenuItem();
            exportarDDLToolStripMenuItem = new ToolStripMenuItem();
            selectToolStripMenuItem = new ToolStripMenuItem();
            crearToolStripMenuItem = new ToolStripMenuItem();
            splitContSQLDDL = new SplitContainer();
            pnlSQL = new Panel();
            richTxtBoxSQL = new RichTextBox();
            pnlBotonesSQL = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSQL = new Button();
            btnDDL = new Button();
            tabResultados = new TabControl();
            tpResultados = new TabPage();
            dataGridResultados = new DataGridView();
            tpMensajes = new TabPage();
            richTxtBoxMensajes = new RichTextBox();
            toolStrip1 = new ToolStrip();
            toolTipEjecutar = new ToolStripButton();
            toolTipNuevoQuery = new ToolStripButton();
            toolTipLimpiar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolTipExport = new ToolStripButton();
            toolTipRefrescar = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            menuTreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContSQLDDL).BeginInit();
            splitContSQLDDL.Panel1.SuspendLayout();
            splitContSQLDDL.Panel2.SuspendLayout();
            splitContSQLDDL.SuspendLayout();
            pnlSQL.SuspendLayout();
            pnlBotonesSQL.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tabResultados.SuspendLayout();
            tpResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridResultados).BeginInit();
            tpMensajes.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContSQLDDL);
            splitContainer1.Panel2.Controls.Add(toolStrip1);
            splitContainer1.Panel2MinSize = 500;
            splitContainer1.Size = new Size(1264, 681);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 32);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "Navegador";
            // 
            // treeView1
            // 
            treeView1.ContextMenuStrip = menuTreeView;
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 32);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(250, 649);
            treeView1.TabIndex = 0;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
            // 
            // menuTreeView
            // 
            menuTreeView.Items.AddRange(new ToolStripItem[] { verDDLToolStripMenuItem, exportarDDLToolStripMenuItem, selectToolStripMenuItem, crearToolStripMenuItem });
            menuTreeView.Name = "menuTreeView";
            menuTreeView.Size = new Size(176, 92);
            menuTreeView.Opening += menuTreeView_Opening;
            // 
            // verDDLToolStripMenuItem
            // 
            verDDLToolStripMenuItem.Name = "verDDLToolStripMenuItem";
            verDDLToolStripMenuItem.Size = new Size(175, 22);
            verDDLToolStripMenuItem.Text = "Ver DDL";
            verDDLToolStripMenuItem.Click += verDDLToolStripMenuItem_Click;
            // 
            // exportarDDLToolStripMenuItem
            // 
            exportarDDLToolStripMenuItem.Name = "exportarDDLToolStripMenuItem";
            exportarDDLToolStripMenuItem.Size = new Size(175, 22);
            exportarDDLToolStripMenuItem.Text = "Exportar DDL a SQL";
            exportarDDLToolStripMenuItem.Click += exportarDDLToolStripMenuItem_Click;
            // 
            // selectToolStripMenuItem
            // 
            selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            selectToolStripMenuItem.Size = new Size(175, 22);
            selectToolStripMenuItem.Text = "Select * (Top 100))";
            selectToolStripMenuItem.Click += selectToolStripMenuItem_Click;
            // 
            // crearToolStripMenuItem
            // 
            crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            crearToolStripMenuItem.Size = new Size(175, 22);
            crearToolStripMenuItem.Text = "Crear...";
            // 
            // splitContSQLDDL
            // 
            splitContSQLDDL.Dock = DockStyle.Fill;
            splitContSQLDDL.Location = new Point(0, 25);
            splitContSQLDDL.Name = "splitContSQLDDL";
            splitContSQLDDL.Orientation = Orientation.Horizontal;
            // 
            // splitContSQLDDL.Panel1
            // 
            splitContSQLDDL.Panel1.Controls.Add(pnlSQL);
            // 
            // splitContSQLDDL.Panel2
            // 
            splitContSQLDDL.Panel2.Controls.Add(tabResultados);
            splitContSQLDDL.Size = new Size(1010, 656);
            splitContSQLDDL.SplitterDistance = 323;
            splitContSQLDDL.TabIndex = 0;
            // 
            // pnlSQL
            // 
            pnlSQL.Controls.Add(richTxtBoxSQL);
            pnlSQL.Controls.Add(pnlBotonesSQL);
            pnlSQL.Dock = DockStyle.Fill;
            pnlSQL.Location = new Point(0, 0);
            pnlSQL.Name = "pnlSQL";
            pnlSQL.Size = new Size(1010, 323);
            pnlSQL.TabIndex = 0;
            // 
            // richTxtBoxSQL
            // 
            richTxtBoxSQL.AcceptsTab = true;
            richTxtBoxSQL.Dock = DockStyle.Fill;
            richTxtBoxSQL.Font = new Font("Consolas", 10F);
            richTxtBoxSQL.HideSelection = false;
            richTxtBoxSQL.Location = new Point(0, 54);
            richTxtBoxSQL.Name = "richTxtBoxSQL";
            richTxtBoxSQL.Size = new Size(1010, 269);
            richTxtBoxSQL.TabIndex = 1;
            richTxtBoxSQL.Text = "";
            richTxtBoxSQL.WordWrap = false;
            richTxtBoxSQL.TextChanged += richTxtBoxSQL_TextChanged;
            // 
            // pnlBotonesSQL
            // 
            pnlBotonesSQL.Controls.Add(flowLayoutPanel1);
            pnlBotonesSQL.Dock = DockStyle.Top;
            pnlBotonesSQL.Location = new Point(0, 0);
            pnlBotonesSQL.Name = "pnlBotonesSQL";
            pnlBotonesSQL.Size = new Size(1010, 54);
            pnlBotonesSQL.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSQL);
            flowLayoutPanel1.Controls.Add(btnDDL);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(310, 54);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSQL
            // 
            btnSQL.AutoSize = true;
            btnSQL.Font = new Font("Segoe UI", 12F);
            btnSQL.Location = new Point(3, 3);
            btnSQL.Name = "btnSQL";
            btnSQL.Size = new Size(85, 40);
            btnSQL.TabIndex = 0;
            btnSQL.Text = "SQL";
            btnSQL.UseVisualStyleBackColor = true;
            btnSQL.Click += btnSQL_Click;
            // 
            // btnDDL
            // 
            btnDDL.AutoSize = true;
            btnDDL.Font = new Font("Segoe UI", 12F);
            btnDDL.Location = new Point(94, 3);
            btnDDL.Name = "btnDDL";
            btnDDL.Size = new Size(95, 40);
            btnDDL.TabIndex = 1;
            btnDDL.Text = "DDL";
            btnDDL.UseVisualStyleBackColor = true;
            btnDDL.Click += btnDDL_Click;
            // 
            // tabResultados
            // 
            tabResultados.Controls.Add(tpResultados);
            tabResultados.Controls.Add(tpMensajes);
            tabResultados.Dock = DockStyle.Fill;
            tabResultados.Location = new Point(0, 0);
            tabResultados.Name = "tabResultados";
            tabResultados.SelectedIndex = 0;
            tabResultados.Size = new Size(1010, 329);
            tabResultados.TabIndex = 0;
            // 
            // tpResultados
            // 
            tpResultados.Controls.Add(dataGridResultados);
            tpResultados.Location = new Point(4, 24);
            tpResultados.Name = "tpResultados";
            tpResultados.Padding = new Padding(3);
            tpResultados.Size = new Size(1002, 301);
            tpResultados.TabIndex = 0;
            tpResultados.Text = "Resultados";
            tpResultados.UseVisualStyleBackColor = true;
            // 
            // dataGridResultados
            // 
            dataGridResultados.AllowUserToAddRows = false;
            dataGridResultados.AllowUserToDeleteRows = false;
            dataGridResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridResultados.Dock = DockStyle.Fill;
            dataGridResultados.Location = new Point(3, 3);
            dataGridResultados.MultiSelect = false;
            dataGridResultados.Name = "dataGridResultados";
            dataGridResultados.ReadOnly = true;
            dataGridResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridResultados.Size = new Size(996, 295);
            dataGridResultados.TabIndex = 0;
            // 
            // tpMensajes
            // 
            tpMensajes.Controls.Add(richTxtBoxMensajes);
            tpMensajes.Location = new Point(4, 24);
            tpMensajes.Name = "tpMensajes";
            tpMensajes.Padding = new Padding(3);
            tpMensajes.Size = new Size(1002, 301);
            tpMensajes.TabIndex = 1;
            tpMensajes.Text = "Mensajes";
            tpMensajes.UseVisualStyleBackColor = true;
            // 
            // richTxtBoxMensajes
            // 
            richTxtBoxMensajes.Dock = DockStyle.Fill;
            richTxtBoxMensajes.Font = new Font("Consolas", 10F);
            richTxtBoxMensajes.Location = new Point(3, 3);
            richTxtBoxMensajes.Name = "richTxtBoxMensajes";
            richTxtBoxMensajes.Size = new Size(996, 295);
            richTxtBoxMensajes.TabIndex = 0;
            richTxtBoxMensajes.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolTipEjecutar, toolTipNuevoQuery, toolTipLimpiar, toolStripSeparator1, toolTipExport, toolTipRefrescar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1010, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolTipEjecutar
            // 
            toolTipEjecutar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolTipEjecutar.Image = (Image)resources.GetObject("toolTipEjecutar.Image");
            toolTipEjecutar.ImageTransparentColor = Color.Magenta;
            toolTipEjecutar.Name = "toolTipEjecutar";
            toolTipEjecutar.Size = new Size(53, 22);
            toolTipEjecutar.Text = "Ejecutar";
            toolTipEjecutar.Click += toolTipEjecutar_Click;
            // 
            // toolTipNuevoQuery
            // 
            toolTipNuevoQuery.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolTipNuevoQuery.Image = (Image)resources.GetObject("toolTipNuevoQuery.Image");
            toolTipNuevoQuery.ImageTransparentColor = Color.Magenta;
            toolTipNuevoQuery.Name = "toolTipNuevoQuery";
            toolTipNuevoQuery.Size = new Size(81, 22);
            toolTipNuevoQuery.Text = "Nuevo Query";
            toolTipNuevoQuery.Click += toolTipNuevoQuery_Click;
            // 
            // toolTipLimpiar
            // 
            toolTipLimpiar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolTipLimpiar.Image = (Image)resources.GetObject("toolTipLimpiar.Image");
            toolTipLimpiar.ImageTransparentColor = Color.Magenta;
            toolTipLimpiar.Name = "toolTipLimpiar";
            toolTipLimpiar.Size = new Size(85, 22);
            toolTipLimpiar.Text = "Limpiar Salida";
            toolTipLimpiar.Click += toolTipLimpiar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolTipExport
            // 
            toolTipExport.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolTipExport.Image = (Image)resources.GetObject("toolTipExport.Image");
            toolTipExport.ImageTransparentColor = Color.Magenta;
            toolTipExport.Name = "toolTipExport";
            toolTipExport.Size = new Size(112, 22);
            toolTipExport.Text = "Exportar DDL a SQL";
            toolTipExport.Click += toolTipExport_Click;
            // 
            // toolTipRefrescar
            // 
            toolTipRefrescar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolTipRefrescar.Image = (Image)resources.GetObject("toolTipRefrescar.Image");
            toolTipRefrescar.ImageTransparentColor = Color.Magenta;
            toolTipRefrescar.Name = "toolTipRefrescar";
            toolTipRefrescar.Size = new Size(59, 22);
            toolTipRefrescar.Text = "Refrescar";
            toolTipRefrescar.Click += toolTipRefrescar_Click;
            // 
            // PaginaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(splitContainer1);
            Name = "PaginaPrincipal";
            Text = "Gestor DB2";
            FormClosed += PaginaPrincipal_FormClosed;
            Load += PaginaPrincipal_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuTreeView.ResumeLayout(false);
            splitContSQLDDL.Panel1.ResumeLayout(false);
            splitContSQLDDL.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContSQLDDL).EndInit();
            splitContSQLDDL.ResumeLayout(false);
            pnlSQL.ResumeLayout(false);
            pnlBotonesSQL.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tabResultados.ResumeLayout(false);
            tpResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridResultados).EndInit();
            tpMensajes.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private SplitContainer splitContSQLDDL;
        private Panel pnlSQL;
        private Panel pnlBotonesSQL;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSQL;
        private Button btnDDL;
        private RichTextBox richTxtBoxSQL;
        private TabControl tabResultados;
        private TabPage tpResultados;
        private DataGridView dataGridResultados;
        private TabPage tpMensajes;
        private RichTextBox richTxtBoxMensajes;
        private ToolStrip toolStrip1;
        private ToolStripButton toolTipEjecutar;
        private ToolStripButton toolTipLimpiar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolTipExport;
        private ToolStripButton toolTipNuevoQuery;
        private ContextMenuStrip menuTreeView;
        private ToolStripMenuItem verDDLToolStripMenuItem;
        private ToolStripMenuItem exportarDDLToolStripMenuItem;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem crearToolStripMenuItem;
        private Panel panel1;
        private Label label1;
        private ToolStripButton toolTipRefrescar;
    }
}