namespace WindowsAdmin
{
    partial class frmUsed
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
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nupAge = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupAge)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Condition:";
            // 
            // cboCondition
            // 
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Items.AddRange(new object[] {
            "Poor",
            "Average",
            "As New"});
            this.cboCondition.Location = new System.Drawing.Point(180, 285);
            this.cboCondition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(311, 24);
            this.cboCondition.TabIndex = 14;
            this.cboCondition.Text = "Average";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Age (Years):";
            // 
            // nupAge
            // 
            this.nupAge.Location = new System.Drawing.Point(180, 323);
            this.nupAge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nupAge.Name = "nupAge";
            this.nupAge.Size = new System.Drawing.Size(107, 22);
            this.nupAge.TabIndex = 16;
            this.nupAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmUsed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(711, 454);
            this.Controls.Add(this.nupAge);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboCondition);
            this.Controls.Add(this.label9);
            this.Name = "frmUsed";
            this.Text = "Used game";
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cboCondition, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.nupAge, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nupAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboCondition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nupAge;
    }
}
