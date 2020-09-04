namespace WindowsAdmin
{
    partial class frmNew
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtWarrantyExp = new System.Windows.Forms.TextBox();
            this.dtpWarranty = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Warranty expires:";
            // 
            // txtWarrantyExp
            // 
            this.txtWarrantyExp.Location = new System.Drawing.Point(179, 296);
            this.txtWarrantyExp.Name = "txtWarrantyExp";
            this.txtWarrantyExp.Size = new System.Drawing.Size(214, 22);
            this.txtWarrantyExp.TabIndex = 19;
            // 
            // dtpWarranty
            // 
            this.dtpWarranty.Location = new System.Drawing.Point(179, 337);
            this.dtpWarranty.Name = "dtpWarranty";
            this.dtpWarranty.Size = new System.Drawing.Size(200, 22);
            this.dtpWarranty.TabIndex = 20;
            // 
            // frmNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(710, 462);
            this.Controls.Add(this.dtpWarranty);
            this.Controls.Add(this.txtWarrantyExp);
            this.Controls.Add(this.label9);
            this.Name = "frmNew";
            this.Text = "New Game";
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtWarrantyExp, 0);
            this.Controls.SetChildIndex(this.dtpWarranty, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWarrantyExp;
        private System.Windows.Forms.DateTimePicker dtpWarranty;
    }
}
