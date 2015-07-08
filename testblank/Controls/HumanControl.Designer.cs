namespace Recog.Controls
{
    partial class HumanControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HumanControl));
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_education = new System.Windows.Forms.ComboBox();
            this.tb_lastname = new System.Windows.Forms.TextBox();
            this.tb_firstname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_secondname = new System.Windows.Forms.TextBox();
            this.dp_birthdate = new System.Windows.Forms.DateTimePicker();
            this.cb_gender = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_department = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_additinfo = new System.Windows.Forms.TextBox();
            this.btn_addep = new System.Windows.Forms.Button();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.66102F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.33898F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.Controls.Add(this.cb_education, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.tb_lastname, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.tb_firstname, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.tb_secondname, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.dp_birthdate, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.cb_gender, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.cb_department, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.tb_additinfo, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.btn_addep, 2, 6);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(381, 275);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // cb_education
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.cb_education, 2);
            this.cb_education.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_education.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_education.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_education.FormattingEnabled = true;
            this.cb_education.Location = new System.Drawing.Point(108, 128);
            this.cb_education.Name = "cb_education";
            this.cb_education.Size = new System.Drawing.Size(270, 21);
            this.cb_education.TabIndex = 17;
            this.cb_education.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
            // 
            // tb_lastname
            // 
            this.tb_lastname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.tb_lastname, 2);
            this.tb_lastname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_lastname.Location = new System.Drawing.Point(108, 53);
            this.tb_lastname.Name = "tb_lastname";
            this.tb_lastname.Size = new System.Drawing.Size(270, 20);
            this.tb_lastname.TabIndex = 13;
            this.tb_lastname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
            // 
            // tb_firstname
            // 
            this.tb_firstname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.tb_firstname, 2);
            this.tb_firstname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_firstname.Location = new System.Drawing.Point(108, 28);
            this.tb_firstname.Name = "tb_firstname";
            this.tb_firstname.Size = new System.Drawing.Size(270, 20);
            this.tb_firstname.TabIndex = 12;
            this.tb_firstname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Фамилия *";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Имя";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Отчество";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Дата рождения";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Пол";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Образование";
            // 
            // tb_secondname
            // 
            this.tb_secondname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.tb_secondname, 2);
            this.tb_secondname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_secondname.Location = new System.Drawing.Point(108, 3);
            this.tb_secondname.Name = "tb_secondname";
            this.tb_secondname.Size = new System.Drawing.Size(270, 20);
            this.tb_secondname.TabIndex = 11;
            this.tb_secondname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
            // 
            // dp_birthdate
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.dp_birthdate, 2);
            this.dp_birthdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dp_birthdate.Location = new System.Drawing.Point(108, 78);
            this.dp_birthdate.Name = "dp_birthdate";
            this.dp_birthdate.Size = new System.Drawing.Size(270, 20);
            this.dp_birthdate.TabIndex = 14;
            this.dp_birthdate.Value = new System.DateTime(2013, 3, 17, 20, 8, 56, 0);
            this.dp_birthdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
            // 
            // cb_gender
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.cb_gender, 2);
            this.cb_gender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_gender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_gender.FormattingEnabled = true;
            this.cb_gender.Location = new System.Drawing.Point(108, 103);
            this.cb_gender.Name = "cb_gender";
            this.cb_gender.Size = new System.Drawing.Size(270, 21);
            this.cb_gender.TabIndex = 15;
            this.cb_gender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Подразделение";
            // 
            // cb_department
            // 
            this.cb_department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_department.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_department.FormattingEnabled = true;
            this.cb_department.Location = new System.Drawing.Point(108, 153);
            this.cb_department.MaxDropDownItems = 15;
            this.cb_department.Name = "cb_department";
            this.cb_department.Size = new System.Drawing.Size(242, 21);
            this.cb_department.TabIndex = 19;
            this.cb_department.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 26);
            this.label9.TabIndex = 20;
            this.label9.Text = "Дополнительная информация";
            // 
            // tb_additinfo
            // 
            this.tb_additinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.tb_additinfo, 2);
            this.tb_additinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_additinfo.Location = new System.Drawing.Point(108, 178);
            this.tb_additinfo.Multiline = true;
            this.tb_additinfo.Name = "tb_additinfo";
            this.tb_additinfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_additinfo.Size = new System.Drawing.Size(270, 94);
            this.tb_additinfo.TabIndex = 21;
            // 
            // btn_addep
            // 
            this.btn_addep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_addep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addep.Image = ((System.Drawing.Image)(resources.GetObject("btn_addep.Image")));
            this.btn_addep.Location = new System.Drawing.Point(356, 153);
            this.btn_addep.Name = "btn_addep";
            this.btn_addep.Size = new System.Drawing.Size(22, 19);
            this.btn_addep.TabIndex = 22;
            this.btn_addep.UseVisualStyleBackColor = true;
            this.btn_addep.Click += new System.EventHandler(this.btn_addep_Click);
            // 
            // HumanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "HumanControl";
            this.Size = new System.Drawing.Size(381, 281);
            this.Load += new System.EventHandler(this.HumanControl_Load);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox cb_education;
        private System.Windows.Forms.TextBox tb_lastname;
        private System.Windows.Forms.TextBox tb_firstname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_secondname;
        private System.Windows.Forms.DateTimePicker dp_birthdate;
        private System.Windows.Forms.ComboBox cb_gender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_department;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_additinfo;
        private System.Windows.Forms.Button btn_addep;
    }
}
