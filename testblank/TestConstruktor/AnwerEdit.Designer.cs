namespace Recog.TestConstruktor
{
    partial class AnwerEdit
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nu_hight = new System.Windows.Forms.NumericUpDown();
            this.nu_width = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmd_editans = new System.Windows.Forms.Button();
            this.tb_desc = new System.Windows.Forms.TextBox();
            this.nu_intercells = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nu_hight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu_intercells)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.nu_hight, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.nu_width, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmd_editans, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tb_desc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nu_intercells, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 209);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nu_hight
            // 
            this.nu_hight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nu_hight.Location = new System.Drawing.Point(181, 103);
            this.nu_hight.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nu_hight.Name = "nu_hight";
            this.nu_hight.Size = new System.Drawing.Size(325, 20);
            this.nu_hight.TabIndex = 10;
            // 
            // nu_width
            // 
            this.nu_width.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nu_width.Location = new System.Drawing.Point(181, 78);
            this.nu_width.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nu_width.Name = "nu_width";
            this.nu_width.Size = new System.Drawing.Size(325, 20);
            this.nu_width.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Описание вопроса";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Расстояние между ячейками";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Длинна ячеек";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Высота ячеек";
            // 
            // cmd_editans
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmd_editans, 2);
            this.cmd_editans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd_editans.Location = new System.Drawing.Point(3, 178);
            this.cmd_editans.Name = "cmd_editans";
            this.cmd_editans.Size = new System.Drawing.Size(503, 28);
            this.cmd_editans.TabIndex = 6;
            this.cmd_editans.Text = "Внести изменения";
            this.cmd_editans.UseVisualStyleBackColor = true;
            this.cmd_editans.Click += new System.EventHandler(this.cmd_editans_Click);
            // 
            // tb_desc
            // 
            this.tb_desc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_desc.Location = new System.Drawing.Point(181, 3);
            this.tb_desc.Multiline = true;
            this.tb_desc.Name = "tb_desc";
            this.tb_desc.Size = new System.Drawing.Size(325, 44);
            this.tb_desc.TabIndex = 7;
            // 
            // nu_intercells
            // 
            this.nu_intercells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nu_intercells.Location = new System.Drawing.Point(181, 53);
            this.nu_intercells.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nu_intercells.Name = "nu_intercells";
            this.nu_intercells.Size = new System.Drawing.Size(325, 20);
            this.nu_intercells.TabIndex = 8;
            // 
            // AnwerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 209);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnwerEdit";
            this.ShowIcon = false;
            this.Text = "AnwerEdit";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AnwerEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nu_hight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu_intercells)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmd_editans;
        private System.Windows.Forms.NumericUpDown nu_hight;
        private System.Windows.Forms.NumericUpDown nu_width;
        private System.Windows.Forms.TextBox tb_desc;
        private System.Windows.Forms.NumericUpDown nu_intercells;
    }
}