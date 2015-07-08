namespace Recog.Controls
{
    partial class TwoButtonsControl
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
            this.lb_1 = new System.Windows.Forms.Label();
            this.lb_caption = new System.Windows.Forms.Label();
            this.lb_2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lb_1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_caption, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 389);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lb_1
            // 
            this.lb_1.AutoSize = true;
            this.lb_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_1.Location = new System.Drawing.Point(3, 189);
            this.lb_1.Name = "lb_1";
            this.lb_1.Size = new System.Drawing.Size(584, 45);
            this.lb_1.TabIndex = 1;
            this.lb_1.Text = "label2";
            this.lb_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_caption
            // 
            this.lb_caption.AutoSize = true;
            this.lb_caption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_caption.Location = new System.Drawing.Point(3, 0);
            this.lb_caption.Name = "lb_caption";
            this.lb_caption.Size = new System.Drawing.Size(584, 189);
            this.lb_caption.TabIndex = 0;
            this.lb_caption.Text = "label1";
            this.lb_caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_2
            // 
            this.lb_2.AutoSize = true;
            this.lb_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_2.Location = new System.Drawing.Point(3, 244);
            this.lb_2.Name = "lb_2";
            this.lb_2.Size = new System.Drawing.Size(584, 45);
            this.lb_2.TabIndex = 2;
            this.lb_2.Text = "label3";
            this.lb_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TwoButtonsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TwoButtonsControl";
            this.Size = new System.Drawing.Size(590, 389);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
       public System.Windows.Forms.Label lb_1;
        public System.Windows.Forms.Label lb_caption;
        public System.Windows.Forms.Label lb_2;

    }
}
