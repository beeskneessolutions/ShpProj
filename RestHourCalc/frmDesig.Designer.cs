namespace RestHourCalc
{
    partial class frmDesig
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
            this.btnDesig = new System.Windows.Forms.Button();
            this.btnDesigExit = new System.Windows.Forms.Button();
            this.btnDesigDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddDesig = new System.Windows.Forms.Button();
            this.txtDesigDesc = new System.Windows.Forms.TextBox();
            this.txtDesigName = new System.Windows.Forms.TextBox();
            this.txtDesigID = new System.Windows.Forms.TextBox();
            this.lblDesigDesc = new System.Windows.Forms.Label();
            this.lblDesigName = new System.Windows.Forms.Label();
            this.lblDesigID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDesig
            // 
            this.btnDesig.Location = new System.Drawing.Point(81, 130);
            this.btnDesig.Name = "btnDesig";
            this.btnDesig.Size = new System.Drawing.Size(75, 23);
            this.btnDesig.TabIndex = 19;
            this.btnDesig.Text = "Search";
            this.btnDesig.UseVisualStyleBackColor = true;
            // 
            // btnDesigExit
            // 
            this.btnDesigExit.Location = new System.Drawing.Point(117, 159);
            this.btnDesigExit.Name = "btnDesigExit";
            this.btnDesigExit.Size = new System.Drawing.Size(75, 23);
            this.btnDesigExit.TabIndex = 18;
            this.btnDesigExit.Text = "Exit";
            this.btnDesigExit.UseVisualStyleBackColor = true;
            this.btnDesigExit.Click += new System.EventHandler(this.btnDesigExit_Click);
            // 
            // btnDesigDelete
            // 
            this.btnDesigDelete.Location = new System.Drawing.Point(243, 130);
            this.btnDesigDelete.Name = "btnDesigDelete";
            this.btnDesigDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDesigDelete.TabIndex = 17;
            this.btnDesigDelete.Text = "Delete";
            this.btnDesigDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(162, 130);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAddDesig
            // 
            this.btnAddDesig.Location = new System.Drawing.Point(3, 130);
            this.btnAddDesig.Name = "btnAddDesig";
            this.btnAddDesig.Size = new System.Drawing.Size(75, 23);
            this.btnAddDesig.TabIndex = 15;
            this.btnAddDesig.Text = "Add";
            this.btnAddDesig.UseVisualStyleBackColor = true;
            // 
            // txtDesigDesc
            // 
            this.txtDesigDesc.Location = new System.Drawing.Point(85, 53);
            this.txtDesigDesc.MaxLength = 100;
            this.txtDesigDesc.Multiline = true;
            this.txtDesigDesc.Name = "txtDesigDesc";
            this.txtDesigDesc.Size = new System.Drawing.Size(223, 71);
            this.txtDesigDesc.TabIndex = 14;
            // 
            // txtDesigName
            // 
            this.txtDesigName.Location = new System.Drawing.Point(85, 29);
            this.txtDesigName.MaxLength = 20;
            this.txtDesigName.Name = "txtDesigName";
            this.txtDesigName.Size = new System.Drawing.Size(223, 20);
            this.txtDesigName.TabIndex = 12;
            // 
            // txtDesigID
            // 
            this.txtDesigID.Location = new System.Drawing.Point(85, 7);
            this.txtDesigID.MaxLength = 20;
            this.txtDesigID.Name = "txtDesigID";
            this.txtDesigID.Size = new System.Drawing.Size(223, 20);
            this.txtDesigID.TabIndex = 10;
            // 
            // lblDesigDesc
            // 
            this.lblDesigDesc.AutoSize = true;
            this.lblDesigDesc.Location = new System.Drawing.Point(9, 56);
            this.lblDesigDesc.Name = "lblDesigDesc";
            this.lblDesigDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesigDesc.TabIndex = 13;
            this.lblDesigDesc.Text = "Description";
            // 
            // lblDesigName
            // 
            this.lblDesigName.AutoSize = true;
            this.lblDesigName.Location = new System.Drawing.Point(9, 32);
            this.lblDesigName.Name = "lblDesigName";
            this.lblDesigName.Size = new System.Drawing.Size(35, 13);
            this.lblDesigName.TabIndex = 11;
            this.lblDesigName.Text = "Name";
            // 
            // lblDesigID
            // 
            this.lblDesigID.AutoSize = true;
            this.lblDesigID.Location = new System.Drawing.Point(9, 10);
            this.lblDesigID.Name = "lblDesigID";
            this.lblDesigID.Size = new System.Drawing.Size(18, 13);
            this.lblDesigID.TabIndex = 9;
            this.lblDesigID.Text = "ID";
            // 
            // frmDesig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 182);
            this.Controls.Add(this.btnDesig);
            this.Controls.Add(this.btnDesigExit);
            this.Controls.Add(this.btnDesigDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddDesig);
            this.Controls.Add(this.txtDesigDesc);
            this.Controls.Add(this.txtDesigName);
            this.Controls.Add(this.txtDesigID);
            this.Controls.Add(this.lblDesigDesc);
            this.Controls.Add(this.lblDesigName);
            this.Controls.Add(this.lblDesigID);
            this.Name = "frmDesig";
            this.Text = "Designation Configuration Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDesig;
        private System.Windows.Forms.Button btnDesigExit;
        private System.Windows.Forms.Button btnDesigDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddDesig;
        private System.Windows.Forms.TextBox txtDesigDesc;
        private System.Windows.Forms.TextBox txtDesigName;
        private System.Windows.Forms.TextBox txtDesigID;
        private System.Windows.Forms.Label lblDesigDesc;
        private System.Windows.Forms.Label lblDesigName;
        private System.Windows.Forms.Label lblDesigID;
    }
}