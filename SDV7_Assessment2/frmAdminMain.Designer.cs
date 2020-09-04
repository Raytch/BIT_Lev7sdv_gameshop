namespace WindowsAdmin
{
    partial class frmAdminMain
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
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpGenreDetails = new System.Windows.Forms.GroupBox();
            this.lblGenreName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lstGames = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpGenreDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(34, 363);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(104, 35);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "add item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(143, 363);
            this.btnEditItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(104, 35);
            this.btnEditItem.TabIndex = 2;
            this.btnEditItem.Text = "edit item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(252, 363);
            this.btnDeleteItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(104, 35);
            this.btnDeleteItem.TabIndex = 3;
            this.btnDeleteItem.Text = "delete item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inventory";
            // 
            // grpGenreDetails
            // 
            this.grpGenreDetails.Controls.Add(this.lblGenreName);
            this.grpGenreDetails.Controls.Add(this.lblDescription);
            this.grpGenreDetails.Controls.Add(this.label6);
            this.grpGenreDetails.Controls.Add(this.label8);
            this.grpGenreDetails.Location = new System.Drawing.Point(499, 10);
            this.grpGenreDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpGenreDetails.Name = "grpGenreDetails";
            this.grpGenreDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpGenreDetails.Size = new System.Drawing.Size(330, 321);
            this.grpGenreDetails.TabIndex = 17;
            this.grpGenreDetails.TabStop = false;
            this.grpGenreDetails.Text = "Genre details:";
            // 
            // lblGenreName
            // 
            this.lblGenreName.AutoSize = true;
            this.lblGenreName.Location = new System.Drawing.Point(116, 25);
            this.lblGenreName.Name = "lblGenreName";
            this.lblGenreName.Size = new System.Drawing.Size(87, 17);
            this.lblGenreName.TabIndex = 15;
            this.lblGenreName.Text = "Genre name";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(116, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(218, 283);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Genre description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Name:";
            // 
            // lstGames
            // 
            this.lstGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGames.ForeColor = System.Drawing.Color.Black;
            this.lstGames.FormattingEnabled = true;
            this.lstGames.ItemHeight = 25;
            this.lstGames.Items.AddRange(new object[] {
            "hghjghj"});
            this.lstGames.Location = new System.Drawing.Point(14, 27);
            this.lstGames.Name = "lstGames";
            this.lstGames.Size = new System.Drawing.Size(479, 304);
            this.lstGames.TabIndex = 25;
            this.lstGames.DoubleClick += new System.EventHandler(this.lstGames_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(716, 497);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 35);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 544);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstGames);
            this.Controls.Add(this.grpGenreDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnAddItem);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAdminMain";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.frmAdminMain_Load);
            this.grpGenreDetails.ResumeLayout(false);
            this.grpGenreDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpGenreDetails;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblGenreName;
        private System.Windows.Forms.ListBox lstGames;
        private System.Windows.Forms.Button btnClose;
    }
}

