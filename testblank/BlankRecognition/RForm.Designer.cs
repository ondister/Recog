namespace Recog.BlankRecognition
{
    partial class RForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RForm));
            this.btn_addtobase = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.p_parent = new System.Windows.Forms.Panel();
            this.p_child = new System.Windows.Forms.Panel();
            this.pb_formimage = new System.Windows.Forms.PictureBox();
            this.btn_scan = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chb_onofdesc = new System.Windows.Forms.CheckBox();
            this.lb_status = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ag_answers = new Recog.Controls.AnswersGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.p_parent.SuspendLayout();
            this.p_child.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_formimage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addtobase
            // 
            this.btn_addtobase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_addtobase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addtobase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_addtobase.Location = new System.Drawing.Point(3, 302);
            this.btn_addtobase.Name = "btn_addtobase";
            this.btn_addtobase.Size = new System.Drawing.Size(318, 29);
            this.btn_addtobase.TabIndex = 1;
            this.btn_addtobase.Text = "Добавить результаты в базу";
            this.btn_addtobase.UseVisualStyleBackColor = true;
            this.btn_addtobase.Click += new System.EventHandler(this.btn_addtobase_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(850, 336);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.p_parent, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_scan, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(518, 334);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // p_parent
            // 
            this.p_parent.AutoScroll = true;
            this.p_parent.AutoSize = true;
            this.p_parent.Controls.Add(this.p_child);
            this.p_parent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_parent.Location = new System.Drawing.Point(3, 38);
            this.p_parent.Name = "p_parent";
            this.p_parent.Size = new System.Drawing.Size(512, 258);
            this.p_parent.TabIndex = 1;
            // 
            // p_child
            // 
            this.p_child.AutoScroll = true;
            this.p_child.AutoSize = true;
            this.p_child.Controls.Add(this.pb_formimage);
            this.p_child.Location = new System.Drawing.Point(0, 0);
            this.p_child.Name = "p_child";
            this.p_child.Size = new System.Drawing.Size(371, 227);
            this.p_child.TabIndex = 0;
            // 
            // pb_formimage
            // 
            this.pb_formimage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_formimage.Location = new System.Drawing.Point(0, 0);
            this.pb_formimage.Name = "pb_formimage";
            this.pb_formimage.Size = new System.Drawing.Size(371, 227);
            this.pb_formimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_formimage.TabIndex = 0;
            this.pb_formimage.TabStop = false;
            this.pb_formimage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_formimage_MouseDown);
            this.pb_formimage.MouseEnter += new System.EventHandler(this.pb_formimage_MouseEnter);
            this.pb_formimage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_formimage_MouseMove);
            // 
            // btn_scan
            // 
            this.btn_scan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_scan.Location = new System.Drawing.Point(3, 302);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(512, 29);
            this.btn_scan.TabIndex = 2;
            this.btn_scan.Text = "Сканировать";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.70313F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.29688F));
            this.tableLayoutPanel1.Controls.Add(this.chb_onofdesc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_status, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 29);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // chb_onofdesc
            // 
            this.chb_onofdesc.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_onofdesc.AutoSize = true;
            this.chb_onofdesc.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_onofdesc.Checked = true;
            this.chb_onofdesc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_onofdesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_onofdesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_onofdesc.Location = new System.Drawing.Point(364, 3);
            this.chb_onofdesc.Name = "chb_onofdesc";
            this.chb_onofdesc.Size = new System.Drawing.Size(145, 23);
            this.chb_onofdesc.TabIndex = 0;
            this.chb_onofdesc.Text = "Выкл. описание ответов";
            this.chb_onofdesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_onofdesc.UseVisualStyleBackColor = true;
            this.chb_onofdesc.Visible = false;
            this.chb_onofdesc.CheckedChanged += new System.EventHandler(this.chb_onofdesc_CheckedChanged);
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_status.Location = new System.Drawing.Point(3, 0);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(355, 29);
            this.lb_status.TabIndex = 1;
            this.lb_status.Text = "label1";
            this.lb_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_status.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.ag_answers, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_addtobase, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(324, 334);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ag_answers
            // 
            this.ag_answers.Answers = null;
            this.ag_answers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ag_answers.Location = new System.Drawing.Point(3, 3);
            this.ag_answers.Name = "ag_answers";
            this.ag_answers.Size = new System.Drawing.Size(318, 293);
            this.ag_answers.TabIndex = 2;
            this.ag_answers.AnswerSelect += new Recog.Controls.WorkAnswer(this.ag_answers_AnswerSelect);

            // 
            // RForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 336);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распознавание бланка";
            this.Load += new System.EventHandler(this.RecogForm_Load);
            this.Shown += new System.EventHandler(this.RecogForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.p_parent.ResumeLayout(false);
            this.p_parent.PerformLayout();
            this.p_child.ResumeLayout(false);
            this.p_child.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_formimage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btn_addtobase;
        private Controls.AnswersGrid ag_answers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel p_parent;
        private System.Windows.Forms.Panel p_child;
        private System.Windows.Forms.PictureBox pb_formimage;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chb_onofdesc;
        private System.Windows.Forms.Label lb_status;
    }
}