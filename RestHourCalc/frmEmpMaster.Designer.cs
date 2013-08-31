namespace RestHourCalc
{
    partial class frmEmpMaster
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
            this.components = new System.ComponentModel.Container();
            this.panelEmpDetails = new System.Windows.Forms.Panel();
            this.grpBoxContractPeriod = new System.Windows.Forms.GroupBox();
            this.lblDateFormat = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.grpBoxActive = new System.Windows.Forms.GroupBox();
            this.rdBtnInactive = new System.Windows.Forms.RadioButton();
            this.rdBtnActive = new System.Windows.Forms.RadioButton();
            this.lblShip = new System.Windows.Forms.Label();
            this.lblEmpDepartment = new System.Windows.Forms.Label();
            this.lblEmployeeType = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblEmployeeNumber = new System.Windows.Forms.Label();
            this.cmbBoxShip = new System.Windows.Forms.ComboBox();
            this.tblshipmasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resthourcalcDataSet = new RestHourCalc.resthourcalcDataSet();
            this.cmbBoxEmpDept = new System.Windows.Forms.ComboBox();
            this.tbldepartmentmasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbBoxEmpType = new System.Windows.Forms.ComboBox();
            this.tblemployeetypemasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblDesignatio = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEmpAdd = new System.Windows.Forms.Button();
            this.tblemployeetypemasterTableAdapter = new RestHourCalc.resthourcalcDataSetTableAdapters.tblemployeetypemasterTableAdapter();
            this.tbldepartmentmasterTableAdapter = new RestHourCalc.resthourcalcDataSetTableAdapters.tbldepartmentmasterTableAdapter();
            this.tblshipmasterTableAdapter = new RestHourCalc.resthourcalcDataSetTableAdapters.tblshipmasterTableAdapter();
            this.btnDeptExit = new System.Windows.Forms.Button();
            this.panelEmpDetails.SuspendLayout();
            this.grpBoxContractPeriod.SuspendLayout();
            this.grpBoxActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblshipmasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resthourcalcDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbldepartmentmasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblemployeetypemasterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEmpDetails
            // 
            this.panelEmpDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEmpDetails.Controls.Add(this.grpBoxContractPeriod);
            this.panelEmpDetails.Controls.Add(this.grpBoxActive);
            this.panelEmpDetails.Controls.Add(this.lblShip);
            this.panelEmpDetails.Controls.Add(this.lblEmpDepartment);
            this.panelEmpDetails.Controls.Add(this.lblEmployeeType);
            this.panelEmpDetails.Controls.Add(this.txtEmpName);
            this.panelEmpDetails.Controls.Add(this.txtEmpNo);
            this.panelEmpDetails.Controls.Add(this.lblEmpName);
            this.panelEmpDetails.Controls.Add(this.lblEmployeeNumber);
            this.panelEmpDetails.Controls.Add(this.cmbBoxShip);
            this.panelEmpDetails.Controls.Add(this.cmbBoxEmpDept);
            this.panelEmpDetails.Controls.Add(this.cmbBoxEmpType);
            this.panelEmpDetails.Controls.Add(this.txtPassWord);
            this.panelEmpDetails.Controls.Add(this.lblDesignatio);
            this.panelEmpDetails.Location = new System.Drawing.Point(7, 5);
            this.panelEmpDetails.Name = "panelEmpDetails";
            this.panelEmpDetails.Size = new System.Drawing.Size(323, 309);
            this.panelEmpDetails.TabIndex = 19;
            // 
            // grpBoxContractPeriod
            // 
            this.grpBoxContractPeriod.Controls.Add(this.lblDateFormat);
            this.grpBoxContractPeriod.Controls.Add(this.txtToDate);
            this.grpBoxContractPeriod.Controls.Add(this.txtFromDate);
            this.grpBoxContractPeriod.Controls.Add(this.lblTo);
            this.grpBoxContractPeriod.Controls.Add(this.lblFrom);
            this.grpBoxContractPeriod.Location = new System.Drawing.Point(4, 213);
            this.grpBoxContractPeriod.Name = "grpBoxContractPeriod";
            this.grpBoxContractPeriod.Size = new System.Drawing.Size(204, 84);
            this.grpBoxContractPeriod.TabIndex = 29;
            this.grpBoxContractPeriod.TabStop = false;
            this.grpBoxContractPeriod.Text = "Contract Period";
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.AutoSize = true;
            this.lblDateFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFormat.Location = new System.Drawing.Point(39, 63);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(114, 13);
            this.lblDateFormat.TabIndex = 13;
            this.lblDateFormat.Text = "DD/MM/YYYY Format";
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(42, 40);
            this.txtToDate.MaxLength = 11;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(100, 20);
            this.txtToDate.TabIndex = 10;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Location = new System.Drawing.Point(42, 16);
            this.txtFromDate.MaxLength = 11;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(100, 20);
            this.txtFromDate.TabIndex = 9;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(6, 40);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(6, 16);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // grpBoxActive
            // 
            this.grpBoxActive.Controls.Add(this.rdBtnInactive);
            this.grpBoxActive.Controls.Add(this.rdBtnActive);
            this.grpBoxActive.Location = new System.Drawing.Point(4, 163);
            this.grpBoxActive.Name = "grpBoxActive";
            this.grpBoxActive.Size = new System.Drawing.Size(205, 44);
            this.grpBoxActive.TabIndex = 28;
            this.grpBoxActive.TabStop = false;
            this.grpBoxActive.Text = "Active/Inactive";
            // 
            // rdBtnInactive
            // 
            this.rdBtnInactive.AutoSize = true;
            this.rdBtnInactive.Location = new System.Drawing.Point(64, 16);
            this.rdBtnInactive.Name = "rdBtnInactive";
            this.rdBtnInactive.Size = new System.Drawing.Size(63, 17);
            this.rdBtnInactive.TabIndex = 8;
            this.rdBtnInactive.Text = "Inactive";
            this.rdBtnInactive.UseVisualStyleBackColor = true;
            this.rdBtnInactive.CheckedChanged += new System.EventHandler(this.rdBtnInactive_CheckedChanged);
            // 
            // rdBtnActive
            // 
            this.rdBtnActive.AutoSize = true;
            this.rdBtnActive.Checked = true;
            this.rdBtnActive.Location = new System.Drawing.Point(3, 16);
            this.rdBtnActive.Name = "rdBtnActive";
            this.rdBtnActive.Size = new System.Drawing.Size(55, 17);
            this.rdBtnActive.TabIndex = 7;
            this.rdBtnActive.TabStop = true;
            this.rdBtnActive.Text = "Active";
            this.rdBtnActive.UseVisualStyleBackColor = true;
            // 
            // lblShip
            // 
            this.lblShip.AutoSize = true;
            this.lblShip.Location = new System.Drawing.Point(1, 135);
            this.lblShip.Name = "lblShip";
            this.lblShip.Size = new System.Drawing.Size(28, 13);
            this.lblShip.TabIndex = 27;
            this.lblShip.Text = "Ship";
            // 
            // lblEmpDepartment
            // 
            this.lblEmpDepartment.AutoSize = true;
            this.lblEmpDepartment.Location = new System.Drawing.Point(1, 104);
            this.lblEmpDepartment.Name = "lblEmpDepartment";
            this.lblEmpDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblEmpDepartment.TabIndex = 26;
            this.lblEmpDepartment.Text = "Department";
            // 
            // lblEmployeeType
            // 
            this.lblEmployeeType.AutoSize = true;
            this.lblEmployeeType.Location = new System.Drawing.Point(1, 75);
            this.lblEmployeeType.Name = "lblEmployeeType";
            this.lblEmployeeType.Size = new System.Drawing.Size(31, 13);
            this.lblEmployeeType.TabIndex = 25;
            this.lblEmployeeType.Text = "Type";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(99, 27);
            this.txtEmpName.MaxLength = 20;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(175, 20);
            this.txtEmpName.TabIndex = 2;
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(99, 4);
            this.txtEmpNo.MaxLength = 20;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(175, 20);
            this.txtEmpNo.TabIndex = 1;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(1, 30);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(35, 13);
            this.lblEmpName.TabIndex = 22;
            this.lblEmpName.Text = "Name";
            // 
            // lblEmployeeNumber
            // 
            this.lblEmployeeNumber.AutoSize = true;
            this.lblEmployeeNumber.Location = new System.Drawing.Point(1, 7);
            this.lblEmployeeNumber.Name = "lblEmployeeNumber";
            this.lblEmployeeNumber.Size = new System.Drawing.Size(44, 13);
            this.lblEmployeeNumber.TabIndex = 21;
            this.lblEmployeeNumber.Text = "Number";
            // 
            // cmbBoxShip
            // 
            this.cmbBoxShip.DataSource = this.tblshipmasterBindingSource;
            this.cmbBoxShip.DisplayMember = "ShipName";
            this.cmbBoxShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxShip.FormattingEnabled = true;
            this.cmbBoxShip.Location = new System.Drawing.Point(99, 134);
            this.cmbBoxShip.Name = "cmbBoxShip";
            this.cmbBoxShip.Size = new System.Drawing.Size(175, 21);
            this.cmbBoxShip.TabIndex = 6;
            this.cmbBoxShip.ValueMember = "ShipNo";
            // 
            // tblshipmasterBindingSource
            // 
            this.tblshipmasterBindingSource.DataMember = "tblshipmaster";
            this.tblshipmasterBindingSource.DataSource = this.resthourcalcDataSet;
            // 
            // resthourcalcDataSet
            // 
            this.resthourcalcDataSet.DataSetName = "resthourcalcDataSet";
            this.resthourcalcDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbBoxEmpDept
            // 
            this.cmbBoxEmpDept.DataSource = this.tbldepartmentmasterBindingSource;
            this.cmbBoxEmpDept.DisplayMember = "DepartmentName";
            this.cmbBoxEmpDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxEmpDept.FormattingEnabled = true;
            this.cmbBoxEmpDept.Location = new System.Drawing.Point(99, 103);
            this.cmbBoxEmpDept.Name = "cmbBoxEmpDept";
            this.cmbBoxEmpDept.Size = new System.Drawing.Size(175, 21);
            this.cmbBoxEmpDept.TabIndex = 5;
            this.cmbBoxEmpDept.ValueMember = "DepartmentID";
            // 
            // tbldepartmentmasterBindingSource
            // 
            this.tbldepartmentmasterBindingSource.DataMember = "tbldepartmentmaster";
            this.tbldepartmentmasterBindingSource.DataSource = this.resthourcalcDataSet;
            // 
            // cmbBoxEmpType
            // 
            this.cmbBoxEmpType.DataSource = this.tblemployeetypemasterBindingSource;
            this.cmbBoxEmpType.DisplayMember = "EmpType";
            this.cmbBoxEmpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxEmpType.FormattingEnabled = true;
            this.cmbBoxEmpType.Location = new System.Drawing.Point(99, 74);
            this.cmbBoxEmpType.Name = "cmbBoxEmpType";
            this.cmbBoxEmpType.Size = new System.Drawing.Size(175, 21);
            this.cmbBoxEmpType.TabIndex = 4;
            this.cmbBoxEmpType.ValueMember = "EmpTypeID";
            // 
            // tblemployeetypemasterBindingSource
            // 
            this.tblemployeetypemasterBindingSource.DataMember = "tblemployeetypemaster";
            this.tblemployeetypemasterBindingSource.DataSource = this.resthourcalcDataSet;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(99, 50);
            this.txtPassWord.MaxLength = 20;
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(175, 20);
            this.txtPassWord.TabIndex = 3;
            // 
            // lblDesignatio
            // 
            this.lblDesignatio.AutoSize = true;
            this.lblDesignatio.Location = new System.Drawing.Point(0, 53);
            this.lblDesignatio.Name = "lblDesignatio";
            this.lblDesignatio.Size = new System.Drawing.Size(63, 13);
            this.lblDesignatio.TabIndex = 10;
            this.lblDesignatio.Text = "Designation";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(252, 319);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(171, 319);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(90, 319);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEmpAdd
            // 
            this.btnEmpAdd.Location = new System.Drawing.Point(9, 319);
            this.btnEmpAdd.Name = "btnEmpAdd";
            this.btnEmpAdd.Size = new System.Drawing.Size(75, 23);
            this.btnEmpAdd.TabIndex = 11;
            this.btnEmpAdd.Text = "Add";
            this.btnEmpAdd.UseVisualStyleBackColor = true;
            this.btnEmpAdd.Click += new System.EventHandler(this.btnEmpAdd_Click);
            // 
            // tblemployeetypemasterTableAdapter
            // 
            this.tblemployeetypemasterTableAdapter.ClearBeforeFill = true;
            // 
            // tbldepartmentmasterTableAdapter
            // 
            this.tbldepartmentmasterTableAdapter.ClearBeforeFill = true;
            // 
            // tblshipmasterTableAdapter
            // 
            this.tblshipmasterTableAdapter.ClearBeforeFill = true;
            // 
            // btnDeptExit
            // 
            this.btnDeptExit.Location = new System.Drawing.Point(131, 343);
            this.btnDeptExit.Name = "btnDeptExit";
            this.btnDeptExit.Size = new System.Drawing.Size(75, 23);
            this.btnDeptExit.TabIndex = 20;
            this.btnDeptExit.Text = "Exit";
            this.btnDeptExit.UseVisualStyleBackColor = true;
            this.btnDeptExit.Click += new System.EventHandler(this.btnDeptExit_Click);
            // 
            // frmEmpMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 371);
            this.Controls.Add(this.btnDeptExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnEmpAdd);
            this.Controls.Add(this.panelEmpDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmpMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Configuration Wizard";
            this.Load += new System.EventHandler(this.frmEmpMaster_Load);
            this.panelEmpDetails.ResumeLayout(false);
            this.panelEmpDetails.PerformLayout();
            this.grpBoxContractPeriod.ResumeLayout(false);
            this.grpBoxContractPeriod.PerformLayout();
            this.grpBoxActive.ResumeLayout(false);
            this.grpBoxActive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblshipmasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resthourcalcDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbldepartmentmasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblemployeetypemasterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEmpDetails;
        private System.Windows.Forms.ComboBox cmbBoxShip;
        private System.Windows.Forms.ComboBox cmbBoxEmpDept;
        private System.Windows.Forms.ComboBox cmbBoxEmpType;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label lblDesignatio;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblEmployeeNumber;
        private System.Windows.Forms.Label lblShip;
        private System.Windows.Forms.Label lblEmpDepartment;
        private System.Windows.Forms.Label lblEmployeeType;
        private System.Windows.Forms.GroupBox grpBoxActive;
        private System.Windows.Forms.RadioButton rdBtnInactive;
        private System.Windows.Forms.RadioButton rdBtnActive;
        private System.Windows.Forms.GroupBox grpBoxContractPeriod;
        private System.Windows.Forms.Label lblDateFormat;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnEmpAdd;
        private resthourcalcDataSet resthourcalcDataSet;
        private System.Windows.Forms.BindingSource tblemployeetypemasterBindingSource;
        private resthourcalcDataSetTableAdapters.tblemployeetypemasterTableAdapter tblemployeetypemasterTableAdapter;
        private System.Windows.Forms.BindingSource tbldepartmentmasterBindingSource;
        private resthourcalcDataSetTableAdapters.tbldepartmentmasterTableAdapter tbldepartmentmasterTableAdapter;
        private System.Windows.Forms.BindingSource tblshipmasterBindingSource;
        private resthourcalcDataSetTableAdapters.tblshipmasterTableAdapter tblshipmasterTableAdapter;
        private System.Windows.Forms.Button btnDeptExit;
    }
}