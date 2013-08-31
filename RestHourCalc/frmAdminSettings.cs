using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace RestHourCalc
{
    public partial class frmAdminSettings : Form
    {
        DBAccessLayer dbAccessLayer = new DBAccessLayer();
        public frmAdminSettings()
        {
            InitializeComponent();
        }

        private void btnAdminProceed_Click(object sender, EventArgs e)
        {
            tabCtrlAdministration.SelectedTab = tabPgShipDetails;
        }

        private void btnAdminShipBack_Click(object sender, EventArgs e)
        {
            tabCtrlAdministration.SelectedTab = tabPgAdminSettings;
        }

        private void btnAdminShipProceed_Click(object sender, EventArgs e)
        {
            tabCtrlAdministration.SelectedTab = tabPgEmpDetail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabCtrlAdministration.SelectedTab = tabPgShipDetails;
        }

        private void btnAdminExit_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnFleet_Click(object sender, EventArgs e)
        {
            frmFleet objFleet = new frmFleet();
            objFleet.Show();
        }

        private void btnShipType_Click(object sender, EventArgs e)
        {
            frmShipType objShipType = new frmShipType();
            objShipType.Show();
        }

        private void btnEmpType_Click(object sender, EventArgs e)
        {
            frmEmpType objEmpType = new frmEmpType();
            objEmpType.Show();
        }

        private void btnEmpDept_Click(object sender, EventArgs e)
        {
            frmDepartment objDept = new frmDepartment();
            objDept.Show();
        }

        private void btnAdminSaveSettings_Click(object sender, EventArgs e)
        {

        }

        private void frmAdminSettings_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'resthourcalcDataSet.tbldepartmentmaster' table. You can move, or remove it, as needed.
            this.tbldepartmentmasterTableAdapter.Fill(this.resthourcalcDataSet.tbldepartmentmaster);
            // TODO: This line of code loads data into the 'resthourcalcDataSet.tblshipmaster' table. You can move, or remove it, as needed.
            this.tblshipmasterTableAdapter.Fill(this.resthourcalcDataSet.tblshipmaster);
            // TODO: This line of code loads data into the 'resthourcalcDataSet.tblemployeetypemaster' table. You can move, or remove it, as needed.
            this.tblemployeetypemasterTableAdapter.Fill(this.resthourcalcDataSet.tblemployeetypemaster);
            // TODO: This line of code loads data into the 'resthourcalcDataSet.tblshiptypemaster' table. You can move, or remove it, as needed.
            this.tblshiptypemasterTableAdapter.Fill(this.resthourcalcDataSet.tblshiptypemaster);
            // TODO: This line of code loads data into the 'resthourcalcDataSet.tblfleetmaster' table. You can move, or remove it, as needed.
            this.tblfleetmasterTableAdapter.Fill(this.resthourcalcDataSet.tblfleetmaster);

        }

        private void btnShipAdd_Click(object sender, EventArgs e)
        {
            if (!txtShipNo.Text.Equals("") && !txtShipName.Text.Equals("") && !txtShipSize.Text.Equals("") && !txtShipCapacity.Text.Equals(""))
            {
                if (dbAccessLayer.SaveToTable("tblshipmaster", new String[] { txtShipNo.Text, txtShipName.Text, cmbBoxFleet.SelectedValue.ToString(), cmbBoxShipType.SelectedValue.ToString(), txtShipSize.Text, txtShipCapacity.Text }))
                {
                    MessageBox.Show("Added Successfully");
                    txtShipNo.Text = "";
                    txtShipName.Text = "";
                    txtShipSize.Text = "";
                    txtShipCapacity.Text = "";
                    
                }
                else
                {
                    MessageBox.Show("Operation failed. Kindly check the values again.");
                }
            }
            else
            {
                MessageBox.Show("All the fields are mandatory");
            }
        }

        private void btnEmpAdd_Click(object sender, EventArgs e)
        {
            String strFromDate = String.Empty;
            String strToDate = String.Empty;

            if (txtFromDate.Text.Equals("") || txtToDate.Text.Equals(""))
            {
                strFromDate = "01012999";
                strToDate = "01012999";
            }
            else
            {
                strFromDate = txtFromDate.Text;
                strToDate = txtToDate.Text;
            }
            if (!txtEmpNo.Text .Equals ("") && !txtEmpName.Text .Equals ("") && !txtPassWord.Text .Equals (""))
            {
                if (dbAccessLayer.SaveToTable("tblempmaster", new String[] { txtEmpNo.Text, txtEmpName.Text, cmbBoxEmpType.SelectedValue.ToString(), cmbBoxEmpDept.SelectedValue.ToString(), cmbBoxShip.SelectedValue.ToString(), (rdBtnActive.Checked ? "1" : "0"), strFromDate, strToDate, txtPassWord.Text }))
                {
                    if (dbAccessLayer.SaveToTable("tblsecurity",new String []{txtEmpName.Text ,txtEmpName.Text ,txtEmpName.Text ,"Emp"}))
                    {
                        MessageBox.Show("Added Successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Operation failed. Kindly check the values again.");
                }
               
            }
            else
            {
                MessageBox.Show("All the fields are mandatory");
            }
        }

        

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            StreamWriter sw =File .CreateText ("E:\\ViolationReport.txt");
            DataSet ds=dbAccessLayer.GetViolation(txtEmployeeId.Text, dtPickerFrom.Value , dtPickerTo.Value );

            sw.WriteLine("Violation Report" + Environment.NewLine + "Name  : " + txtEmployeeId.Text + Environment.NewLine + "Rank  : "+""+Environment .NewLine +"Month :  "+dtPickerFrom.Value .Month);
            sw.WriteLine ("__________________________________________________"+Environment .NewLine +" Index To Violations :"+Environment .NewLine +
"Case 1 : Less than 6 consecutive hours of rest in the last 24 hours."+Environment .NewLine +"Case 2 : Less than 10 hours of rest in the last 24 hours."+Environment .NewLine +"Case 3 : Rest hours comprise three periods in the last 24 hours."
+Environment .NewLine +"Case 4 : Rest hours comprise more than three periods in the last 24 hours."+Environment .NewLine +"Case 5 : Less than 77 hours of rest in the last 7 days."+Environment .NewLine +"Case 6 : Less than 70 hours of rest in the last 7 days."
+Environment .NewLine +"Case 7 : Less than 36 hours of rest in the last 72 hours."+Environment .NewLine +"__________________________________________________");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    for(int j = 0; j < ds.Tables[0].Columns.Count;j++)
                    {
                        if (!ds.Tables[0].Rows[i][j].ToString().Equals("0"))
                        {
                            sw.WriteLine(dtPickerFrom.Value.AddDays(i).ToString() + "     " + (((float)(j+1) / 2)).ToString() + "  Violation - Case " + ds.Tables[0].Rows[i][j].ToString());
                        }
                    }
                }
            }
            else
            {
                sw.WriteLine("No Violations");
            }
            sw.Close();
            
            
        }



        

        private void tabPgShipDetails_Enter(object sender, EventArgs e)
        {
            //Refreshing Fleet Data Set
            this.tblfleetmasterTableAdapter.ClearBeforeFill = true;
            this.tblfleetmasterTableAdapter.Fill(this.resthourcalcDataSet.tblfleetmaster);
            //Refreshing Ship Type Data Set
            this.tblshiptypemasterTableAdapter.ClearBeforeFill = true;
            this.tblshiptypemasterTableAdapter.Fill(this.resthourcalcDataSet.tblshiptypemaster);  
        }

        private void tabPgEmpDetail_Enter(object sender, EventArgs e)
        {
            //Refreshing Employee Type DataSet
            this.tblemployeetypemasterTableAdapter.ClearBeforeFill = true;
            this.tblemployeetypemasterTableAdapter.Fill(this.resthourcalcDataSet.tblemployeetypemaster);

            //Refreshing Ship Data Set
            this.tblshipmasterTableAdapter.ClearBeforeFill = true;
            this.tblshipmasterTableAdapter.Fill(this.resthourcalcDataSet.tblshipmaster);

            //Refreshing Department DataSet
            this.tbldepartmentmasterTableAdapter.ClearBeforeFill = true;
            this.tbldepartmentmasterTableAdapter.Fill(this.resthourcalcDataSet.tbldepartmentmaster);
        }


     
    }
}
