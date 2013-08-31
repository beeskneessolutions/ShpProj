namespace RestHourCalc
{
    partial class frmDepartment
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
            this.btnDeptExit = new System.Windows.Forms.Button();
            this.btnDeptDelete = new System.Windows.Forms.Button();
            this.btnDeptAdd = new System.Windows.Forms.Button();
            this.txtDeptDesc = new System.Windows.Forms.TextBox();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.txtDeptID = new System.Windows.Forms.TextBox();
            this.lblDeptDesc = new System.Windows.Forms.Label();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.lblDeptID = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeptExit
            // 
            this.btnDeptExit.Location = new System.Drawing.Point(123, 162);
            this.btnDeptExit.Name = "btnDeptExit";
            this.btnDeptExit.Size = new System.Drawing.Size(75, 23);
            this.btnDeptExit.TabIndex = 7;
            this.btnDeptExit.Text = "Exit";
            this.btnDeptExit.UseVisualStyleBackColor = true;
            this.btnDeptExit.Click += new System.EventHandler(this.btnDeptExit_Click);
            // 
            // btnDeptDelete
            // 
            this.btnDeptDelete.Location = new System.Drawing.Point(245, 128);
            this.btnDeptDelete.Name = "btnDeptDelete";
            this.btnDeptDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDeptDelete.TabIndex = 6;
            this.btnDeptDelete.Text = "Delete";
            this.btnDeptDelete.UseVisualStyleBackColor = true;
            this.btnDeptDelete.Click += new System.EventHandler(this.btnDeptDelete_Click);
            // 
            // btnDeptAdd
            // 
            this.btnDeptAdd.Location = new System.Drawing.Point(2, 128);
            this.btnDeptAdd.Name = "btnDeptAdd";
            this.btnDeptAdd.Size = new System.Drawing.Size(75, 23);
            this.btnDeptAdd.TabIndex = 4;
            this.btnDeptAdd.Text = "Add";
            this.btnDeptAdd.UseVisualStyleBackColor = true;
            this.btnDeptAdd.Click += new System.EventHandler(this.btnDeptAdd_Click);
            // 
            // txtDeptDesc
            // 
            this.txtDeptDesc.Location = new System.Drawing.Point(88, 51);
            this.txtDeptDesc.MaxLength = 100;
            this.txtDeptDesc.Multiline = true;
            this.txtDeptDesc.Name = "txtDeptDesc";
            this.txtDeptDesc.Size = new System.Drawing.Size(223, 71);
            this.txtDeptDesc.TabIndex = 3;
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(88, 27);
            this.txtDeptName.MaxLength = 20;
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(223, 20);
            this.txtDeptName.TabIndex = 2;
            // 
            // txtDeptID
            // 
            this.txtDeptID.Location = new System.Drawing.Point(88, 5);
            this.txtDeptID.MaxLength = 20;
            this.txtDeptID.Name = "txtDeptID";
            this.txtDeptID.Size = new System.Drawing.Size(223, 20);
            this.txtDeptID.TabIndex = 1;
            // 
            // lblDeptDesc
            // 
            this.lblDeptDesc.AutoSize = true;
            this.lblDeptDesc.Location = new System.Drawing.Point(12, 54);
            this.lblDeptDesc.Name = "lblDeptDesc";
            this.lblDeptDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDeptDesc.TabIndex = 12;
            this.lblDeptDesc.Text = "Description";
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Location = new System.Drawing.Point(12, 30);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(35, 13);
            this.lblDeptName.TabIndex = 11;
            this.lblDeptName.Text = "Name";
            // 
            // lblDeptID
            // 
            this.lblDeptID.AutoSize = true;
            this.lblDeptID.Location = new System.Drawing.Point(12, 8);
            this.lblDeptID.Name = "lblDeptID";
            this.lblDeptID.Size = new System.Drawing.Size(18, 13);
            this.lblDeptID.TabIndex = 10;
            this.lblDeptID.Text = "ID";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(83, 128);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(164, 128);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 197);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDeptExit);
            this.Controls.Add(this.btnDeptDelete);
            this.Controls.Add(this.btnDeptAdd);
            this.Controls.Add(this.txtDeptDesc);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.txtDeptID);
            this.Controls.Add(this.lblDeptDesc);
            this.Controls.Add(this.lblDeptName);
            this.Controls.Add(this.lblDeptID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(500, 300);
            this.MaximizeBox = false;
            this.Name = "frmDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Department Configuration Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeptExit;
        private System.Windows.Forms.Button btnDeptDelete;
        private System.Windows.Forms.Button btnDeptAdd;
        private System.Windows.Forms.TextBox txtDeptDesc;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.TextBox txtDeptID;
        private System.Windows.Forms.Label lblDeptDesc;
        private System.Windows.Forms.Label lblDeptName;
        private System.Windows.Forms.Label lblDeptID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
    }
}