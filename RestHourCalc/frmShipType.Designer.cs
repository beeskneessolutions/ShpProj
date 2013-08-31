namespace RestHourCalc
{
    partial class frmShipType
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
            this.btnShipTypeExit = new System.Windows.Forms.Button();
            this.btnShipTypeDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShipTypeAdd = new System.Windows.Forms.Button();
            this.txtShipTypeDesc = new System.Windows.Forms.TextBox();
            this.txtShipTypeName = new System.Windows.Forms.TextBox();
            this.txtShipTypeID = new System.Windows.Forms.TextBox();
            this.lblShipTypeDesc = new System.Windows.Forms.Label();
            this.lblShipTypeName = new System.Windows.Forms.Label();
            this.lblDhipTypeID = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShipTypeExit
            // 
            this.btnShipTypeExit.Location = new System.Drawing.Point(124, 160);
            this.btnShipTypeExit.Name = "btnShipTypeExit";
            this.btnShipTypeExit.Size = new System.Drawing.Size(75, 23);
            this.btnShipTypeExit.TabIndex = 7;
            this.btnShipTypeExit.Text = "Exit";
            this.btnShipTypeExit.UseVisualStyleBackColor = true;
            this.btnShipTypeExit.Click += new System.EventHandler(this.btnShipTypeExit_Click);
            // 
            // btnShipTypeDelete
            // 
            this.btnShipTypeDelete.Location = new System.Drawing.Point(246, 131);
            this.btnShipTypeDelete.Name = "btnShipTypeDelete";
            this.btnShipTypeDelete.Size = new System.Drawing.Size(75, 23);
            this.btnShipTypeDelete.TabIndex = 6;
            this.btnShipTypeDelete.Text = "Delete";
            this.btnShipTypeDelete.UseVisualStyleBackColor = true;
            this.btnShipTypeDelete.Click += new System.EventHandler(this.btnShipTypeDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(165, 131);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnShipTypeAdd
            // 
            this.btnShipTypeAdd.Location = new System.Drawing.Point(3, 131);
            this.btnShipTypeAdd.Name = "btnShipTypeAdd";
            this.btnShipTypeAdd.Size = new System.Drawing.Size(75, 23);
            this.btnShipTypeAdd.TabIndex = 4;
            this.btnShipTypeAdd.Text = "Add";
            this.btnShipTypeAdd.UseVisualStyleBackColor = true;
            this.btnShipTypeAdd.Click += new System.EventHandler(this.btnShipTypeAdd_Click);
            // 
            // txtShipTypeDesc
            // 
            this.txtShipTypeDesc.Location = new System.Drawing.Point(89, 54);
            this.txtShipTypeDesc.MaxLength = 100;
            this.txtShipTypeDesc.Multiline = true;
            this.txtShipTypeDesc.Name = "txtShipTypeDesc";
            this.txtShipTypeDesc.Size = new System.Drawing.Size(223, 71);
            this.txtShipTypeDesc.TabIndex = 3;
            // 
            // txtShipTypeName
            // 
            this.txtShipTypeName.Location = new System.Drawing.Point(89, 30);
            this.txtShipTypeName.MaxLength = 20;
            this.txtShipTypeName.Name = "txtShipTypeName";
            this.txtShipTypeName.Size = new System.Drawing.Size(223, 20);
            this.txtShipTypeName.TabIndex = 2;
            // 
            // txtShipTypeID
            // 
            this.txtShipTypeID.Location = new System.Drawing.Point(89, 8);
            this.txtShipTypeID.MaxLength = 20;
            this.txtShipTypeID.Name = "txtShipTypeID";
            this.txtShipTypeID.Size = new System.Drawing.Size(223, 20);
            this.txtShipTypeID.TabIndex = 1;
            // 
            // lblShipTypeDesc
            // 
            this.lblShipTypeDesc.AutoSize = true;
            this.lblShipTypeDesc.Location = new System.Drawing.Point(13, 57);
            this.lblShipTypeDesc.Name = "lblShipTypeDesc";
            this.lblShipTypeDesc.Size = new System.Drawing.Size(60, 13);
            this.lblShipTypeDesc.TabIndex = 12;
            this.lblShipTypeDesc.Text = "Description";
            // 
            // lblShipTypeName
            // 
            this.lblShipTypeName.AutoSize = true;
            this.lblShipTypeName.Location = new System.Drawing.Point(13, 33);
            this.lblShipTypeName.Name = "lblShipTypeName";
            this.lblShipTypeName.Size = new System.Drawing.Size(35, 13);
            this.lblShipTypeName.TabIndex = 11;
            this.lblShipTypeName.Text = "Name";
            // 
            // lblDhipTypeID
            // 
            this.lblDhipTypeID.AutoSize = true;
            this.lblDhipTypeID.Location = new System.Drawing.Point(13, 11);
            this.lblDhipTypeID.Name = "lblDhipTypeID";
            this.lblDhipTypeID.Size = new System.Drawing.Size(18, 13);
            this.lblDhipTypeID.TabIndex = 10;
            this.lblDhipTypeID.Text = "ID";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(84, 131);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmShipType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 190);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnShipTypeExit);
            this.Controls.Add(this.btnShipTypeDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnShipTypeAdd);
            this.Controls.Add(this.txtShipTypeDesc);
            this.Controls.Add(this.txtShipTypeName);
            this.Controls.Add(this.txtShipTypeID);
            this.Controls.Add(this.lblShipTypeDesc);
            this.Controls.Add(this.lblShipTypeName);
            this.Controls.Add(this.lblDhipTypeID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmShipType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ship Type Configuration Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShipTypeExit;
        private System.Windows.Forms.Button btnShipTypeDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnShipTypeAdd;
        private System.Windows.Forms.TextBox txtShipTypeDesc;
        private System.Windows.Forms.TextBox txtShipTypeName;
        private System.Windows.Forms.TextBox txtShipTypeID;
        private System.Windows.Forms.Label lblShipTypeDesc;
        private System.Windows.Forms.Label lblShipTypeName;
        private System.Windows.Forms.Label lblDhipTypeID;
        private System.Windows.Forms.Button btnSearch;
    }
}