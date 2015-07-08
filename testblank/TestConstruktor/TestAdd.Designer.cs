namespace Recog.TestConstruktor
{
    partial class TestAdd
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
            this.cmd_addtest = new System.Windows.Forms.Button();
            this.cmd_openimg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pb_img = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_answ = new System.Windows.Forms.ListView();
            this.num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ida = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.intercellwidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cellwidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cellheight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.x = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.y = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.oof_dialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.28004F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.71996F));
            this.tableLayoutPanel1.Controls.Add(this.cmd_addtest, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmd_openimg, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 562);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmd_addtest
            // 
            this.cmd_addtest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd_addtest.Location = new System.Drawing.Point(751, 503);
            this.cmd_addtest.Name = "cmd_addtest";
            this.cmd_addtest.Size = new System.Drawing.Size(253, 24);
            this.cmd_addtest.TabIndex = 5;
            this.cmd_addtest.Text = "Добавить тест";
            this.cmd_addtest.UseVisualStyleBackColor = true;
            this.cmd_addtest.Click += new System.EventHandler(this.cmd_addtest_Click);
            // 
            // cmd_openimg
            // 
            this.cmd_openimg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd_openimg.Location = new System.Drawing.Point(4, 503);
            this.cmd_openimg.Name = "cmd_openimg";
            this.cmd_openimg.Size = new System.Drawing.Size(740, 24);
            this.cmd_openimg.TabIndex = 0;
            this.cmd_openimg.Text = "Открыть изображение";
            this.cmd_openimg.UseVisualStyleBackColor = true;
            this.cmd_openimg.Click += new System.EventHandler(this.cmd_openimg_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 492);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.pb_img);
            this.panel2.Location = new System.Drawing.Point(3, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 523);
            this.panel2.TabIndex = 0;
            // 
            // pb_img
            // 
            this.pb_img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_img.Location = new System.Drawing.Point(0, 0);
            this.pb_img.Name = "pb_img";
            this.pb_img.Size = new System.Drawing.Size(546, 523);
            this.pb_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_img.TabIndex = 0;
            this.pb_img.TabStop = false;
            this.pb_img.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_img_MouseClick);
            this.pb_img.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pb_img_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(751, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 492);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создание теста";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.64516F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.35484F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lst_answ, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(247, 473);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название теста";
            // 
            // lst_answ
            // 
            this.lst_answ.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.num,
            this.ida,
            this.description,
            this.intercellwidth,
            this.cellwidth,
            this.cellheight,
            this.x,
            this.y});
            this.tableLayoutPanel2.SetColumnSpan(this.lst_answ, 2);
            this.lst_answ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_answ.FullRowSelect = true;
            this.lst_answ.GridLines = true;
            this.lst_answ.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lst_answ.HideSelection = false;
            this.lst_answ.Location = new System.Drawing.Point(3, 28);
            this.lst_answ.MultiSelect = false;
            this.lst_answ.Name = "lst_answ";
            this.lst_answ.Size = new System.Drawing.Size(241, 442);
            this.lst_answ.TabIndex = 1;
            this.lst_answ.UseCompatibleStateImageBehavior = false;
            this.lst_answ.View = System.Windows.Forms.View.Details;
            this.lst_answ.ItemActivate += new System.EventHandler(this.lst_answ_ItemActivate);
            // 
            // num
            // 
            this.num.Text = "Номер";
            this.num.Width = 40;
            // 
            // ida
            // 
            this.ida.DisplayIndex = 2;
            this.ida.Text = "ID";
            this.ida.Width = 0;
            // 
            // description
            // 
            this.description.DisplayIndex = 1;
            this.description.Text = "Описание";
            this.description.Width = 120;
            // 
            // intercellwidth
            // 
            this.intercellwidth.Text = "Расстояние между ячейками";
            // 
            // cellwidth
            // 
            this.cellwidth.Text = "Длина ячейки";
            // 
            // cellheight
            // 
            this.cellheight.Text = "Высота ячейки";
            // 
            // x
            // 
            this.x.Text = "X первой ячейки";
            // 
            // y
            // 
            this.y.Text = "Y первой ячейки";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(751, 534);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // oof_dialog
            // 
            this.oof_dialog.RestoreDirectory = true;
            // 
            // TestAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TestAdd";
            this.Text = "Конструктор тестов";
            this.Load += new System.EventHandler(this.TConstructor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button cmd_openimg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pb_img;
        private System.Windows.Forms.OpenFileDialog oof_dialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_addtest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lst_answ;
        private System.Windows.Forms.ColumnHeader num;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ColumnHeader ida;
        private System.Windows.Forms.ColumnHeader intercellwidth;
        private System.Windows.Forms.ColumnHeader cellwidth;
        private System.Windows.Forms.ColumnHeader cellheight;
        private System.Windows.Forms.ColumnHeader x;
        private System.Windows.Forms.ColumnHeader y;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}