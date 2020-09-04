namespace WindowsAdmin
{
    partial class frmGenreSelect
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.btnViewGames = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a genre:";
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(168, 33);
            this.cboGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(305, 24);
            this.cboGenre.TabIndex = 1;
            this.cboGenre.Text = "shooter";
            this.cboGenre.SelectedIndexChanged += new System.EventHandler(this.cboGenre_SelectedIndexChanged);
            // 
            // btnViewGames
            // 
            this.btnViewGames.AutoSize = true;
            this.btnViewGames.Location = new System.Drawing.Point(393, 253);
            this.btnViewGames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewGames.Name = "btnViewGames";
            this.btnViewGames.Size = new System.Drawing.Size(96, 29);
            this.btnViewGames.TabIndex = 2;
            this.btnViewGames.Text = "View Games";
            this.btnViewGames.UseVisualStyleBackColor = true;
            this.btnViewGames.Click += new System.EventHandler(this.btnViewGames_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Genre Description:";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(165, 86);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(308, 135);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // btnViewOrders
            // 
            this.btnViewOrders.AutoSize = true;
            this.btnViewOrders.Location = new System.Drawing.Point(22, 253);
            this.btnViewOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewOrders.Name = "btnViewOrders";
            this.btnViewOrders.Size = new System.Drawing.Size(95, 29);
            this.btnViewOrders.TabIndex = 5;
            this.btnViewOrders.Text = "View Orders";
            this.btnViewOrders.UseVisualStyleBackColor = true;
            this.btnViewOrders.Click += new System.EventHandler(this.btnViewOrders_Click);
            // 
            // frmGenreSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 302);
            this.Controls.Add(this.btnViewOrders);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnViewGames);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmGenreSelect";
            this.Text = "Select Genre";
            this.Load += new System.EventHandler(this.frmGenreSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.Button btnViewGames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnViewOrders;
    }
}