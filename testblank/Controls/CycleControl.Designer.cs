namespace Recog.Controls
{
    partial class CycleControl
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
            this.pb_cycle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cycle)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_cycle
            // 
            this.pb_cycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_cycle.Location = new System.Drawing.Point(0, 0);
            this.pb_cycle.Name = "pb_cycle";
            this.pb_cycle.Size = new System.Drawing.Size(300, 300);
            this.pb_cycle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_cycle.TabIndex = 0;
            this.pb_cycle.TabStop = false;
            // 
            // CycleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_cycle);
            this.Name = "CycleControl";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.pb_cycle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pb_cycle;
    }
}
