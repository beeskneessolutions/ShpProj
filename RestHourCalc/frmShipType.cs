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
    public partial class frmShipType : Form
    {
        DBAccessLayer dbAccessLayer;
        public frmShipType()
        {
            InitializeComponent();
            dbAccessLayer = new DBAccessLayer();
        }

        private void btnShipTypeExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnShipTypeAdd_Click(object sender, EventArgs e)
        {
            if (!txtShipTypeDesc.Text.Equals("") && !txtShipTypeID.Text.Equals("") && !txtShipTypeName.Text.Equals(""))
            {
                if (dbAccessLayer.SaveToTable("tblshiptypemaster", new String[] { txtShipTypeID.Text, txtShipTypeName.Text, txtShipTypeDesc.Text }))
                {
                    MessageBox.Show("Added Successfully");
                    txtShipTypeDesc.Text = "";
                    txtShipTypeID.Text = "";
                    txtShipTypeName.Text = "";
                }
                else
                {
                    MessageBox.Show("Operation failed. Kindly check the values again.");
                }
            }
            else
            {
                MessageBox.Show("All fields are mandatory");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dtSearchResult = new DataTable();
            Boolean flag = false;
            if (txtShipTypeID.Text.Equals(""))
            {
                MessageBox.Show("Enter Ship Id to search");
            }
            else
            {
                dtSearchResult = dbAccessLayer.RetrieveTable("tblshiptypemaster", new String[] { "ShiptypeID" }, new String[] { txtShipTypeID.Text });
            }

            if (dtSearchResult != null)
            {
                if (dtSearchResult.Rows.Count > 0)
                {
                    txtShipTypeID.Text = dtSearchResult.Rows[0][0].ToString();

                    txtShipTypeName.Text = dtSearchResult.Rows[0][1].ToString();

                    txtShipTypeDesc.Text = dtSearchResult.Rows[0][2].ToString();
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
            iRowsAffected = dbAccessLayer.UpdateTable("tblshiptypemaster", new String[] { "ShipType", "ShipTypeDesc" }, new String[] { txtShipTypeName.Text, txtShipTypeDesc.Text }, new String[] { "ShiptypeID" }, new String[] { txtShipTypeID.Text });
            if (iRowsAffected)
            {
                MessageBox.Show("Details Updated Successfully");
            }
            else
            {
                MessageBox.Show("Updation failed");
            }

        }

        private void btnShipTypeDelete_Click(object sender, EventArgs e)
        {
            Boolean iRowsAffected = false;
            iRowsAffected = dbAccessLayer.DeleteRow("tblshiptypemaster", new String[] { "ShiptypeID" }, new String[] { txtShipTypeID.Text });
            if (iRowsAffected)
            {
                txtShipTypeID.Text = "";
                txtShipTypeDesc.Text = "";
                txtShipTypeName.Text = "";
                MessageBox.Show("Details Deleted Successfully");

            }
            else
            {
                MessageBox.Show("Deletion failed");
            }
        }
    }
}
