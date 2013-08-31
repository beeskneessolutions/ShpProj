using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestHourCalc
{
    public partial class frmEmpMaster : Form
    {
        DBAccessLayer dbAccessLayer = new DBAccessLayer();
        public frmEmpMaster()
        {
            InitializeComponent();
        }

        private void frmEmpMaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'resthourcalcDataSet.tblshipmaster' table. You can move, or remove it, as needed.
            this.tblshipmasterTableAdapter.Fill(this.resthourcalcDataSet.tblshipmaster);
            // TODO: This line of code loads data into the 'resthourcalcDataSet.tbldepartmentmaster' table. You can move, or remove it, as needed.
            this.tbldepartmentmasterTableAdapter.Fill(this.resthourcalcDataSet.tbldepartmentmaster);
            // TODO: This line of code loads data into the 'resthourcalcDataSet.tblemployeetypemaster' table. You can move, or remove it, as needed.
            this.tblemployeetypemasterTableAdapter.Fill(this.resthourcalcDataSet.tblemployeetypemaster);

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
            if (!txtEmpNo.Text.Equals("") && !txtEmpName.Text.Equals("") && !txtPassWord.Text.Equals(""))
            {
                if (dbAccessLayer.SaveToTable("tblempmaster", new String[] { txtEmpNo.Text, txtEmpName.Text, cmbBoxEmpType.SelectedValue.ToString(), cmbBoxEmpDept.SelectedValue.ToString(), cmbBoxShip.SelectedValue.ToString(), (rdBtnActive.Checked ? "1" : "0"), strFromDate, strToDate, txtPassWord.Text }))
                {
                    if (dbAccessLayer.SaveToTable("tblsecurity", new String[] { txtEmpNo.Text, txtEmpName.Text, txtEmpNo.Text, "Emp" }))
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
       private void rdBtnInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnInactive.Checked)
            {
                grpBoxContractPeriod.Enabled = false;
            }
            else
            {
                grpBoxContractPeriod.Enabled = true;
            }
        }

       private void btnDeptExit_Click(object sender, EventArgs e)
       {
           DialogResult dialogResult = MessageBox.Show("Do you really want to exit", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (dialogResult == DialogResult.Yes)
           {
               this.Close();
           }
       }

       private void btnSearch_Click(object sender, EventArgs e)
       {
           DataTable dtSearchResult = new DataTable();
           Boolean flag = false;
           if (txtEmpNo.Text.Equals(""))
           {
               MessageBox.Show("Enter Employee Number to search");
           }
           else
           {
               dtSearchResult = dbAccessLayer.RetrieveTable("tblempmaster", new String[] { "EmpNo" }, new String[] { txtEmpNo.Text });
           }

           if (dtSearchResult != null)
           {
               if (dtSearchResult.Rows.Count > 0)
               {
                   txtEmpNo.Text = dtSearchResult.Rows[0][0].ToString();

                   txtEmpName.Text = dtSearchResult.Rows[0][1].ToString();
                   cmbBoxEmpType.SelectedValue = dtSearchResult.Rows[0][2].ToString();
                   cmbBoxEmpDept.SelectedValue = dtSearchResult.Rows[0][3].ToString();
                   cmbBoxShip.SelectedValue = dtSearchResult.Rows[0][4].ToString();
                   if (Boolean .Parse (dtSearchResult .Rows [0][5].ToString ()))
                   {
                       rdBtnActive.Checked = true ;
                   }
                   else 
                   {
                       rdBtnInactive.Checked = true ;
                   }
                   txtFromDate.Text = dtSearchResult.Rows[0][6].ToString();
                   txtToDate.Text = dtSearchResult.Rows[0][7].ToString();
                   txtPassWord.Text = dtSearchResult.Rows[0][8].ToString();
                   flag = true;
               }
               else
               {
                   flag = false;
               }
           }
           else
           {
               flag = false;
           }

           if (!flag)
           {
               MessageBox.Show("No results found");
           }

       }

       private void btnUpdate_Click(object sender, EventArgs e)
       {
           Boolean iRowsAffected = false;
           iRowsAffected = dbAccessLayer.UpdateTable("tblempmaster", new String[] { "EmpName", "EmpType", "EmpDepartment", "EmpShip", "EmpStatus", "EmpFrom", "EmpTo", "Designation" }, new String[] { txtEmpName.Text, cmbBoxEmpType.SelectedValue .ToString (),cmbBoxEmpDept.SelectedValue.ToString (),cmbBoxShip.SelectedValue .ToString (), rdBtnActive.Checked ?"1":"0", txtFromDate.Text ,txtToDate .Text ,txtPassWord.Text  }, new String[] { "EmpNo" }, new String[] { txtEmpNo.Text });
           if (iRowsAffected)
           {
               MessageBox.Show("Details Updated Successfully");
           }
           else
           {
               MessageBox.Show("Updation failed");
           }
       }

       private void btnDelete_Click(object sender, EventArgs e)
       {
           Boolean iRowsAffected = false;
           iRowsAffected = dbAccessLayer.DeleteRow("tblempmaster", new String[] { "EmpNo" }, new String[] { txtEmpNo.Text });
           if (iRowsAffected)
           {
               txtEmpNo.Text = "";
               txtEmpName.Text = "";
               txtFromDate.Text = "";
               txtPassWord.Text = "";
               txtToDate.Text = "";
               cmbBoxShip.SelectedIndex = 0;
               cmbBoxEmpType.SelectedIndex = 0;
               cmbBoxEmpDept.SelectedIndex = 0;
               rdBtnActive.Checked = true;
               MessageBox.Show("Details Deleted Successfully");

           }
           else
           {
               MessageBox.Show("Deletion failed");
           }
       }


    }
}
