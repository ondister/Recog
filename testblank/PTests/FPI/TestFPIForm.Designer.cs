namespace Recog.PTests.FPI
{
    partial class TestFPIForm
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
            this.stc_start = new Recog.Controls.StartTestControl();
            this.atc_gone = new Recog.Controls.TwoButtonsControl();
            this.etc_end = new Recog.Controls.EndTestControl();
            this.SuspendLayout();
            // 
            // stc_start
            // 
            this.stc_start.AboutTest = "label1";
            this.stc_start.Location = new System.Drawing.Point(-437, 45);
            this.stc_start.Name = "stc_start";
            this.stc_start.Size = new System.Drawing.Size(619, 387);
            this.stc_start.TabIndex = 0;
            // 
            // atc_gone
            // 
            this.atc_gone.Location = new System.Drawing.Point(211, 202);
            this.atc_gone.Name = "atc_gone";
            this.atc_gone.Size = new System.Drawing.Size(590, 389);
            this.atc_gone.TabIndex = 1;
            // 
            // etc_end
            // 
            this.etc_end.AboutTest = "label1";
            this.etc_end.Location = new System.Drawing.Point(541, -23);
            this.etc_end.Name = "etc_end";
            this.etc_end.Size = new System.Drawing.Size(488, 330);
            this.etc_end.TabIndex = 2;
            // 
            // TestAdaptabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 330);
            this.Controls.Add(this.etc_end);
            this.Controls.Add(this.atc_gone);
            this.Controls.Add(this.stc_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestAdaptabilityForm";
            this.Text = "TestAdaptabilityForm";
            this.Load += new System.EventHandler(this.TestAdaptabilityForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.StartTestControl stc_start;
        public Controls.TwoButtonsControl atc_gone;
        public Controls.EndTestControl etc_end;
    }
}