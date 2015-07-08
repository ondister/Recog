namespace Recog.PTests.Kettell
{
    partial class TestKettellCForm
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
            this.ktc_gone = new Recog.Controls.ThreeButtonsControl();
            this.stc_start = new Recog.Controls.StartTestControl();
            this.SuspendLayout();
            // 
            // etc_end
            // 
            this.etc_end.AboutTest = "label1";
            this.etc_end.Location = new System.Drawing.Point(285, 237);
            this.etc_end.Name = "etc_end";
            this.etc_end.Size = new System.Drawing.Size(488, 330);
            this.etc_end.TabIndex = 2;
            // 
            // ktc_gone
            // 
            this.ktc_gone.Location = new System.Drawing.Point(367, -15);
            this.ktc_gone.Name = "ktc_gone";
            this.ktc_gone.Size = new System.Drawing.Size(590, 389);
            this.ktc_gone.TabIndex = 1;
            // 
            // stc_start
            // 
            this.stc_start.AboutTest = "label1";
            this.stc_start.Location = new System.Drawing.Point(-393, -59);
            this.stc_start.Name = "stc_start";
            this.stc_start.Size = new System.Drawing.Size(619, 387);
            this.stc_start.TabIndex = 0;
            // 
            // TestKettellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 386);
            this.Controls.Add(this.etc_end);
            this.Controls.Add(this.ktc_gone);
            this.Controls.Add(this.stc_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestKettellForm";
            this.Text = "TestKettellForm";
            this.Load += new System.EventHandler(this.TestKettellForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.StartTestControl stc_start;
        private Controls.ThreeButtonsControl ktc_gone;
       public Controls.EndTestControl etc_end;
    }
}