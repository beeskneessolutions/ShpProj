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
    public partial class frmShipMaster : Form
    {
        DBAccessLayer dbAccessLayer = new DBAccessLayer();
        public frmShipMaster()
        {
            InitializeComponent();
        }

       private void frmShipMaster_Load(object sender, EventArgs e)
        {
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
           if (txtShipNo.Text.Equals(""))
           {
               MessageBox.Show("Enter Ship Number to search");
           }
           else
           {
               dtSearchResult = dbAccessLayer.RetrieveTable("tblshipmaster", new String[] { "ShipNo" }, new String[] { txtShipNo.Text });
           }

           if (dtSearchResult != null)
           {
               if (dtSearchResult.Rows.Count > 0)
               {
                   txtShipNo.Text = dtSearchResult.Rows[0][0].ToString();

                   txtShipName.Text = dtSearchResult.Rows[0][1].ToString();
                   cmbBoxFleet.SelectedValue = dtSearchResult.Rows[0][2].ToString();
                   cmbBoxShipType.SelectedValue = dtSearchResult.Rows[0][3].ToString();
                   txtShipSize.Text = dtSearchResult.Rows[0][4].ToString();
                   txtShipCapacity.Text = dtSearchResult.Rows[0][5].ToString();
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
           iRowsAffected = dbAccessLayer.UpdateTable("tblshipmaster", new String[] { "ShipName", "Fleet", "ShipType", "ShipSize", "ShipCapacity" }, new String[] { txtShipName.Text, cmbBoxFleet.SelectedValue.ToString(), cmbBoxShipType.SelectedValue.ToString(), txtShipSize.Text, txtShipCapacity.Text}, new String[] { "ShipNo" }, new String[] { txtShipNo.Text });
           if (iRowsAffected)
           {
               MessageBox.Show("Details Updated Successfully");
           }
           else
           {
               MessageBox.Show("Updation failed");
           }
       }

       private void btnShipDelete_Click(object sender, EventArgs e)
       {
           Boolean iRowsAffected = false;
           iRowsAffected = dbAccessLayer.DeleteRow("tblshipmaster", new String[] { "ShipNo" }, new String[] { txtShipNo.Text });
           if (iRowsAffected)
           {
               txtShipNo.Text = "";
               txtShipName.Text = "";
               txtShipSize.Text = "";
               txtShipCapacity.Text = "";
               cmbBoxFleet.SelectedIndex = 0;
               cmbBoxShipType.SelectedIndex = 0;
               MessageBox.Show("Details Deleted Successfully");

           }
           else
           {
               MessageBox.Show("Deletion failed");
           }
       }

       
      }
}
