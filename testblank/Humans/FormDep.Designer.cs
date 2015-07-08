namespace Recog.Humans
{
    partial class FormDep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDep));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dg_deps = new System.Windows.Forms.DataGridView();
            this.txt_dep = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_deps)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dg_deps, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_dep, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_add, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 313);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dg_deps
            // 
            this.dg_deps.AllowUserToAddRows = false;
            this.dg_deps.AllowUserToDeleteRows = false;
            this.dg_deps.AllowUserToResizeRows = false;
            this.dg_deps.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dg_deps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_deps.Location = new System.Drawing.Point(3, 71);
            this.dg_deps.Name = "dg_deps";
            this.dg_deps.ReadOnly = true;
            this.dg_deps.RowHeadersVisible = false;
            this.dg_deps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_deps.Size = new System.Drawing.Size(465, 239);
            this.dg_deps.TabIndex = 4;
            // 
            // txt_dep
            // 
            this.txt_dep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_dep.Location = new System.Drawing.Point(3, 3);
            this.txt_dep.Name = "txt_dep";
            this.txt_dep.Size = new System.Drawing.Size(465, 26);
            this.txt_dep.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.Location = new System.Drawing.Point(3, 34);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(465, 31);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // FormDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 313);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление подразделений";
            this.Load += new System.EventHandler(this.FormDep_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_deps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txt_dep;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dg_deps;
    }
}