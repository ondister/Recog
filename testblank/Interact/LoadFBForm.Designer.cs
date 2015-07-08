namespace Recog.Interact
{
    partial class LoadFBForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadFBForm));
            this.btn_load = new System.Windows.Forms.Button();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lst_manual = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dp_mindate = new System.Windows.Forms.DateTimePicker();
            this.dp_maxdate = new System.Windows.Forms.DateTimePicker();
            this.lb_tstcnt = new System.Windows.Forms.Label();
            this.tbn_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_load.Location = new System.Drawing.Point(403, 3);
            this.btn_load.Name = "btn_load";
            this.tableLayoutPanel1.SetRowSpan(this.btn_load, 2);
            this.btn_load.Size = new System.Drawing.Size(229, 168);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "Выгрузить тест";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // pb_progress
            // 
            this.pb_progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_progress.Location = new System.Drawing.Point(403, 212);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(229, 20);
            this.pb_progress.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lst_manual, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_load, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_progress, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbn_cancel, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 235);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lst_manual
            // 
            this.lst_manual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_manual.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lst_manual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_manual.FullRowSelect = true;
            this.lst_manual.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lst_manual.HideSelection = false;
            this.lst_manual.Location = new System.Drawing.Point(3, 3);
            this.lst_manual.MultiSelect = false;
            this.lst_manual.Name = "lst_manual";
            this.tableLayoutPanel1.SetRowSpan(this.lst_manual, 4);
            this.lst_manual.Size = new System.Drawing.Size(194, 229);
            this.lst_manual.TabIndex = 3;
            this.lst_manual.UseCompatibleStateImageBehavior = false;
            this.lst_manual.View = System.Windows.Forms.View.Details;
            this.lst_manual.SelectedIndexChanged += new System.EventHandler(this.lst_manual_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Наименование";
            this.columnHeader2.Width = 155;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(203, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 4);
            this.groupBox1.Size = new System.Drawing.Size(194, 229);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Диапазон дат";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dp_mindate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dp_maxdate, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lb_tstcnt, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(188, 210);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "От:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "До:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dp_mindate
            // 
            this.dp_mindate.Enabled = false;
            this.dp_mindate.Location = new System.Drawing.Point(3, 23);
            this.dp_mindate.Name = "dp_mindate";
            this.dp_mindate.Size = new System.Drawing.Size(182, 20);
            this.dp_mindate.TabIndex = 2;
            // 
            // dp_maxdate
            // 
            this.dp_maxdate.Enabled = false;
            this.dp_maxdate.Location = new System.Drawing.Point(3, 68);
            this.dp_maxdate.Name = "dp_maxdate";
            this.dp_maxdate.Size = new System.Drawing.Size(182, 20);
            this.dp_maxdate.TabIndex = 3;
            // 
            // lb_tstcnt
            // 
            this.lb_tstcnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_tstcnt.AutoSize = true;
            this.lb_tstcnt.Location = new System.Drawing.Point(3, 96);
            this.lb_tstcnt.Name = "lb_tstcnt";
            this.lb_tstcnt.Size = new System.Drawing.Size(182, 13);
            this.lb_tstcnt.TabIndex = 4;
            this.lb_tstcnt.Text = "Чило тестов";
            // 
            // tbn_cancel
            // 
            this.tbn_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbn_cancel.Enabled = false;
            this.tbn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbn_cancel.Location = new System.Drawing.Point(403, 177);
            this.tbn_cancel.Name = "tbn_cancel";
            this.tbn_cancel.Size = new System.Drawing.Size(229, 29);
            this.tbn_cancel.TabIndex = 5;
            this.tbn_cancel.Text = "Отмена";
            this.tbn_cancel.UseVisualStyleBackColor = true;
            this.tbn_cancel.Click += new System.EventHandler(this.tbn_cancel_Click);
            // 
            // LoadFBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 235);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadFBForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выгрузка результатов в ексель";
            this.Load += new System.EventHandler(this.LoadFBForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.ProgressBar pb_progress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lst_manual;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dp_mindate;
        private System.Windows.Forms.DateTimePicker dp_maxdate;
        private System.Windows.Forms.Label lb_tstcnt;
        private System.Windows.Forms.Button tbn_cancel;
    }
}