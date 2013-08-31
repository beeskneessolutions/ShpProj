using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RestHourCalc
{
    public partial class frmViolationRep : Form
    {
        DBAccessLayer dbAccessLayer = new DBAccessLayer();
        public frmViolationRep()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (txtReportPath.Text == "" || !Directory.Exists(txtReportPath.Text.ToString()))
            {
                MessageBox.Show("Invalid Report Path");
            }
            else
            {
                try
                {
                    StreamWriter sw = File.CreateText(txtReportPath.Text + @"\ViolationReport - " + txtEmployeeId.Text + ".txt");
                    DataSet ds = dbAccessLayer.GetViolation(txtEmployeeId.Text, dtPickerFrom.Value, dtPickerTo.Value);

                    sw.WriteLine("Violation Report" + Environment.NewLine + "Name  : " + txtEmployeeId.Text + Environment.NewLine + "Rank  : " + "" + Environment.NewLine + "Month :  " + dtPickerFrom.Value.Month);
                    /*sw.WriteLine("__________________________________________________" + Environment.NewLine + " Index To Violations :" + Environment.NewLine +
                    "Case 1 : Less than 6 consecutive hours of rest in the last 24 hours." + Environment.NewLine + "Case 2 : Less than 10 hours of rest in the last 24 hours." + Environment.NewLine + "Case 3 : Rest hours comprise three periods in the last 24 hours."
                    + Environment.NewLine + "Case 4 : Rest hours comprise more than three periods in the last 24 hours." + Environment.NewLine + "Case 5 : Less than 77 hours of rest in the last 7 days." + Environment.NewLine + "Case 6 : Less than 70 hours of rest in the last 7 days."
                    + Environment.NewLine + "Case 7 : Less than 36 hours of rest in the last 72 hours." + Environment.NewLine + "__________________________________________________");
                    */
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                if (!ds.Tables[0].Rows[i][j].ToString().Equals("0"))
                                {
                                    sw.WriteLine(dtPickerFrom.Value.AddDays(i).ToString() + "     " + (((float)(j + 1) / 2)).ToString() + "  Violation - Case " + ds.Tables[0].Rows[i][j].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        sw.WriteLine("No Violations");
                    }
                    sw.Close();
                    MessageBox.Show("Report Generated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtReportPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
