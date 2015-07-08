namespace Recog.Controls
{
    partial class EndTestControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_savedata = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lb_caption = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn_savedata, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_exit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_caption, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 330);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btn_savedata
            // 
            this.btn_savedata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_savedata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_savedata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_savedata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_savedata.Location = new System.Drawing.Point(3, 293);
            this.btn_savedata.Name = "btn_savedata";
            this.btn_savedata.Size = new System.Drawing.Size(238, 34);
            this.btn_savedata.TabIndex = 3;
            this.btn_savedata.Text = "Сохранить результаты";
            this.btn_savedata.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_exit.Location = new System.Drawing.Point(247, 293);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(238, 34);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Выход без сохранения";
            this.btn_exit.UseVisualStyleBackColor = true;
            // 
            // lb_caption
            // 
            this.lb_caption.AutoSize = true;
            this.lb_caption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.lb_caption, 2);
            this.lb_caption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_caption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_caption.Location = new System.Drawing.Point(3, 0);
            this.lb_caption.Name = "lb_caption";
            this.lb_caption.Size = new System.Drawing.Size(482, 290);
            this.lb_caption.TabIndex = 2;
            this.lb_caption.Text = "label1";
            this.lb_caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EndTestControl";
            this.Size = new System.Drawing.Size(488, 330);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lb_caption;
        public System.Windows.Forms.Button btn_savedata;
    }
}
