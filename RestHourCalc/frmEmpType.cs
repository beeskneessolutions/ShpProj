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
    public partial class frmEmpType : Form
    {
        DBAccessLayer dbAccessLayer;
        public frmEmpType()
        {
            InitializeComponent();
            dbAccessLayer = new DBAccessLayer();
        }

        private void btnEmpTypeAdd_Click(object sender, EventArgs e)
        {
            if (!txtEmpTypeDesc.Text.Equals("") && !txtEmpTypeID.Text.Equals("") && !txtEmpTypeName.Text.Equals(""))
            {
                if (dbAccessLayer.SaveToTable("tblemployeetypemaster", new String[] { txtEmpTypeID.Text, txtEmpTypeName.Text, txtEmpTypeDesc.Text }))
                {
                    MessageBox.Show("Added Successfully");
                    txtEmpTypeDesc.Text = "";
                    txtEmpTypeID.Text = "";
                    txtEmpTypeName.Text = "";
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

        private void btnEmpTypeExit_Click(object sender, EventArgs e)
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
            if (txtEmpTypeID.Text.Equals(""))
            {
                MessageBox.Show("Enter Employee Id to search");
            }
            else
            {
                dtSearchResult = dbAccessLayer.RetrieveTable("tblemployeetypemaster", new String[] { "EmpTypeId" }, new String[] { txtEmpTypeID.Text });
            }

            if (dtSearchResult != null)
            {
                if (dtSearchResult.Rows.Count > 0)
                {
                    txtEmpTypeID.Text = dtSearchResult.Rows[0][0].ToString();

                    txtEmpTypeName.Text = dtSearchResult.Rows[0][1].ToString();

                    txtEmpTypeDesc.Text = dtSearchResult.Rows[0][2].ToString();
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
            iRowsAffected = dbAccessLayer.UpdateTable("tblemployeetypemaster", new String[] { "EmpType", "EmpTypeDesc" }, new String[] { txtEmpTypeName.Text, txtEmpTypeDesc.Text }, new String[] { "EmpTypeID" }, new String[] { txtEmpTypeID.Text });
            if (iRowsAffected)
            {
                MessageBox.Show("Details Updated Successfully");
            }
            else
            {
                MessageBox.Show("Updation failed");
            }
        }

        private void btnEmpTypeDelete_Click(object sender, EventArgs e)
        {
            Boolean iRowsAffected = false;
            iRowsAffected = dbAccessLayer.DeleteRow("tblemployeetypemaster", new String[] { "EmpTypeID" }, new String[] { txtEmpTypeID.Text });
            if (iRowsAffected)
            {
                txtEmpTypeID.Text = "";
                txtEmpTypeDesc.Text = "";
                txtEmpTypeName.Text = "";
                MessageBox.Show("Details Deleted Successfully");

            }
            else
            {
                MessageBox.Show("Deletion failed");
            }

        }
    }
}
