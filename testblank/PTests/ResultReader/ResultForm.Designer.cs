namespace Recog.PTests.ResultReader
{
    partial class ResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.dg_humans = new System.Windows.Forms.DataGridView();
            this.btn_delhuman = new System.Windows.Forms.Button();
            this.btn_read = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_showchart = new System.Windows.Forms.Button();
            this.dg_references = new System.Windows.Forms.DataGridView();
            this.idr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_testresults = new System.Windows.Forms.DataGridView();
            this.idt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tstdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_printresult = new System.Windows.Forms.Button();
            this.btn_printchar = new System.Windows.Forms.Button();
            this.btn_show_answers = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_humans)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_references)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_testresults)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.74212F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.25788F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 340);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.88764F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.11236F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tb_search, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dg_humans, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_delhuman, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btn_read, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(445, 334);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Поиск по фамилии";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_search
            // 
            this.tb_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_search.Location = new System.Drawing.Point(135, 3);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(307, 26);
            this.tb_search.TabIndex = 2;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // dg_humans
            // 
            this.dg_humans.AllowUserToAddRows = false;
            this.dg_humans.AllowUserToDeleteRows = false;
            this.dg_humans.AllowUserToResizeRows = false;
            this.dg_humans.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_humans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tableLayoutPanel3.SetColumnSpan(this.dg_humans, 2);
            this.dg_humans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_humans.Location = new System.Drawing.Point(3, 33);
            this.dg_humans.MultiSelect = false;
            this.dg_humans.Name = "dg_humans";
            this.dg_humans.ReadOnly = true;
            this.dg_humans.RowHeadersVisible = false;
            this.dg_humans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_humans.Size = new System.Drawing.Size(439, 263);
            this.dg_humans.TabIndex = 3;
            this.dg_humans.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_humans_RowEnter);
            // 
            // btn_delhuman
            // 
            this.btn_delhuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_delhuman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delhuman.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_delhuman.Location = new System.Drawing.Point(135, 302);
            this.btn_delhuman.Name = "btn_delhuman";
            this.btn_delhuman.Size = new System.Drawing.Size(307, 29);
            this.btn_delhuman.TabIndex = 4;
            this.btn_delhuman.Text = "Удалить данные";
            this.btn_delhuman.UseVisualStyleBackColor = true;
            this.btn_delhuman.Click += new System.EventHandler(this.btn_delhuman_Click);
            // 
            // btn_read
            // 
            this.btn_read.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_read.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_read.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_read.Location = new System.Drawing.Point(3, 302);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(126, 29);
            this.btn_read.TabIndex = 5;
            this.btn_read.Text = "Просмотр";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_showchart, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dg_references, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.dg_testresults, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btn_printresult, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_printchar, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.btn_show_answers, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(454, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(400, 334);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_showchart
            // 
            this.btn_showchart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_showchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_showchart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_showchart.Location = new System.Drawing.Point(3, 107);
            this.btn_showchart.Name = "btn_showchart";
            this.btn_showchart.Size = new System.Drawing.Size(394, 29);
            this.btn_showchart.TabIndex = 6;
            this.btn_showchart.Text = "Показать график скорости прохождения";
            this.btn_showchart.UseVisualStyleBackColor = true;
            this.btn_showchart.Click += new System.EventHandler(this.btn_showchart_Click);
            // 
            // dg_references
            // 
            this.dg_references.AllowUserToAddRows = false;
            this.dg_references.AllowUserToDeleteRows = false;
            this.dg_references.AllowUserToResizeRows = false;
            this.dg_references.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_references.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dg_references.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_references.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idr,
            this.name});
            this.tableLayoutPanel2.SetColumnSpan(this.dg_references, 2);
            this.dg_references.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_references.Location = new System.Drawing.Point(3, 232);
            this.dg_references.MultiSelect = false;
            this.dg_references.Name = "dg_references";
            this.dg_references.ReadOnly = true;
            this.dg_references.RowHeadersVisible = false;
            this.dg_references.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_references.Size = new System.Drawing.Size(394, 63);
            this.dg_references.TabIndex = 5;
            this.dg_references.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_references_RowEnter);
            // 
            // idr
            // 
            this.idr.HeaderText = "Column1";
            this.idr.Name = "idr";
            this.idr.ReadOnly = true;
            this.idr.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Характеристика";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // dg_testresults
            // 
            this.dg_testresults.AllowUserToAddRows = false;
            this.dg_testresults.AllowUserToDeleteRows = false;
            this.dg_testresults.AllowUserToResizeRows = false;
            this.dg_testresults.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_testresults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dg_testresults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_testresults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idt,
            this.idtt,
            this.tsel,
            this.tstdate,
            this.tname,
            this.tmode});
            this.tableLayoutPanel2.SetColumnSpan(this.dg_testresults, 2);
            this.dg_testresults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_testresults.Location = new System.Drawing.Point(3, 23);
            this.dg_testresults.Name = "dg_testresults";
            this.dg_testresults.RowHeadersVisible = false;
            this.dg_testresults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_testresults.Size = new System.Drawing.Size(394, 78);
            this.dg_testresults.TabIndex = 4;
            this.dg_testresults.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dg_testresults_CellMouseClick);
            this.dg_testresults.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_testresults_RowEnter);
            // 
            // idt
            // 
            this.idt.HeaderText = "idt";
            this.idt.Name = "idt";
            this.idt.Visible = false;
            // 
            // idtt
            // 
            this.idtt.HeaderText = "Column1";
            this.idtt.Name = "idtt";
            this.idtt.Visible = false;
            // 
            // tsel
            // 
            this.tsel.HeaderText = "Выбор";
            this.tsel.Name = "tsel";
            this.tsel.Width = 50;
            // 
            // tstdate
            // 
            this.tstdate.HeaderText = "Дата";
            this.tstdate.Name = "tstdate";
            this.tstdate.ReadOnly = true;
            this.tstdate.Width = 120;
            // 
            // tname
            // 
            this.tname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tname.HeaderText = "Тест";
            this.tname.Name = "tname";
            this.tname.ReadOnly = true;
            // 
            // tmode
            // 
            this.tmode.HeaderText = "Режим";
            this.tmode.Name = "tmode";
            this.tmode.ReadOnly = true;
            this.tmode.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Доступные результаты тестов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(394, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Доступные характеристики";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_printresult
            // 
            this.btn_printresult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_printresult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_printresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_printresult.Location = new System.Drawing.Point(3, 142);
            this.btn_printresult.Name = "btn_printresult";
            this.btn_printresult.Size = new System.Drawing.Size(394, 29);
            this.btn_printresult.TabIndex = 2;
            this.btn_printresult.Text = "Вывод результата в RTF";
            this.btn_printresult.UseVisualStyleBackColor = true;
            this.btn_printresult.Click += new System.EventHandler(this.btn_printresult_Click);
            // 
            // btn_printchar
            // 
            this.btn_printchar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_printchar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_printchar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_printchar.Location = new System.Drawing.Point(3, 301);
            this.btn_printchar.Name = "btn_printchar";
            this.btn_printchar.Size = new System.Drawing.Size(394, 30);
            this.btn_printchar.TabIndex = 3;
            this.btn_printchar.Text = "Вывод характеристики в RTF";
            this.btn_printchar.UseVisualStyleBackColor = true;
            this.btn_printchar.Click += new System.EventHandler(this.btn_printchar_Click);
            // 
            // btn_show_answers
            // 
            this.btn_show_answers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_show_answers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show_answers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_show_answers.Location = new System.Drawing.Point(3, 177);
            this.btn_show_answers.Name = "btn_show_answers";
            this.btn_show_answers.Size = new System.Drawing.Size(394, 29);
            this.btn_show_answers.TabIndex = 7;
            this.btn_show_answers.Text = "Просмотр ответов теста";
            this.btn_show_answers.UseVisualStyleBackColor = true;
            this.btn_show_answers.Click += new System.EventHandler(this.btn_show_answers_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 340);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultForm";
            this.Text = "Результаты тестов";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_humans)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_references)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_testresults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_printresult;
        private System.Windows.Forms.Button btn_printchar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.DataGridView dg_humans;
        private System.Windows.Forms.DataGridView dg_references;
        private System.Windows.Forms.DataGridView dg_testresults;
        private System.Windows.Forms.DataGridViewTextBoxColumn idr;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn idt;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tsel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tstdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn tname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmode;
        private System.Windows.Forms.Button btn_delhuman;
        private System.Windows.Forms.Button btn_showchart;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_show_answers;
    }
}