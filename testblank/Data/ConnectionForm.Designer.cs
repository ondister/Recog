namespace Recog.Data
{
    partial class ConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_servertype = new System.Windows.Forms.ComboBox();
            this.gb_connsett = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_openpbase = new System.Windows.Forms.Button();
            this.btn_openfbase = new System.Windows.Forms.Button();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.tb_pbase_path = new System.Windows.Forms.TextBox();
            this.tb_fbase_path = new System.Windows.Forms.TextBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_connsett.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 188);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.90551F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.09449F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gb_connsett, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_check, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_save, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 184);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.cb_servertype);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип сервера";
            // 
            // cb_servertype
            // 
            this.cb_servertype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_servertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_servertype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_servertype.FormattingEnabled = true;
            this.cb_servertype.Location = new System.Drawing.Point(3, 16);
            this.cb_servertype.Name = "cb_servertype";
            this.cb_servertype.Size = new System.Drawing.Size(545, 21);
            this.cb_servertype.TabIndex = 0;
            this.cb_servertype.SelectedValueChanged += new System.EventHandler(this.cb_servertype_SelectedValueChanged);
            // 
            // gb_connsett
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gb_connsett, 2);
            this.gb_connsett.Controls.Add(this.tableLayoutPanel2);
            this.gb_connsett.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_connsett.Location = new System.Drawing.Point(3, 53);
            this.gb_connsett.Name = "gb_connsett";
            this.gb_connsett.Size = new System.Drawing.Size(551, 93);
            this.gb_connsett.TabIndex = 1;
            this.gb_connsett.TabStop = false;
            this.gb_connsett.Text = "Параметры подключения";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.0625F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.9375F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_openpbase, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_openfbase, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.tb_ip, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tb_pbase_path, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tb_fbase_path, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(545, 74);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP адрес сервера";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Путь или алиас к базе FPBASE.fdb";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Путь или алиас к базе FFBASE.fdb";
            // 
            // btn_openpbase
            // 
            this.btn_openpbase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_openpbase.Image = ((System.Drawing.Image)(resources.GetObject("btn_openpbase.Image")));
            this.btn_openpbase.Location = new System.Drawing.Point(515, 28);
            this.btn_openpbase.Name = "btn_openpbase";
            this.btn_openpbase.Size = new System.Drawing.Size(27, 19);
            this.btn_openpbase.TabIndex = 3;
            this.btn_openpbase.UseVisualStyleBackColor = true;
            this.btn_openpbase.Click += new System.EventHandler(this.btn_openpbase_Click);
            // 
            // btn_openfbase
            // 
            this.btn_openfbase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_openfbase.Image = ((System.Drawing.Image)(resources.GetObject("btn_openfbase.Image")));
            this.btn_openfbase.Location = new System.Drawing.Point(515, 53);
            this.btn_openfbase.Name = "btn_openfbase";
            this.btn_openfbase.Size = new System.Drawing.Size(27, 19);
            this.btn_openfbase.TabIndex = 4;
            this.btn_openfbase.UseVisualStyleBackColor = true;
            this.btn_openfbase.Click += new System.EventHandler(this.btn_openfbase_Click);
            // 
            // tb_ip
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tb_ip, 2);
            this.tb_ip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ip.Location = new System.Drawing.Point(203, 3);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(339, 20);
            this.tb_ip.TabIndex = 5;
            // 
            // tb_pbase_path
            // 
            this.tb_pbase_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_pbase_path.Location = new System.Drawing.Point(203, 28);
            this.tb_pbase_path.Name = "tb_pbase_path";
            this.tb_pbase_path.Size = new System.Drawing.Size(306, 20);
            this.tb_pbase_path.TabIndex = 6;
            // 
            // tb_fbase_path
            // 
            this.tb_fbase_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_fbase_path.Location = new System.Drawing.Point(203, 53);
            this.tb_fbase_path.Name = "tb_fbase_path";
            this.tb_fbase_path.Size = new System.Drawing.Size(306, 20);
            this.tb_fbase_path.TabIndex = 7;
            // 
            // btn_check
            // 
            this.btn_check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_check.Location = new System.Drawing.Point(3, 152);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(305, 29);
            this.btn_check.TabIndex = 2;
            this.btn_check.Text = "Проверить подключение";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_save.Location = new System.Drawing.Point(314, 152);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(240, 29);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 188);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка подключения к базам данных";
            this.Load += new System.EventHandler(this.ConnectionForm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gb_connsett.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_servertype;
        private System.Windows.Forms.GroupBox gb_connsett;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_openpbase;
        private System.Windows.Forms.Button btn_openfbase;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.TextBox tb_pbase_path;
        private System.Windows.Forms.TextBox tb_fbase_path;
    }
}