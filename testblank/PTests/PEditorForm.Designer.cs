namespace Recog.PTests
{
    partial class PEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PEditorForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_packs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lst_pooll = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lst_all = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_right, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_left, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_up, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_down, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_add, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_delete, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(873, 381);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst_packs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(611, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(259, 340);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доступные кортежи";
            // 
            // lst_packs
            // 
            this.lst_packs.AllowDrop = true;
            this.lst_packs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_packs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lst_packs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_packs.FullRowSelect = true;
            this.lst_packs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lst_packs.HideSelection = false;
            this.lst_packs.Location = new System.Drawing.Point(3, 16);
            this.lst_packs.MultiSelect = false;
            this.lst_packs.Name = "lst_packs";
            this.lst_packs.Size = new System.Drawing.Size(253, 321);
            this.lst_packs.TabIndex = 0;
            this.lst_packs.UseCompatibleStateImageBehavior = false;
            this.lst_packs.View = System.Windows.Forms.View.Details;
            this.lst_packs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lst_packs_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Наименование";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lst_pooll);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(307, 3);
            this.groupBox3.Name = "groupBox3";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox3, 2);
            this.groupBox3.Size = new System.Drawing.Size(258, 340);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Очередь тестов";
            // 
            // lst_pooll
            // 
            this.lst_pooll.AllowDrop = true;
            this.lst_pooll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_pooll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lst_pooll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_pooll.FullRowSelect = true;
            this.lst_pooll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lst_pooll.HideSelection = false;
            this.lst_pooll.Location = new System.Drawing.Point(3, 16);
            this.lst_pooll.MultiSelect = false;
            this.lst_pooll.Name = "lst_pooll";
            this.lst_pooll.Size = new System.Drawing.Size(252, 321);
            this.lst_pooll.TabIndex = 0;
            this.lst_pooll.UseCompatibleStateImageBehavior = false;
            this.lst_pooll.View = System.Windows.Forms.View.Details;
            this.lst_pooll.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lst_pooll.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lst_pooll.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Наименование";
            // 
            // btn_right
            // 
            this.btn_right.BackColor = System.Drawing.SystemColors.Control;
            this.btn_right.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_right.Image = ((System.Drawing.Image)(resources.GetObject("btn_right.Image")));
            this.btn_right.Location = new System.Drawing.Point(267, 3);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(34, 167);
            this.btn_right.TabIndex = 5;
            this.btn_right.Tag = "Добавить тест в очередь";
            this.btn_right.UseVisualStyleBackColor = false;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // btn_left
            // 
            this.btn_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_left.Image = ((System.Drawing.Image)(resources.GetObject("btn_left.Image")));
            this.btn_left.Location = new System.Drawing.Point(267, 176);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(34, 167);
            this.btn_left.TabIndex = 6;
            this.btn_left.Tag = "Удалить тест из очереди";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // btn_up
            // 
            this.btn_up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_up.Image = ((System.Drawing.Image)(resources.GetObject("btn_up.Image")));
            this.btn_up.Location = new System.Drawing.Point(571, 3);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(34, 167);
            this.btn_up.TabIndex = 7;
            this.btn_up.Tag = "Выше в очереди";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_down
            // 
            this.btn_down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_down.Image = ((System.Drawing.Image)(resources.GetObject("btn_down.Image")));
            this.btn_down.Location = new System.Drawing.Point(571, 176);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(34, 167);
            this.btn_down.TabIndex = 8;
            this.btn_down.Tag = "Ниже в очереди";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lst_all);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox2, 3);
            this.groupBox2.Size = new System.Drawing.Size(258, 375);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Доступные тесты";
            // 
            // lst_all
            // 
            this.lst_all.AllowDrop = true;
            this.lst_all.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_all.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lst_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_all.FullRowSelect = true;
            this.lst_all.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lst_all.HideSelection = false;
            this.lst_all.Location = new System.Drawing.Point(3, 16);
            this.lst_all.MultiSelect = false;
            this.lst_all.Name = "lst_all";
            this.lst_all.Size = new System.Drawing.Size(252, 356);
            this.lst_all.TabIndex = 0;
            this.lst_all.UseCompatibleStateImageBehavior = false;
            this.lst_all.View = System.Windows.Forms.View.Details;
            this.lst_all.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lst_all.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lst_all.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Наименование";
            // 
            // btn_add
            // 
            this.btn_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.Location = new System.Drawing.Point(307, 349);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(258, 29);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "Сохранить кортеж";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_delete.Location = new System.Drawing.Point(611, 349);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(259, 29);
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Text = "Удалить кортеж";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // PEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 381);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор кортежей";
            this.Load += new System.EventHandler(this.PEForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lst_all;
        private System.Windows.Forms.ListView lst_pooll;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lst_packs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delete;
    }
}