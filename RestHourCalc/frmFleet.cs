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
    public partial class frmFleet : Form
    {
        DBAccessLayer dbAccessLayer;
        public frmFleet()
        {
            InitializeComponent();
            dbAccessLayer = new DBAccessLayer();
        }

        private void btnFleetExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit","Confirmation Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAddFleet_Click(object sender, EventArgs e)
        {
            if (!txtFleetDesc.Text.Equals("") && !txtFleetID.Text.Equals("") && !txtFleetName.Text.Equals(""))
            {
                if (dbAccessLayer.SaveToTable("tblfleetmaster", new String[] { txtFleetID.Text, txtFleetName.Text, txtFleetDesc.Text }))
                {
                    MessageBox.Show("Successfully added");
                    txtFleetDesc.Clear();
                    txtFleetID.Clear(); 
                    txtFleetName.Clear();
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
            if (txtFleetID.Text.Equals(""))
            {
                MessageBox.Show("Enter Fleet Id to search");
            }
            else
            {
                dtSearchResult = dbAccessLayer.RetrieveTable("tblfleetmaster", new String[] { "FleetID" }, new String[] { txtFleetID.Text });
            }

            if (dtSearchResult != null)
            {
                if (dtSearchResult.Rows.Count > 0)
                {
                    txtFleetID.Text = dtSearchResult.Rows[0][0].ToString();

                    txtFleetName.Text = dtSearchResult.Rows[0][1].ToString();

                    txtFleetDesc.Text = dtSearchResult.Rows[0][2].ToString();
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
            iRowsAffected = dbAccessLayer.UpdateTable("tblfleetmaster", new String[] { "FleetName", "FleetDesc" }, new String[] { txtFleetName.Text, txtFleetDesc.Text }, new String[] { "FleetID" }, new String[] { txtFleetID.Text });
            if (iRowsAffected)
            {
                MessageBox.Show("Details Updated Successfully");
            }
            else
            {
                MessageBox.Show("Updation failed");
            }
        }

        private void btnFleetDelete_Click(object sender, EventArgs e)
        {
            Boolean iRowsAffected = false;
            iRowsAffected = dbAccessLayer.DeleteRow("tblfleetmaster", new String[] { "FleetID" }, new String[] { txtFleetID.Text });
            if (iRowsAffected)
            {
                txtFleetID.Text = "";
                txtFleetDesc.Text = "";
                txtFleetName.Text = "";
                MessageBox.Show("Details Deleted Successfully");

            }
            else
            {
                MessageBox.Show("Deletion failed");
            }
        }

        private void frmFleet_Load(object sender, EventArgs e)
        {

        }

      }
}
