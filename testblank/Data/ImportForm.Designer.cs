namespace Recog.Data
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_setdir = new System.Windows.Forms.Button();
            this.txt_dirpath = new System.Windows.Forms.TextBox();
            this.btn_startimport = new System.Windows.Forms.Button();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.8391F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.1609F));
            this.tableLayoutPanel1.Controls.Add(this.btn_setdir, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_dirpath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_startimport, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pb_progress, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 67);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_setdir
            // 
            this.btn_setdir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_setdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_setdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_setdir.Location = new System.Drawing.Point(340, 3);
            this.btn_setdir.Name = "btn_setdir";
            this.btn_setdir.Size = new System.Drawing.Size(148, 23);
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
            this.txt_dirpath.Size = new System.Drawing.Size(331, 22);
            this.txt_dirpath.TabIndex = 1;
            // 
            // btn_startimport
            // 
            this.btn_startimport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_startimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_startimport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_startimport.Location = new System.Drawing.Point(340, 32);
            this.btn_startimport.Name = "btn_startimport";
            this.btn_startimport.Size = new System.Drawing.Size(148, 32);
            this.btn_startimport.TabIndex = 3;
            this.btn_startimport.Text = "Начать импорт";
            this.btn_startimport.UseVisualStyleBackColor = true;
            this.btn_startimport.Click += new System.EventHandler(this.btn_startimport_Click);
            // 
            // pb_progress
            // 
            this.pb_progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_progress.Location = new System.Drawing.Point(3, 32);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(331, 32);
            this.pb_progress.Step = 1;
            this.pb_progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_progress.TabIndex = 4;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 67);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Импорт респондентов";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_setdir;
        private System.Windows.Forms.TextBox txt_dirpath;
        private System.Windows.Forms.Button btn_startimport;
        private System.Windows.Forms.ProgressBar pb_progress;

    }
}