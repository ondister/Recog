namespace Recog.PTests.D
{
    partial class TestDForm
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
            this.etc_end = new Recog.Controls.EndTestControl();
            this.atc_gone = new Recog.Controls.TwoButtonsControl();
            this.stc_start = new Recog.Controls.StartTestControl();
            this.SuspendLayout();
            // 
            // etc_end
            // 
            this.etc_end.AboutTest = "label1";
            this.etc_end.Location = new System.Drawing.Point(0, 0);
            this.etc_end.Name = "etc_end";
            this.etc_end.Size = new System.Drawing.Size(308, 120);
            this.etc_end.TabIndex = 2;
            this.etc_end.Visible = false;
            // 
            // atc_gone
            // 
            this.atc_gone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atc_gone.Location = new System.Drawing.Point(0, 0);
            this.atc_gone.Name = "atc_gone";
            this.atc_gone.Size = new System.Drawing.Size(728, 330);
            this.atc_gone.TabIndex = 1;
            this.atc_gone.Visible = false;
            // 
            // stc_start
            // 
            this.stc_start.AboutTest = "label1";
            this.stc_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stc_start.Location = new System.Drawing.Point(0, 0);
            this.stc_start.Name = "stc_start";
            this.stc_start.Size = new System.Drawing.Size(728, 330);
            this.stc_start.TabIndex = 0;
            this.stc_start.Visible = false;
            // 
            // TestDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 330);
            this.Controls.Add(this.etc_end);
            this.Controls.Add(this.atc_gone);
            this.Controls.Add(this.stc_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestDForm";
            this.Text = "TestAdaptabilityForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TestAdaptabilityForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.StartTestControl stc_start;
        public Controls.TwoButtonsControl atc_gone;
        public Controls.EndTestControl etc_end;
    }
}