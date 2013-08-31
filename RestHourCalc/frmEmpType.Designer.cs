namespace RestHourCalc
{
    partial class frmEmpType
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
            this.btnEmpTypeExit = new System.Windows.Forms.Button();
            this.btnEmpTypeDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnEmpTypeAdd = new System.Windows.Forms.Button();
            this.txtEmpTypeDesc = new System.Windows.Forms.TextBox();
            this.txtEmpTypeName = new System.Windows.Forms.TextBox();
            this.txtEmpTypeID = new System.Windows.Forms.TextBox();
            this.lblEmpTypeDesc = new System.Windows.Forms.Label();
            this.lblEmpTypeName = new System.Windows.Forms.Label();
            this.lblEmpTypeID = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmpTypeExit
            // 
            this.btnEmpTypeExit.Location = new System.Drawing.Point(117, 157);
            this.btnEmpTypeExit.Name = "btnEmpTypeExit";
            this.btnEmpTypeExit.Size = new System.Drawing.Size(75, 23);
            this.btnEmpTypeExit.TabIndex = 7;
            this.btnEmpTypeExit.Text = "Exit";
            this.btnEmpTypeExit.UseVisualStyleBackColor = true;
            this.btnEmpTypeExit.Click += new System.EventHandler(this.btnEmpTypeExit_Click);
            // 
            // btnEmpTypeDelete
            // 
            this.btnEmpTypeDelete.Location = new System.Drawing.Point(245, 128);
            this.btnEmpTypeDelete.Name = "btnEmpTypeDelete";
            this.btnEmpTypeDelete.Size = new System.Drawing.Size(75, 23);
            this.btnEmpTypeDelete.TabIndex = 6;
            this.btnEmpTypeDelete.Text = "Delete";
            this.btnEmpTypeDelete.UseVisualStyleBackColor = true;
            this.btnEmpTypeDelete.Click += new System.EventHandler(this.btnEmpTypeDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(164, 128);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnEmpTypeAdd
            // 
            this.btnEmpTypeAdd.Location = new System.Drawing.Point(2, 128);
            this.btnEmpTypeAdd.Name = "btnEmpTypeAdd";
            this.btnEmpTypeAdd.Size = new System.Drawing.Size(75, 23);
            this.btnEmpTypeAdd.TabIndex = 4;
            this.btnEmpTypeAdd.Text = "Add";
            this.btnEmpTypeAdd.UseVisualStyleBackColor = true;
            this.btnEmpTypeAdd.Click += new System.EventHandler(this.btnEmpTypeAdd_Click);
            // 
            // txtEmpTypeDesc
            // 
            this.txtEmpTypeDesc.Location = new System.Drawing.Point(88, 51);
            this.txtEmpTypeDesc.MaxLength = 100;
            this.txtEmpTypeDesc.Multiline = true;
            this.txtEmpTypeDesc.Name = "txtEmpTypeDesc";
            this.txtEmpTypeDesc.Size = new System.Drawing.Size(223, 71);
            this.txtEmpTypeDesc.TabIndex = 3;
            // 
            // txtEmpTypeName
            // 
            this.txtEmpTypeName.Location = new System.Drawing.Point(88, 27);
            this.txtEmpTypeName.MaxLength = 20;
            this.txtEmpTypeName.Name = "txtEmpTypeName";
            this.txtEmpTypeName.Size = new System.Drawing.Size(223, 20);
            this.txtEmpTypeName.TabIndex = 2;
            // 
            // txtEmpTypeID
            // 
            this.txtEmpTypeID.Location = new System.Drawing.Point(88, 5);
            this.txtEmpTypeID.MaxLength = 20;
            this.txtEmpTypeID.Name = "txtEmpTypeID";
            this.txtEmpTypeID.Size = new System.Drawing.Size(223, 20);
            this.txtEmpTypeID.TabIndex = 1;
            // 
            // lblEmpTypeDesc
            // 
            this.lblEmpTypeDesc.AutoSize = true;
            this.lblEmpTypeDesc.Location = new System.Drawing.Point(12, 54);
            this.lblEmpTypeDesc.Name = "lblEmpTypeDesc";
            this.lblEmpTypeDesc.Size = new System.Drawing.Size(60, 13);
            this.lblEmpTypeDesc.TabIndex = 22;
            this.lblEmpTypeDesc.Text = "Description";
            // 
            // lblEmpTypeName
            // 
            this.lblEmpTypeName.AutoSize = true;
            this.lblEmpTypeName.Location = new System.Drawing.Point(12, 30);
            this.lblEmpTypeName.Name = "lblEmpTypeName";
            this.lblEmpTypeName.Size = new System.Drawing.Size(35, 13);
            this.lblEmpTypeName.TabIndex = 21;
            this.lblEmpTypeName.Text = "Name";
            // 
            // lblEmpTypeID
            // 
            this.lblEmpTypeID.AutoSize = true;
            this.lblEmpTypeID.Location = new System.Drawing.Point(12, 8);
            this.lblEmpTypeID.Name = "lblEmpTypeID";
            this.lblEmpTypeID.Size = new System.Drawing.Size(18, 13);
            this.lblEmpTypeID.TabIndex = 20;
            this.lblEmpTypeID.Text = "ID";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(83, 128);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmEmpType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 191);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnEmpTypeExit);
            this.Controls.Add(this.btnEmpTypeDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnEmpTypeAdd);
            this.Controls.Add(this.txtEmpTypeDesc);
            this.Controls.Add(this.txtEmpTypeName);
            this.Controls.Add(this.txtEmpTypeID);
            this.Controls.Add(this.lblEmpTypeDesc);
            this.Controls.Add(this.lblEmpTypeName);
            this.Controls.Add(this.lblEmpTypeID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEmpType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Type Configuration Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmpTypeExit;
        private System.Windows.Forms.Button btnEmpTypeDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnEmpTypeAdd;
        private System.Windows.Forms.TextBox txtEmpTypeDesc;
        private System.Windows.Forms.TextBox txtEmpTypeName;
        private System.Windows.Forms.TextBox txtEmpTypeID;
        private System.Windows.Forms.Label lblEmpTypeDesc;
        private System.Windows.Forms.Label lblEmpTypeName;
        private System.Windows.Forms.Label lblEmpTypeID;
        private System.Windows.Forms.Button btnSearch;
    }
}