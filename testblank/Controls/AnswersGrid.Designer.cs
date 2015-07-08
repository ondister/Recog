namespace Recog.Controls
{
    partial class AnswersGrid
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
            this.PanelParent = new System.Windows.Forms.Panel();
            this.pb_progress = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_recog = new System.Windows.Forms.Button();
            this.PanelChild = new System.Windows.Forms.Panel();
            this.PanelParent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelParent
            // 
            this.PanelParent.AutoScroll = true;
            this.PanelParent.Controls.Add(this.pb_progress);
            this.PanelParent.Controls.Add(this.panel1);
            this.PanelParent.Controls.Add(this.PanelChild);
            this.PanelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelParent.Location = new System.Drawing.Point(0, 0);
            this.PanelParent.Name = "PanelParent";
            this.PanelParent.Size = new System.Drawing.Size(284, 329);
            this.PanelParent.TabIndex = 0;
            // 
            // pb_progress
            // 
            this.pb_progress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_progress.Location = new System.Drawing.Point(0, 25);
            this.pb_progress.Name = "pb_progress";
            this.pb_progress.Size = new System.Drawing.Size(284, 15);
            this.pb_progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_progress.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_recog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 25);
            this.panel1.TabIndex = 1;
            // 
            // btn_recog
            // 
            this.btn_recog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_recog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_recog.Location = new System.Drawing.Point(0, 0);
            this.btn_recog.Name = "btn_recog";
            this.btn_recog.Size = new System.Drawing.Size(284, 25);
            this.btn_recog.TabIndex = 0;
            this.btn_recog.Text = "Распознать изображение";
            this.btn_recog.UseVisualStyleBackColor = true;
          
            // 
            // PanelChild
            // 
            this.PanelChild.AutoSize = true;
            this.PanelChild.Location = new System.Drawing.Point(3, 46);
            this.PanelChild.Name = "PanelChild";
            this.PanelChild.Size = new System.Drawing.Size(277, 280);
            this.PanelChild.TabIndex = 0;
            this.PanelChild.MouseEnter += new System.EventHandler(this.PanelChild_MouseEnter);
            // 
            // AnswersGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelParent);
            this.Name = "AnswersGrid";
            this.Size = new System.Drawing.Size(284, 329);
            this.PanelParent.ResumeLayout(false);
            this.PanelParent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

      private System.Windows.Forms.Panel PanelParent;
       private System.Windows.Forms.Panel PanelChild;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btn_recog;
        public System.Windows.Forms.ProgressBar pb_progress;
    }
}
