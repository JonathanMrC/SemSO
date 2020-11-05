namespace Actividad1
{
    partial class Form
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelInicial = new System.Windows.Forms.Panel();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.nudCantProcesos = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlproceso = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTerminados = new System.Windows.Forms.Panel();
            this.txtbox_terminados = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_npterminados = new System.Windows.Forms.Label();
            this.pnlEjecucion = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.ComenzarProceso = new System.Windows.Forms.Button();
            this.lbltt = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtboxproceso_act = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlnuevos = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtboxbloqueados = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtbox_listos = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblnuevos = new System.Windows.Forms.Label();
            this.pnl_datgrid = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lbltt_pnlfin = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnMostrarAyuda = new System.Windows.Forms.Button();
            this.btnAyudadgv = new System.Windows.Forms.Button();
            this.panelInicial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantProcesos)).BeginInit();
            this.pnlproceso.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlTerminados.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlEjecucion.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlnuevos.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_datgrid.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInicial
            // 
            this.panelInicial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panelInicial.Controls.Add(this.btnComenzar);
            this.panelInicial.Controls.Add(this.nudCantProcesos);
            this.panelInicial.Controls.Add(this.label1);
            this.panelInicial.Location = new System.Drawing.Point(0, 0);
            this.panelInicial.Name = "panelInicial";
            this.panelInicial.Size = new System.Drawing.Size(27, 521);
            this.panelInicial.TabIndex = 0;
            // 
            // btnComenzar
            // 
            this.btnComenzar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnComenzar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnComenzar.FlatAppearance.BorderSize = 0;
            this.btnComenzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComenzar.ForeColor = System.Drawing.Color.White;
            this.btnComenzar.Location = new System.Drawing.Point(-32, 268);
            this.btnComenzar.MaximumSize = new System.Drawing.Size(100, 20);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(100, 20);
            this.btnComenzar.TabIndex = 2;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.UseVisualStyleBackColor = false;
            this.btnComenzar.Click += new System.EventHandler(this.PrimerEtapa);
            // 
            // nudCantProcesos
            // 
            this.nudCantProcesos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudCantProcesos.Location = new System.Drawing.Point(-55, 218);
            this.nudCantProcesos.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCantProcesos.MaximumSize = new System.Drawing.Size(150, 0);
            this.nudCantProcesos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantProcesos.Name = "nudCantProcesos";
            this.nudCantProcesos.Size = new System.Drawing.Size(150, 20);
            this.nudCantProcesos.TabIndex = 1;
            this.nudCantProcesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCantProcesos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-121, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese la cantidad de procesos:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlproceso
            // 
            this.pnlproceso.Controls.Add(this.tableLayoutPanel1);
            this.pnlproceso.Location = new System.Drawing.Point(56, 0);
            this.pnlproceso.Name = "pnlproceso";
            this.pnlproceso.Size = new System.Drawing.Size(429, 521);
            this.pnlproceso.TabIndex = 2;
            this.pnlproceso.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(191)))), ((int)(((byte)(215)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pnlTerminados, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlEjecucion, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlnuevos, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(429, 521);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlTerminados
            // 
            this.pnlTerminados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.pnlTerminados.Controls.Add(this.txtbox_terminados);
            this.pnlTerminados.Controls.Add(this.panel2);
            this.pnlTerminados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTerminados.Location = new System.Drawing.Point(286, 0);
            this.pnlTerminados.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTerminados.Name = "pnlTerminados";
            this.pnlTerminados.Size = new System.Drawing.Size(143, 521);
            this.pnlTerminados.TabIndex = 3;
            // 
            // txtbox_terminados
            // 
            this.txtbox_terminados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbox_terminados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.txtbox_terminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_terminados.Location = new System.Drawing.Point(5, 73);
            this.txtbox_terminados.Multiline = true;
            this.txtbox_terminados.Name = "txtbox_terminados";
            this.txtbox_terminados.ReadOnly = true;
            this.txtbox_terminados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbox_terminados.Size = new System.Drawing.Size(133, 436);
            this.txtbox_terminados.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panel2.Controls.Add(this.lbl_npterminados);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 70);
            this.panel2.TabIndex = 0;
            // 
            // lbl_npterminados
            // 
            this.lbl_npterminados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_npterminados.AutoSize = true;
            this.lbl_npterminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_npterminados.Location = new System.Drawing.Point(-23, 24);
            this.lbl_npterminados.Name = "lbl_npterminados";
            this.lbl_npterminados.Size = new System.Drawing.Size(186, 20);
            this.lbl_npterminados.TabIndex = 4;
            this.lbl_npterminados.Text = "Procesos Terminados:";
            this.lbl_npterminados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlEjecucion
            // 
            this.pnlEjecucion.Controls.Add(this.tableLayoutPanel3);
            this.pnlEjecucion.Controls.Add(this.panel4);
            this.pnlEjecucion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEjecucion.Location = new System.Drawing.Point(143, 0);
            this.pnlEjecucion.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEjecucion.Name = "pnlEjecucion";
            this.pnlEjecucion.Size = new System.Drawing.Size(143, 521);
            this.pnlEjecucion.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel10, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.20298F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.79702F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(143, 451);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panel10.Controls.Add(this.btnMostrarAyuda);
            this.panel10.Controls.Add(this.ComenzarProceso);
            this.panel10.Controls.Add(this.lbltt);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 253);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(143, 198);
            this.panel10.TabIndex = 2;
            // 
            // ComenzarProceso
            // 
            this.ComenzarProceso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComenzarProceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.ComenzarProceso.FlatAppearance.BorderSize = 0;
            this.ComenzarProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComenzarProceso.ForeColor = System.Drawing.Color.White;
            this.ComenzarProceso.Location = new System.Drawing.Point(24, 93);
            this.ComenzarProceso.MaximumSize = new System.Drawing.Size(100, 20);
            this.ComenzarProceso.Name = "ComenzarProceso";
            this.ComenzarProceso.Size = new System.Drawing.Size(100, 20);
            this.ComenzarProceso.TabIndex = 1;
            this.ComenzarProceso.Text = "Comenzar";
            this.ComenzarProceso.UseVisualStyleBackColor = false;
            this.ComenzarProceso.Click += new System.EventHandler(this.SegundaEtapa);
            // 
            // lbltt
            // 
            this.lbltt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbltt.AutoSize = true;
            this.lbltt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltt.Location = new System.Drawing.Point(8, 54);
            this.lbltt.Name = "lbltt";
            this.lbltt.Size = new System.Drawing.Size(132, 20);
            this.lbltt.TabIndex = 6;
            this.lbltt.Text = "Tiempo Total: 0";
            this.lbltt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(143, 253);
            this.panel6.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panel7.Controls.Add(this.txtboxproceso_act);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(143, 253);
            this.panel7.TabIndex = 1;
            // 
            // txtboxproceso_act
            // 
            this.txtboxproceso_act.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxproceso_act.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.txtboxproceso_act.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxproceso_act.Location = new System.Drawing.Point(3, 3);
            this.txtboxproceso_act.Multiline = true;
            this.txtboxproceso_act.Name = "txtboxproceso_act";
            this.txtboxproceso_act.ReadOnly = true;
            this.txtboxproceso_act.Size = new System.Drawing.Size(137, 245);
            this.txtboxproceso_act.TabIndex = 2;
            this.txtboxproceso_act.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TeclaEnProcesoAct);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(143, 70);
            this.panel4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-22, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Proceso en ejecucion:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlnuevos
            // 
            this.pnlnuevos.Controls.Add(this.tableLayoutPanel2);
            this.pnlnuevos.Controls.Add(this.panel1);
            this.pnlnuevos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlnuevos.Location = new System.Drawing.Point(0, 0);
            this.pnlnuevos.Margin = new System.Windows.Forms.Padding(0);
            this.pnlnuevos.Name = "pnlnuevos";
            this.pnlnuevos.Size = new System.Drawing.Size(143, 521);
            this.pnlnuevos.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.33194F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.66806F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(143, 486);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panel5.Controls.Add(this.txtboxbloqueados);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 283);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(143, 203);
            this.panel5.TabIndex = 1;
            // 
            // txtboxbloqueados
            // 
            this.txtboxbloqueados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxbloqueados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.txtboxbloqueados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxbloqueados.Location = new System.Drawing.Point(3, 38);
            this.txtboxbloqueados.Multiline = true;
            this.txtboxbloqueados.Name = "txtboxbloqueados";
            this.txtboxbloqueados.ReadOnly = true;
            this.txtboxbloqueados.Size = new System.Drawing.Size(137, 162);
            this.txtboxbloqueados.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panel9.Controls.Add(this.label6);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(143, 35);
            this.panel9.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Bloqueados:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panel3.Controls.Add(this.txtbox_listos);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 283);
            this.panel3.TabIndex = 0;
            // 
            // txtbox_listos
            // 
            this.txtbox_listos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbox_listos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.txtbox_listos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_listos.Location = new System.Drawing.Point(3, 38);
            this.txtbox_listos.Multiline = true;
            this.txtbox_listos.Name = "txtbox_listos";
            this.txtbox_listos.ReadOnly = true;
            this.txtbox_listos.Size = new System.Drawing.Size(137, 242);
            this.txtbox_listos.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.panel8.Controls.Add(this.label4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(143, 35);
            this.panel8.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Listos:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(205)))), ((int)(((byte)(227)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblnuevos);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 35);
            this.panel1.TabIndex = 2;
            // 
            // lblnuevos
            // 
            this.lblnuevos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblnuevos.AutoSize = true;
            this.lblnuevos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnuevos.Location = new System.Drawing.Point(35, 8);
            this.lblnuevos.Name = "lblnuevos";
            this.lblnuevos.Size = new System.Drawing.Size(73, 20);
            this.lblnuevos.TabIndex = 5;
            this.lblnuevos.Text = "Nuevos:";
            this.lblnuevos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_datgrid
            // 
            this.pnl_datgrid.AutoScroll = true;
            this.pnl_datgrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pnl_datgrid.Controls.Add(this.panel12);
            this.pnl_datgrid.Controls.Add(this.panel11);
            this.pnl_datgrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_datgrid.Location = new System.Drawing.Point(508, 0);
            this.pnl_datgrid.Name = "pnl_datgrid";
            this.pnl_datgrid.Size = new System.Drawing.Size(262, 521);
            this.pnl_datgrid.TabIndex = 3;
            this.pnl_datgrid.Visible = false;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.panel11.Controls.Add(this.btnAyudadgv);
            this.panel11.Controls.Add(this.lbltt_pnlfin);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 442);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(262, 79);
            this.panel11.TabIndex = 1;
            // 
            // lbltt_pnlfin
            // 
            this.lbltt_pnlfin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltt_pnlfin.AutoSize = true;
            this.lbltt_pnlfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltt_pnlfin.Location = new System.Drawing.Point(3, 30);
            this.lbltt_pnlfin.Name = "lbltt_pnlfin";
            this.lbltt_pnlfin.Size = new System.Drawing.Size(132, 20);
            this.lbltt_pnlfin.TabIndex = 7;
            this.lbltt_pnlfin.Text = "Tiempo Total: 0";
            this.lbltt_pnlfin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.dgv);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(262, 442);
            this.panel12.TabIndex = 2;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(262, 442);
            this.dgv.TabIndex = 1;
            this.dgv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TeclaenDGV);
            // 
            // btnMostrarAyuda
            // 
            this.btnMostrarAyuda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMostrarAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnMostrarAyuda.FlatAppearance.BorderSize = 0;
            this.btnMostrarAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarAyuda.ForeColor = System.Drawing.Color.White;
            this.btnMostrarAyuda.Location = new System.Drawing.Point(24, 119);
            this.btnMostrarAyuda.MaximumSize = new System.Drawing.Size(100, 20);
            this.btnMostrarAyuda.Name = "btnMostrarAyuda";
            this.btnMostrarAyuda.Size = new System.Drawing.Size(100, 20);
            this.btnMostrarAyuda.TabIndex = 7;
            this.btnMostrarAyuda.Text = "Ayuda";
            this.btnMostrarAyuda.UseVisualStyleBackColor = false;
            this.btnMostrarAyuda.Click += new System.EventHandler(this.btnMostrarAyuda_Click);
            // 
            // btnAyudadgv
            // 
            this.btnAyudadgv.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAyudadgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(54)))));
            this.btnAyudadgv.FlatAppearance.BorderSize = 0;
            this.btnAyudadgv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyudadgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyudadgv.ForeColor = System.Drawing.Color.White;
            this.btnAyudadgv.Location = new System.Drawing.Point(157, 26);
            this.btnAyudadgv.Name = "btnAyudadgv";
            this.btnAyudadgv.Size = new System.Drawing.Size(102, 29);
            this.btnAyudadgv.TabIndex = 8;
            this.btnAyudadgv.Text = "Ayuda";
            this.btnAyudadgv.UseVisualStyleBackColor = false;
            this.btnAyudadgv.Click += new System.EventHandler(this.btnAyudadgv_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(782, 521);
            this.Controls.Add(this.pnl_datgrid);
            this.Controls.Add(this.pnlproceso);
            this.Controls.Add(this.panelInicial);
            this.MinimumSize = new System.Drawing.Size(798, 560);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actividad 6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCerrado);
            this.panelInicial.ResumeLayout(false);
            this.panelInicial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantProcesos)).EndInit();
            this.pnlproceso.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlTerminados.ResumeLayout(false);
            this.pnlTerminados.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlEjecucion.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlnuevos.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_datgrid.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.NumericUpDown nudCantProcesos;
        private System.Windows.Forms.Panel pnlproceso;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlTerminados;
        private System.Windows.Forms.TextBox txtbox_terminados;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_npterminados;
        private System.Windows.Forms.Panel pnlEjecucion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlnuevos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtboxbloqueados;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtbox_listos;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblnuevos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button ComenzarProceso;
        private System.Windows.Forms.Label lbltt;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtboxproceso_act;
        private System.Windows.Forms.Panel pnl_datgrid;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lbltt_pnlfin;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnMostrarAyuda;
        private System.Windows.Forms.Button btnAyudadgv;
    }
}

