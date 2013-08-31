namespace RestHourCalc
{
    partial class frmFleet
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
            this.lblFleetID = new System.Windows.Forms.Label();
            this.lblFleetName = new System.Windows.Forms.Label();
            this.lblFleetDesc = new System.Windows.Forms.Label();
            this.txtFleetID = new System.Windows.Forms.TextBox();
            this.txtFleetName = new System.Windows.Forms.TextBox();
            this.txtFleetDesc = new System.Windows.Forms.TextBox();
            this.btnAddFleet = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFleetDelete = new System.Windows.Forms.Button();
            this.btnFleetExit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFleetID
            // 
            this.lblFleetID.AutoSize = true;
            this.lblFleetID.Location = new System.Drawing.Point(12, 9);
            this.lblFleetID.Name = "lblFleetID";
            this.lblFleetID.Size = new System.Drawing.Size(18, 13);
            this.lblFleetID.TabIndex = 0;
            this.lblFleetID.Text = "ID";
            // 
            // lblFleetName
            // 
            this.lblFleetName.AutoSize = true;
            this.lblFleetName.Location = new System.Drawing.Point(12, 31);
            this.lblFleetName.Name = "lblFleetName";
            this.lblFleetName.Size = new System.Drawing.Size(35, 13);
            this.lblFleetName.TabIndex = 1;
            this.lblFleetName.Text = "Name";
            // 
            // lblFleetDesc
            // 
            this.lblFleetDesc.AutoSize = true;
            this.lblFleetDesc.Location = new System.Drawing.Point(12, 55);
            this.lblFleetDesc.Name = "lblFleetDesc";
            this.lblFleetDesc.Size = new System.Drawing.Size(60, 13);
            this.lblFleetDesc.TabIndex = 2;
            this.lblFleetDesc.Text = "Description";
            // 
            // txtFleetID
            // 
            this.txtFleetID.Location = new System.Drawing.Point(88, 6);
            this.txtFleetID.MaxLength = 20;
            this.txtFleetID.Name = "txtFleetID";
            this.txtFleetID.Size = new System.Drawing.Size(223, 20);
            this.txtFleetID.TabIndex = 1;
            // 
            // txtFleetName
            // 
            this.txtFleetName.Location = new System.Drawing.Point(88, 28);
            this.txtFleetName.MaxLength = 20;
            this.txtFleetName.Name = "txtFleetName";
            this.txtFleetName.Size = new System.Drawing.Size(223, 20);
            this.txtFleetName.TabIndex = 2;
            // 
            // txtFleetDesc
            // 
            this.txtFleetDesc.Location = new System.Drawing.Point(88, 52);
            this.txtFleetDesc.MaxLength = 100;
            this.txtFleetDesc.Multiline = true;
            this.txtFleetDesc.Name = "txtFleetDesc";
            this.txtFleetDesc.Size = new System.Drawing.Size(223, 71);
            this.txtFleetDesc.TabIndex = 3;
            // 
            // btnAddFleet
            // 
            this.btnAddFleet.Location = new System.Drawing.Point(2, 129);
            this.btnAddFleet.Name = "btnAddFleet";
            this.btnAddFleet.Size = new System.Drawing.Size(75, 23);
            this.btnAddFleet.TabIndex = 4;
            this.btnAddFleet.Text = "Add";
            this.btnAddFleet.UseVisualStyleBackColor = true;
            this.btnAddFleet.Click += new System.EventHandler(this.btnAddFleet_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(165, 129);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnFleetDelete
            // 
            this.btnFleetDelete.Location = new System.Drawing.Point(246, 129);
            this.btnFleetDelete.Name = "btnFleetDelete";
            this.btnFleetDelete.Size = new System.Drawing.Size(75, 23);
            this.btnFleetDelete.TabIndex = 6;
            this.btnFleetDelete.Text = "Delete";
            this.btnFleetDelete.UseVisualStyleBackColor = true;
            this.btnFleetDelete.Click += new System.EventHandler(this.btnFleetDelete_Click);
            // 
            // btnFleetExit
            // 
            this.btnFleetExit.Location = new System.Drawing.Point(120, 158);
            this.btnFleetExit.Name = "btnFleetExit";
            this.btnFleetExit.Size = new System.Drawing.Size(75, 23);
            this.btnFleetExit.TabIndex = 7;
            this.btnFleetExit.Text = "Exit";
            this.btnFleetExit.UseVisualStyleBackColor = true;
            this.btnFleetExit.Click += new System.EventHandler(this.btnFleetExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(84, 129);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmFleet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 192);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnFleetExit);
            this.Controls.Add(this.btnFleetDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddFleet);
            this.Controls.Add(this.txtFleetDesc);
            this.Controls.Add(this.txtFleetName);
            this.Controls.Add(this.txtFleetID);
            this.Controls.Add(this.lblFleetDesc);
            this.Controls.Add(this.lblFleetName);
            this.Controls.Add(this.lblFleetID);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFleet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fleet Configration Wizard";
            this.Load += new System.EventHandler(this.frmFleet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFleetID;
        private System.Windows.Forms.Label lblFleetName;
        private System.Windows.Forms.Label lblFleetDesc;
        private System.Windows.Forms.TextBox txtFleetID;
        private System.Windows.Forms.TextBox txtFleetName;
        private System.Windows.Forms.TextBox txtFleetDesc;
        private System.Windows.Forms.Button btnAddFleet;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFleetDelete;
        private System.Windows.Forms.Button btnFleetExit;
        private System.Windows.Forms.Button btnSearch;
    }
}