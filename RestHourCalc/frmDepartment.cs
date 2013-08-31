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
    public partial class frmDepartment : Form
    {
        DBAccessLayer dbAccessLayer;
        public frmDepartment()
        {
            InitializeComponent();
            dbAccessLayer = new DBAccessLayer();
        }

        private void btnDeptEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDeptAdd_Click(object sender, EventArgs e)
        {
            if (!txtDeptDesc.Text.Equals("") && !txtDeptID.Text.Equals("") && !txtDeptName.Text.Equals(""))
            {
                if (dbAccessLayer.SaveToTable("tbldepartmentmaster", new String[] { txtDeptID.Text, txtDeptName.Text, txtDeptDesc.Text }))
                {
                    MessageBox.Show("Added Successfully");
                    txtDeptDesc.Text = "";
                    txtDeptID.Text = "";
                    txtDeptName.Text = "";
                }
                else
                {
                    MessageBox.Show("Operation failed. Kindly check the values again.");
                }
            }
            else
            {
                MessageBox.Show("All the fields are mandatory.");
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
            DataTable dtSearchResult = new DataTable ();
            Boolean flag = false;
            if (txtDeptID.Text.Equals(""))
            {
                MessageBox.Show("Enter Department Id to search");
            }
            else
            {
                dtSearchResult= dbAccessLayer.RetrieveTable("tbldepartmentmaster", new String[] {"DepartmentId" }, new String[] {txtDeptID.Text  });
            }

            if (dtSearchResult != null)
            {
                if (dtSearchResult.Rows.Count > 0)
                {
                    txtDeptID.Text = dtSearchResult.Rows[0][0].ToString();
                   
                    txtDeptName.Text = dtSearchResult.Rows[0][1].ToString();

                    txtDeptDesc.Text = dtSearchResult.Rows[0][2].ToString();
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
            Boolean iRowsAffected = false ;
            iRowsAffected = dbAccessLayer.UpdateTable("tbldepartmentmaster", new String[] { "DepartmentName", "DepartmentDesc" }, new String[] { txtDeptName.Text, txtDeptDesc.Text }, new String[] { "DepartmentID" }, new String[] { txtDeptID.Text });
            if (iRowsAffected)
            {
                MessageBox.Show("Details Updated Successfully");
            }
            else
            {
                MessageBox.Show("Updation failed");
            }


        }

        private void btnDeptDelete_Click(object sender, EventArgs e)
        {
            Boolean iRowsAffected = false;
            iRowsAffected = dbAccessLayer.DeleteRow("tbldepartmentmaster",new String[] { "DepartmentID" }, new String[] { txtDeptID.Text });
            if (iRowsAffected)
            {
                txtDeptDesc.Text = "";
                txtDeptID.Text = "";
                txtDeptName.Text = "";
                MessageBox.Show("Details Deleted Successfully");

            }
            else
            {
                MessageBox.Show("Deletion failed");
            }

        }


    }
}
