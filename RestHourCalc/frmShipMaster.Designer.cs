namespace RestHourCalc
{
    partial class frmShipMaster
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
            this.btnShipDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbBoxFleet = new System.Windows.Forms.ComboBox();
            this.tblfleetmasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resthourcalcDataSet = new RestHourCalc.resthourcalcDataSet();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShipAdd = new System.Windows.Forms.Button();
            this.txtShipCapacity = new System.Windows.Forms.TextBox();
            this.cmbBoxShipType = new System.Windows.Forms.ComboBox();
            this.tblshiptypemasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtShipSize = new System.Windows.Forms.TextBox();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.txtShipNo = new System.Windows.Forms.TextBox();
            this.lblShipCapacity = new System.Windows.Forms.Label();
            this.lblShipSize = new System.Windows.Forms.Label();
            this.lblShipTyp = new System.Windows.Forms.Label();
            this.lblShipFleet = new System.Windows.Forms.Label();
            this.lblShipName = new System.Windows.Forms.Label();
            this.lblShipNumber = new System.Windows.Forms.Label();
            this.panelShipDetails = new System.Windows.Forms.Panel();
            this.tblfleetmasterTableAdapter = new RestHourCalc.resthourcalcDataSetTableAdapters.tblfleetmasterTableAdapter();
            this.tblshiptypemasterTableAdapter = new RestHourCalc.resthourcalcDataSetTableAdapters.tblshiptypemasterTableAdapter();
            this.btnShipExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblfleetmasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resthourcalcDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblshiptypemasterBindingSource)).BeginInit();
            this.panelShipDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShipDelete
            // 
            this.btnShipDelete.Location = new System.Drawing.Point(249, 200);
            this.btnShipDelete.Name = "btnShipDelete";
            this.btnShipDelete.Size = new System.Drawing.Size(75, 23);
            this.btnShipDelete.TabIndex = 10;
            this.btnShipDelete.Text = "Delete";
            this.btnShipDelete.UseVisualStyleBackColor = true;
            this.btnShipDelete.Click += new System.EventHandler(this.btnShipDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(87, 200);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbBoxFleet
            // 
            this.cmbBoxFleet.DataSource = this.tblfleetmasterBindingSource;
            this.cmbBoxFleet.DisplayMember = "FleetName";
            this.cmbBoxFleet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxFleet.FormattingEnabled = true;
            this.cmbBoxFleet.Location = new System.Drawing.Point(74, 61);
            this.cmbBoxFleet.Name = "cmbBoxFleet";
            this.cmbBoxFleet.Size = new System.Drawing.Size(175, 21);
            this.cmbBoxFleet.TabIndex = 3;
            this.cmbBoxFleet.ValueMember = "FleetID";
            // 
            // tblfleetmasterBindingSource
            // 
            this.tblfleetmasterBindingSource.DataMember = "tblfleetmaster";
            this.tblfleetmasterBindingSource.DataSource = this.resthourcalcDataSet;
            // 
            // resthourcalcDataSet
            // 
            this.resthourcalcDataSet.DataSetName = "resthourcalcDataSet";
            this.resthourcalcDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(168, 200);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnShipAdd
            // 
            this.btnShipAdd.Location = new System.Drawing.Point(6, 200);
            this.btnShipAdd.Name = "btnShipAdd";
            this.btnShipAdd.Size = new System.Drawing.Size(75, 23);
            this.btnShipAdd.TabIndex = 7;
            this.btnShipAdd.Text = "Add";
            this.btnShipAdd.UseVisualStyleBackColor = true;
            this.btnShipAdd.Click += new System.EventHandler(this.btnShipAdd_Click);
            // 
            // txtShipCapacity
            // 
            this.txtShipCapacity.Location = new System.Drawing.Point(82, 160);
            this.txtShipCapacity.MaxLength = 20;
            this.txtShipCapacity.Name = "txtShipCapacity";
            this.txtShipCapacity.Size = new System.Drawing.Size(175, 20);
            this.txtShipCapacity.TabIndex = 6;
            // 
            // cmbBoxShipType
            // 
            this.cmbBoxShipType.DataSource = this.tblshiptypemasterBindingSource;
            this.cmbBoxShipType.DisplayMember = "ShipType";
            this.cmbBoxShipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxShipType.FormattingEnabled = true;
            this.cmbBoxShipType.Location = new System.Drawing.Point(74, 89);
            this.cmbBoxShipType.Name = "cmbBoxShipType";
            this.cmbBoxShipType.Size = new System.Drawing.Size(175, 21);
            this.cmbBoxShipType.TabIndex = 4;
            this.cmbBoxShipType.ValueMember = "ShiptypeID";
            // 
            // tblshiptypemasterBindingSource
            // 
            this.tblshiptypemasterBindingSource.DataMember = "tblshiptypemaster";
            this.tblshiptypemasterBindingSource.DataSource = this.resthourcalcDataSet;
            // 
            // txtShipSize
            // 
            this.txtShipSize.Location = new System.Drawing.Point(82, 133);
            this.txtShipSize.MaxLength = 20;
            this.txtShipSize.Name = "txtShipSize";
            this.txtShipSize.Size = new System.Drawing.Size(175, 20);
            this.txtShipSize.TabIndex = 5;
            // 
            // txtShipName
            // 
            this.txtShipName.Location = new System.Drawing.Point(82, 45);
            this.txtShipName.MaxLength = 20;
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(175, 20);
            this.txtShipName.TabIndex = 2;
            // 
            // txtShipNo
            // 
            this.txtShipNo.Location = new System.Drawing.Point(82, 17);
            this.txtShipNo.MaxLength = 20;
            this.txtShipNo.Name = "txtShipNo";
            this.txtShipNo.Size = new System.Drawing.Size(175, 20);
            this.txtShipNo.TabIndex = 1;
            // 
            // lblShipCapacity
            // 
            this.lblShipCapacity.AutoSize = true;
            this.lblShipCapacity.Location = new System.Drawing.Point(8, 163);
            this.lblShipCapacity.Name = "lblShipCapacity";
            this.lblShipCapacity.Size = new System.Drawing.Size(48, 13);
            this.lblShipCapacity.TabIndex = 22;
            this.lblShipCapacity.Text = "Capacity";
            // 
            // lblShipSize
            // 
            this.lblShipSize.AutoSize = true;
            this.lblShipSize.Location = new System.Drawing.Point(8, 135);
            this.lblShipSize.Name = "lblShipSize";
            this.lblShipSize.Size = new System.Drawing.Size(27, 13);
            this.lblShipSize.TabIndex = 21;
            this.lblShipSize.Text = "Size";
            // 
            // lblShipTyp
            // 
            this.lblShipTyp.AutoSize = true;
            this.lblShipTyp.Location = new System.Drawing.Point(8, 103);
            this.lblShipTyp.Name = "lblShipTyp";
            this.lblShipTyp.Size = new System.Drawing.Size(31, 13);
            this.lblShipTyp.TabIndex = 20;
            this.lblShipTyp.Text = "Type";
            // 
            // lblShipFleet
            // 
            this.lblShipFleet.AutoSize = true;
            this.lblShipFleet.Location = new System.Drawing.Point(8, 71);
            this.lblShipFleet.Name = "lblShipFleet";
            this.lblShipFleet.Size = new System.Drawing.Size(30, 13);
            this.lblShipFleet.TabIndex = 19;
            this.lblShipFleet.Text = "Fleet";
            // 
            // lblShipName
            // 
            this.lblShipName.AutoSize = true;
            this.lblShipName.Location = new System.Drawing.Point(8, 48);
            this.lblShipName.Name = "lblShipName";
            this.lblShipName.Size = new System.Drawing.Size(35, 13);
            this.lblShipName.TabIndex = 18;
            this.lblShipName.Text = "Name";
            // 
            // lblShipNumber
            // 
            this.lblShipNumber.AutoSize = true;
            this.lblShipNumber.Location = new System.Drawing.Point(8, 20);
            this.lblShipNumber.Name = "lblShipNumber";
            this.lblShipNumber.Size = new System.Drawing.Size(44, 13);
            this.lblShipNumber.TabIndex = 17;
            this.lblShipNumber.Text = "Number";
            // 
            // panelShipDetails
            // 
            this.panelShipDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelShipDetails.Controls.Add(this.cmbBoxShipType);
            this.panelShipDetails.Controls.Add(this.cmbBoxFleet);
            this.panelShipDetails.Location = new System.Drawing.Point(6, 9);
            this.panelShipDetails.Name = "panelShipDetails";
            this.panelShipDetails.Size = new System.Drawing.Size(256, 185);
            this.panelShipDetails.TabIndex = 31;
            // 
            // tblfleetmasterTableAdapter
            // 
            this.tblfleetmasterTableAdapter.ClearBeforeFill = true;
            // 
            // tblshiptypemasterTableAdapter
            // 
            this.tblshiptypemasterTableAdapter.ClearBeforeFill = true;
            // 
            // btnShipExit
            // 
            this.btnShipExit.Location = new System.Drawing.Point(127, 224);
            this.btnShipExit.Name = "btnShipExit";
            this.btnShipExit.Size = new System.Drawing.Size(75, 23);
            this.btnShipExit.TabIndex = 32;
            this.btnShipExit.Text = "Exit";
            this.btnShipExit.UseVisualStyleBackColor = true;
            this.btnShipExit.Click += new System.EventHandler(this.btnEmpTypeExit_Click);
            // 
            // frmShipMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 250);
            this.Controls.Add(this.btnShipExit);
            this.Controls.Add(this.btnShipDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnShipAdd);
            this.Controls.Add(this.txtShipCapacity);
            this.Controls.Add(this.txtShipSize);
            this.Controls.Add(this.txtShipName);
            this.Controls.Add(this.txtShipNo);
            this.Controls.Add(this.lblShipCapacity);
            this.Controls.Add(this.lblShipSize);
            this.Controls.Add(this.lblShipTyp);
            this.Controls.Add(this.lblShipFleet);
            this.Controls.Add(this.lblShipName);
            this.Controls.Add(this.lblShipNumber);
            this.Controls.Add(this.panelShipDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmShipMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ship Configuration Wizard";
            this.Load += new System.EventHandler(this.frmShipMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblfleetmasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resthourcalcDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblshiptypemasterBindingSource)).EndInit();
            this.panelShipDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShipDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbBoxFleet;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnShipAdd;
        private System.Windows.Forms.TextBox txtShipCapacity;
        private System.Windows.Forms.ComboBox cmbBoxShipType;
        private System.Windows.Forms.TextBox txtShipSize;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.TextBox txtShipNo;
        private System.Windows.Forms.Label lblShipCapacity;
        private System.Windows.Forms.Label lblShipSize;
        private System.Windows.Forms.Label lblShipTyp;
        private System.Windows.Forms.Label lblShipFleet;
        private System.Windows.Forms.Label lblShipName;
        private System.Windows.Forms.Label lblShipNumber;
        private System.Windows.Forms.Panel panelShipDetails;
        private resthourcalcDataSet resthourcalcDataSet;
        private System.Windows.Forms.BindingSource tblfleetmasterBindingSource;
        private resthourcalcDataSetTableAdapters.tblfleetmasterTableAdapter tblfleetmasterTableAdapter;
        private System.Windows.Forms.BindingSource tblshiptypemasterBindingSource;
        private resthourcalcDataSetTableAdapters.tblshiptypemasterTableAdapter tblshiptypemasterTableAdapter;
        private System.Windows.Forms.Button btnShipExit;
    }
}