namespace Recog.Data
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_setdir = new System.Windows.Forms.Button();
            this.txt_dirpath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_selectall = new System.Windows.Forms.Button();
            this.btn_unselectall = new System.Windows.Forms.Button();
            this.dg_humans = new System.Windows.Forms.DataGridView();
            this.group_filter = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_tests = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dp_begdate = new System.Windows.Forms.DateTimePicker();
            this.dp_enddate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chb_fam = new System.Windows.Forms.CheckBox();
            this.chb_tests = new System.Windows.Forms.CheckBox();
            this.cb_fam = new System.Windows.Forms.ComboBox();
            this.btn_startexport = new System.Windows.Forms.Button();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_humans)).BeginInit();
            this.group_filter.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.42027F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.57974F));
            this.tableLayoutPanel1.Controls.Add(this.btn_setdir, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_dirpath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_startexport, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pb_progress, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 519);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_setdir
            // 
            this.btn_setdir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_setdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_setdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_setdir.Location = new System.Drawing.Point(541, 3);
            this.btn_setdir.Name = "btn_setdir";
            this.btn_setdir.Size = new System.Drawing.Size(200, 23);
            this.btn_setdir.TabIndex = 0;
            this.btn_setdir.Text = "Указать каталог";
            this.btn_setdir.UseVisualStyleBackColor = true;
            this.btn_setdir.Click += new System.EventHandler(this.btn_setdir_Click);
            // 
            // txt_dirpath
            // 
            this.txt_dirpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dirpath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_dirpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_dirpath.Location = new System.Drawing.Point(3, 3);
            this.txt_dirpath.Name = "txt_dirpath";
            this.txt_dirpath.ReadOnly = true;
            this.txt_dirpath.Size = new System.Drawing.Size(532, 22);
            this.txt_dirpath.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 452);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доступные респонденты";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_selectall, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_unselectall, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.dg_humans, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.group_filter, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(732, 433);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_selectall
            // 
            this.btn_selectall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_selectall.Enabled = false;
            this.btn_selectall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectall.Location = new System.Drawing.Point(3, 406);
            this.btn_selectall.Name = "btn_selectall";
            this.btn_selectall.Size = new System.Drawing.Size(360, 24);
            this.btn_selectall.TabIndex = 0;
            this.btn_selectall.Text = "Выбрать все";
            this.btn_selectall.UseVisualStyleBackColor = true;
            this.btn_selectall.Click += new System.EventHandler(this.btn_selectall_Click);
            // 
            // btn_unselectall
            // 
            this.btn_unselectall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_unselectall.Enabled = false;
            this.btn_unselectall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_unselectall.Location = new System.Drawing.Point(369, 406);
            this.btn_unselectall.Name = "btn_unselectall";
            this.btn_unselectall.Size = new System.Drawing.Size(360, 24);
            this.btn_unselectall.TabIndex = 1;
            this.btn_unselectall.Text = "Снять выделение";
            this.btn_unselectall.UseVisualStyleBackColor = true;
            this.btn_unselectall.Click += new System.EventHandler(this.btn_unselectall_Click);
            // 
            // dg_humans
            // 
            this.dg_humans.AllowUserToAddRows = false;
            this.dg_humans.AllowUserToDeleteRows = false;
            this.dg_humans.AllowUserToResizeRows = false;
            this.dg_humans.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel2.SetColumnSpan(this.dg_humans, 2);
            this.dg_humans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_humans.Enabled = false;
            this.dg_humans.Location = new System.Drawing.Point(3, 150);
            this.dg_humans.Name = "dg_humans";
            this.dg_humans.RowHeadersVisible = false;
            this.dg_humans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_humans.Size = new System.Drawing.Size(726, 250);
            this.dg_humans.TabIndex = 4;
            // 
            // group_filter
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.group_filter, 2);
            this.group_filter.Controls.Add(this.tableLayoutPanel3);
            this.group_filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_filter.Location = new System.Drawing.Point(3, 3);
            this.group_filter.Name = "group_filter";
            this.group_filter.Size = new System.Drawing.Size(726, 141);
            this.group_filter.TabIndex = 7;
            this.group_filter.TabStop = false;
            this.group_filter.Text = "Фильтр экспорта";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 271F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cb_tests, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.chb_fam, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.chb_tests, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.cb_fam, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(720, 122);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Фамилия";
            // 
            // cb_tests
            // 
            this.cb_tests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_tests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tests.FormattingEnabled = true;
            this.cb_tests.Location = new System.Drawing.Point(155, 28);
            this.cb_tests.MaxDropDownItems = 20;
            this.cb_tests.Name = "cb_tests";
            this.cb_tests.Size = new System.Drawing.Size(265, 21);
            this.cb_tests.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Тест";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 66);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дата тестирования";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.30241F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.69759F));
            this.tableLayoutPanel4.Controls.Add(this.dp_begdate, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.dp_enddate, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(411, 47);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // dp_begdate
            // 
            this.dp_begdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dp_begdate.Enabled = false;
            this.dp_begdate.Location = new System.Drawing.Point(149, 3);
            this.dp_begdate.Name = "dp_begdate";
            this.dp_begdate.Size = new System.Drawing.Size(259, 20);
            this.dp_begdate.TabIndex = 0;
            // 
            // dp_enddate
            // 
            this.dp_enddate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dp_enddate.Enabled = false;
            this.dp_enddate.Location = new System.Drawing.Point(149, 28);
            this.dp_enddate.Name = "dp_enddate";
            this.dp_enddate.Size = new System.Drawing.Size(259, 20);
            this.dp_enddate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Начальная дата";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Конечная дата";
            // 
            // chb_fam
            // 
            this.chb_fam.AutoSize = true;
            this.chb_fam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_fam.Enabled = false;
            this.chb_fam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_fam.Location = new System.Drawing.Point(135, 3);
            this.chb_fam.Name = "chb_fam";
            this.chb_fam.Size = new System.Drawing.Size(14, 19);
            this.chb_fam.TabIndex = 14;
            this.chb_fam.Text = "checkBox1";
            this.chb_fam.UseVisualStyleBackColor = true;
            // 
            // chb_tests
            // 
            this.chb_tests.AutoSize = true;
            this.chb_tests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_tests.Enabled = false;
            this.chb_tests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_tests.Location = new System.Drawing.Point(135, 28);
            this.chb_tests.Name = "chb_tests";
            this.chb_tests.Size = new System.Drawing.Size(14, 19);
            this.chb_tests.TabIndex = 16;
            this.chb_tests.Text = "checkBox3";
            this.chb_tests.UseVisualStyleBackColor = true;
            // 
            // cb_fam
            // 
            this.cb_fam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_fam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_fam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_fam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_fam.FormattingEnabled = true;
            this.cb_fam.Location = new System.Drawing.Point(155, 3);
            this.cb_fam.MaxDropDownItems = 20;
            this.cb_fam.Name = "cb_fam";
            this.cb_fam.Size = new System.Drawing.Size(265, 21);
            this.cb_fam.TabIndex = 17;
            // 
            // btn_startexport
            // 
            this.btn_startexport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_startexport.Enabled = false;
            this.btn_startexport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_startexport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_startexport.Location = new System.Drawing.Point(541, 490);
            this.btn_startexport.Name = "btn_startexport";
            this.btn_startexport.Size = new System.Drawing.Size(200, 26);
            this.btn_startexport.TabIndex = 3;
            this.btn_startexport.Text = "Начать экспорт";
            this.btn_startexport.UseVisualStyleBackColor = true;
            this.btn_startexport.Click += new System.EventHandler(this.btn_startexport_Click);
            // 
            // pb_progress
            // 
            this.pb_progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_progress.Enabled = false;
            this.pb_progress.Location = new System.Drawing.Point(3, 490);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(532, 26);
            this.pb_progress.Step = 1;
            this.pb_progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_progress.TabIndex = 4;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Экспорт респондентов";
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_humans)).EndInit();
            this.group_filter.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_setdir;
        private System.Windows.Forms.TextBox txt_dirpath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_startexport;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_selectall;
        private System.Windows.Forms.Button btn_unselectall;
        private System.Windows.Forms.DataGridView dg_humans;
        private System.Windows.Forms.GroupBox group_filter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_tests;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DateTimePicker dp_begdate;
        private System.Windows.Forms.DateTimePicker dp_enddate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chb_fam;
        private System.Windows.Forms.CheckBox chb_tests;
        private System.Windows.Forms.ComboBox cb_fam;

    }
}