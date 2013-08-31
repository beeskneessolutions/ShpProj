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
    public partial class frmRestHourManager : Form
    {
        RestHourViolation violationObject;
        DataSet ds;
        DBAccessLayer dbAccessLayer;
        String USERID;
        String ROLE;
        ToolTip tp;
        public frmRestHourManager(String strUserId,String strRole)
        {
            InitializeComponent();
            dbAccessLayer = new DBAccessLayer();
            violationObject = new RestHourViolation();
            tp = new ToolTip();
            USERID = strUserId;
            ROLE = strRole;
            cmbMonth.SelectedIndex = DateTime.Today.Month - 1; //Loading Current Month
            cmbYear.SelectedIndex = (DateTime.Today.Year - 1990); //Loading Current Year
            
            //Disabling the following two buttons based on client request
            btnClearForm.Visible = false;
            btnCheckViolation.Visible = false;


            

            Control[] c;
            if (VerifyContractPeriod()) //Check for contract period of the employee
            {
                FillTableWithLabels(); //Initializing all the labels
                FillTableWithCheckbox(); //Initializing all teh check boxes
                UpdateDateDayLabels(); //Updating all the labels and Checkboxes 

                LoadUserDetails(USERID);
                LoadHourDetails(); //Loading Rest hour details for teh employee
                ViolationCheck(); //Checking for Violation if any
                
                
            }
            else
            {
                MessageBox.Show("Your Contract Period is over!");
                this.Close();
            }

            if (ROLE.Equals("Emp"))
            {
                //TO enable or disable checkbox based on date
                if (ds != null)
                {
                    for (int i = 1; i <= DateTime.DaysInMonth(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1) + 1; i++)
                    {
                        for (int j = 1; j <= 48; j++)
                        {
                            c = this.Controls.Find("DynCheckBox-" + i.ToString() + "-" + j.ToString(), true);
                            if (c.Count() != 0)
                            {
                                CheckBox cb = (CheckBox)c[0];
                                if ((cmbMonth.SelectedIndex + 1 > DateTime.Today.Month || cmbMonth.SelectedIndex + 1 < DateTime.Today.Month) || ((cmbMonth.SelectedIndex + 1 == DateTime.Today.Month) && (i > DateTime.Today.Day || i < DateTime.Today.Day)))
                                {
                                    cb.Enabled = false;
                                }
                                else
                                {
                                    cb.Enabled = true;
                                }



                            }
                        }

                    }
                }
                cmbMonth.Enabled = false;
                cmbYear.Enabled = false;

                txtShipName.Enabled = false;
                txtEmpId.Enabled = false;
                txtRank.Enabled = false;
                txtName.Enabled = false;

                btnLoad.Enabled = false;
                btnClearForm.Enabled = false;

            }
            else
            {
                cmbMonth.Enabled = true ;
                cmbYear.Enabled = true;

                txtShipName.Enabled = true;
                txtEmpId.Enabled = true;
                txtRank.Enabled = true;
                txtName.Enabled = true;

                btnLoad.Enabled = true;
                btnClearForm.Enabled = true;
            }
        }

        /// <summary>
        /// This method will create Checkboxes to enter rest hour details.
        /// </summary>
        private void FillTableWithCheckbox()
        {
            int rowCount = tableLayoutPanel1.RowCount;
            int colCount = 51;

            //Initially 31*48 checkboxes will be created. Unwanted checkkboxes are hidden using a call to UpdateDateDayLabels method.
            for (int i = 0; i < 31; i++)
            {
                for (int j = 2; j < colCount - 1; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Anchor = AnchorStyles.Top;
                    cb.Anchor = AnchorStyles.Bottom;
                    cb.Anchor = AnchorStyles.Left;
                    cb.Anchor = AnchorStyles.Right;
                    cb.Name = "DynCheckBox-" + (i +1).ToString() + "-" + (j - 1).ToString();
                    cb.Size = new System.Drawing.Size(20, 20);
                    //cb.Padding = new System.Windows.Forms.Padding(0);                
                    tableLayoutPanel1.Controls.Add(cb);
                    tableLayoutPanel1.SetRow(cb, i);
                    tableLayoutPanel1.SetColumn(cb, j);

                    //Event for each checkbox
                    cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
                    cb.MouseHover += new EventHandler(cb_MouseHover);
                }
            }
        }

        void cb_MouseHover(object sender, EventArgs e)
        {
            
            tp.ShowAlways = true;
            String[] str = ((CheckBox)sender).Name.Split('-');
            int[] currentRowCol = { int.Parse(str[1]), int.Parse(str[2]) };
            if (ds != null)
            {
                if (ds.Tables["tblviolation"].Rows.Count >= currentRowCol[0])
                {
                    if (!ds.Tables["tblviolation"].Rows[currentRowCol[0] - 1][currentRowCol[1] - 1].ToString().Equals("0"))
                    {
                       // if (!tp.Active)
                        {
                            tp.Show("Violation Case " + ds.Tables["tblviolation"].Rows[currentRowCol[0] - 1][currentRowCol[1] - 1].ToString(), ((CheckBox)sender), 1000);
                        }
                    }
                } 
            }
        }


        /// <summary>
        /// This method will create neccessary labels for Day, date ans Hours
        /// </summary>
        private void FillTableWithLabels()
        {
            int rowCount = tableLayoutPanel1.RowCount;
            int colCount = 24;

            //Date
            //Initially 31 labels will be created. Unwanted labels are hidden using a call to UpdateDateDayLabels method.
            for (int i = 0; i < 31; i++)
            {
                
                Label lbl = new Label();
                lbl.Text = (i +1).ToString();
                lbl.Name = "DynLabelDate" + (i+1).ToString();
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel1.Controls.Add(lbl);
                tableLayoutPanel1.SetRow(lbl, i);
                tableLayoutPanel1.SetColumn(lbl, 0);
            }

            //Day
            //Initially 31 labels will be created. Unwanted labels are hidden using a call to UpdateDateDayLabels method.
            for (int i = 0; i < 32; i++)
            {
                //T0 add dates
                Label lbl = new Label();
                try
                {
                    lbl.Name = "DynLabelDay" + (i +1).ToString();
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    tableLayoutPanel1.Controls.Add(lbl);
                    tableLayoutPanel1.SetRow(lbl, i);
                    tableLayoutPanel1.SetColumn(lbl, 1);
                    lbl.Text = new DateTime(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1, i +1).DayOfWeek.ToString("G").Substring(0, 3);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    lbl.Visible = false;
                    continue;
                }
                
            }


            //Hours 1 to 24
     /*       for (int i = 0; i < colCount; i++)
            {
                Label lbl = new Label();
                lbl.Name = "DynLabelHour" + i.ToString();
                lbl.Text = (i + 1).ToString();
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.BackColor = Color.White;
                tableLayoutPanel1.Controls.Add(lbl);
                tableLayoutPanel1.SetRow(lbl, 2);
                tableLayoutPanel1.SetColumn(lbl, i + 2);
                tableLayoutPanel1.SetColumnSpan(lbl, 2);
            }*/

        }

        void cb_CheckedChanged(object sender, EventArgs e)
        {
            String[] str = ((CheckBox)sender).Name.Split('-');
            int[] endRowCol = { int.Parse(str[1]), int.Parse(str[2]) };

            if (ds == null)
            {
                if (((CheckBox)sender).Checked)
                {
                    MessageBox.Show("First load the data for an employee by clicking on the Load Button at top right.");
                    ((CheckBox)sender).Checked = false;
                }
            }
            else
            {
                if (((CheckBox)sender).Checked)
                {
                    ds.Tables["tbltransaction"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 1;

                }
                else
                {
                    ds.Tables["tbltransaction"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 0;
                    ds.Tables["tblviolation"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 0;
                    ((CheckBox)sender).BackColor = Color.White;
                }

            }

        }

        private void CheckViolation(Control sender)
        {
            String[] str = ((CheckBox)sender).Name.Split('-');
            Boolean IsViolation = false;
            int[] endRowCol = { int.Parse(str[1]), int.Parse(str[2]) };
            int[] startRowColOneDay = StartRowCol(48, endRowCol[0], endRowCol[1]);//For Violation 1 to 4
            int[] startRowColSevenDays = StartRowCol(336, endRowCol[0], endRowCol[1]);//For violation 5 and 6
            int[] startRowColThreeDays = StartRowCol(144, endRowCol[0], endRowCol[1]);//For violation 7
            if (((CheckBox)sender).Checked)
            {
                if (violationObject.CheckForViolation(7, FetchHourDetails(startRowColThreeDays, endRowCol)) == 1)
                {
                    ds.Tables["tblviolation"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 7;
                    ((CheckBox)sender).BackColor = Color.Red;
                    IsViolation = true;
                }
                else
                {
                    IsViolation = false;
                }
                if (violationObject.CheckForViolation(6, FetchHourDetails(startRowColSevenDays, endRowCol)) == 1)
                {
                    ds.Tables["tblviolation"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 6;
                    ((CheckBox)sender).BackColor = Color.Red;
                    IsViolation = true;
                }
                else
                {
                    IsViolation = false;
                }
                if (violationObject.CheckForViolation(5, FetchHourDetails(startRowColSevenDays, endRowCol)) == 1)
                {
                    ds.Tables["tblviolation"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 5;
                    ((CheckBox)sender).BackColor = Color.Red;
                    IsViolation = true;
                }
                else
                {
                    IsViolation = false;
                }

                if (violationObject.CheckForViolation(1, FetchHourDetails(startRowColOneDay, endRowCol)) == 1)
                {
                    ds.Tables["tblviolation"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 1;
                    ((CheckBox)sender).BackColor = Color.Red;
                    IsViolation = true;
                }
                else if (violationObject.CheckForViolation(2, FetchHourDetails(startRowColOneDay, endRowCol)) == 1)
                {
                    ds.Tables["tblviolation"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 2;
                    ((CheckBox)sender).BackColor = Color.Red;
                    IsViolation = true;
                }
                else if (violationObject.CheckForViolation(3, FetchHourDetails(startRowColOneDay, endRowCol)) == 1)
                {
                    ds.Tables["tblviolation"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 3;
                    ((CheckBox)sender).BackColor = Color.Yellow;
                    IsViolation = true;
                }
                else if (violationObject.CheckForViolation(4, FetchHourDetails(startRowColOneDay, endRowCol)) == 2)
                {
                    ds.Tables["tblviolation"].Rows[endRowCol[0] - 1][endRowCol[1] - 1] = 4;
                    ((CheckBox)sender).BackColor = Color.Red;
                    IsViolation = true;
                }                                   
                else
                {
                    IsViolation = false;
                }

                if (!IsViolation)
                {
                    ((CheckBox)sender).BackColor = Color.Green;
                }
            }
        }

        private String FetchHourDetails(int[] start, int[] end)
        {
            String strHourDetails = "";
            int flag = 0;
            for (int i = start[0]; i <= end[0]; i++)
            {
                if (i <= 0)
                {
                    if (flag == 0)
                    {
                        if (ds.Tables["tblLastSevenTrans"].Rows.Count > 0)
                        {
                            for (int j = start[1]; j <= 48; j++)
                            {

                                strHourDetails += ds.Tables["tblLastSevenTrans"].Rows[i + 6][j - 1].ToString();
                            }
                            flag = 1;
                        }
                        else
                        {
                            for (int j = start[1]; j <= 48; j++)
                            {

                                strHourDetails += "0";
                            }
                            flag = 1;
                        }
                    }
                    else
                    {
                        if (ds.Tables["tblLastSevenTrans"].Rows.Count > 0)
                        {
                            for (int j = 1; j <= 48; j++)
                            {
                                strHourDetails += ds.Tables["tblLastSevenTrans"].Rows[i + 6][j - 1].ToString();
                            }
                        }
                        else
                        {
                            for (int j = 1; j <= 48; j++)
                            {
                                strHourDetails += "0";
                            }
                        }
                    }

                }
                else
                {
                    if (i < end[0] && flag == 0)
                    {
                        for (int j = start[1]; j <= 48; j++)
                        {

                            strHourDetails += ds.Tables["tbltransaction"].Rows[i - 1][j - 1].ToString();

                        }
                        flag = 1;
                    }
                    else if (i == end[0])
                    {
                        for (int j = 1; j <= end[1]; j++)
                        {

                            strHourDetails += ds.Tables["tbltransaction"].Rows[i - 1][j - 1].ToString();

                        }
                    }
                    else
                    {
                        for (int j = 1; j <= 48; j++)
                        {
                            strHourDetails += ds.Tables["tbltransaction"].Rows[i - 1][j - 1].ToString();
                        }
                    }
                }
            }
            return strHourDetails;
        }
        private int[] StartRowCol(int hour, int curRow, int curCol)
        {
            int[] startRowCol = { 1, 1 };
            if ((curCol - hour) < 0)
            {
                if (hour == 48) // For one day period
                {
                    startRowCol[0] = curRow - 1;
                    startRowCol[1] = curCol + 1;
                }
                else if (hour == 336) //For seven days period
                {
                    if (((float)curCol % 48) == 0.0) //Last column or 24th Hour of a day
                    {
                        startRowCol[0] = curRow - 6;
                        startRowCol[1] = 1;
                    }
                    else //Mid of a day
                    {
                        startRowCol[0] = curRow - 7;
                        startRowCol[1] = curCol + 1;
                    }
                }
                else if (hour == 144) //For three days period
                {
                    if (((float)curCol % 48) == 0.0) //Last column or 24th Hour of a day
                    {
                        startRowCol[0] = curRow - 2;
                        startRowCol[1] = 1;
                    }
                    else//Mid of a day
                    {
                        startRowCol[0] = curRow - 3;
                        startRowCol[1] = curCol + 1;
                    }
                }

            }
            else if ((curCol - hour) == 0)//Last column or 24th hour of a day for violation 1 to 4
            {
                startRowCol[0] = curRow;
                startRowCol[1] = 1;
            }

            return startRowCol;
        }



        private void btnProceed_Click(object sender, EventArgs e)
        {
            tabCtrlMain.SelectedTab = tabPgTrans;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text.Equals(""))
            {
                MessageBox.Show("Enter Employee ID to search");
            }
            else
            {
                LoadUserDetails(txtEmpId.Text);
                UpdateDateDayLabels();

                if (LoadHourDetails())
                {
                    ViolationCheck();
                    MessageBox.Show("Employee Rest Hour Details Loaded Successfully.");
                }
                else
                {
                    MessageBox.Show("Error in loading Employee Rest Hour Details. Please check the Employee Id entered.");
                }
            }
        }

        private Boolean LoadHourDetails()
        {
            int start = 1;
            int end = 1;
            Control[] c;
            Boolean status = false;
            if (txtEmpId.Text.Equals(""))
            {
                MessageBox.Show("Enter Employee Id");
            }
            else
            {
                try
                {
                    ResetCheckboxes();
                    ds = dbAccessLayer.GetTransaction(txtEmpId.Text, cmbMonth.SelectedIndex + 1, cmbYear.SelectedItem.ToString());
                    if (ds == null)
                    {
                        ds .Tables .Add ( violationObject.CreateDummyTransTable("tbltransaction"));
                        ds.Tables.Add(violationObject.CreateDummyTransTable("tblLastSevenTrans"));
                    }
                    if (ds.Tables["tbltransaction"].Rows.Count <= 0)
                    {
                        ds.Tables .Remove ("tbltransaction");
                        ds.Tables.Add(violationObject.CreateDummyTransTable("tbltransaction"));
                    }
                    if (ds.Tables["tblLastSevenTrans"].Rows.Count <= 0)
                    {
                        ds.Tables.Remove("tblLastSevenTrans");
                        ds.Tables.Add(violationObject.CreateDummyTransTable("tblLastSevenTrans"));
                    }
                    DataTable tempViolationTable = ds.Tables["tbltransaction"].Copy();
                    tempViolationTable.TableName = "tblviolation";
                    foreach (DataRow dr in tempViolationTable.Rows)
                    {
                        foreach (DataColumn dc in tempViolationTable.Columns)
                        {
                            dr[dc] = "0";
                        }

                    }
                    ds.Tables.Add(tempViolationTable);


                    foreach (DataRow dr in ds.Tables["tbltransaction"].Rows)
                    {
                        foreach (DataColumn dc in ds.Tables["tbltransaction"].Columns)
                        {
                            if (!dc.ColumnName.Equals("TransNo") && !dc.ColumnName.Equals("EmpNo") && !dc.ColumnName.Equals("TransDate"))
                            {
                                if (dr[dc].ToString().Equals("1") && start <=31)
                                {
                                    c = this.Controls.Find("DynCheckBox-" + start.ToString() + "-" + end.ToString(), true);
                                    
                                    CheckBox cb = (CheckBox)c[0];
                                    cb.Checked = true;
                                }

                                end++;
                            }

                        }
                        end = 1;
                        start++;
                    }
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                }

            }
            return status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean status = false;
            String strTransHours = String.Empty;
            String strViolation = String.Empty;
            int date = 1;
            int i=1;
            String strLast24Hrs = String .Empty ;
            DateTime dt1 = new DateTime(Int32.Parse(cmbYear.SelectedItem.ToString()), cmbMonth.SelectedIndex + 1, date);
            DateTime dt2 = new DateTime(Int32.Parse(cmbYear.SelectedItem.ToString()), cmbMonth.SelectedIndex + 1, date);
            ViolationCheck();
            if (ds != null)
            {
                if (ds.Tables["tbltransaction"].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables["tbltransaction"].Rows)
                    {
                        strTransHours = "";
                        foreach (DataColumn dc in ds.Tables["tbltransaction"].Columns)
                        {
                            strTransHours += dr[dc].ToString();
                        }
                        Control[] c = (Controls.Find ("txtRemarkDay"+i.ToString (),true ));
                        Control[] c1 = (Controls.Find("txtTotalRestDay" + (i+1).ToString(), true));                        
                        strLast24Hrs = CalculateLast24HrRest (i).ToString ();
                        if (c1.Length > 0)
                        {
                            ((TextBox)c1[0]).Text = strLast24Hrs;
                        }
                        if (dbAccessLayer.SetTransaction(txtEmpId.Text, dt1, strTransHours,strLast24Hrs  ,(c.Length >0)?((TextBox)c[0]).Text:"","","",""))
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                            break;
                        }
                        dt1 = dt1.AddDays(1);
                        i++;
                    }
                }

                if (ds.Tables["tblviolation"].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables["tblviolation"].Rows)
                    {
                        strViolation = "";
                        foreach (DataColumn dc in ds.Tables["tblviolation"].Columns)
                        {
                            strViolation += dr[dc].ToString();
                        }
                        if (dbAccessLayer.SetViolation(txtEmpId.Text, dt2, strViolation))
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                            break;
                        }

                        dt2 = dt2.AddDays(1);
                    }
                }
            }
            if (status)
            {
                MessageBox.Show("Employee Rest Hour Details Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {

            txtShipName.Text = "";
            txtRank.Text = "";
            txtName.Text = "";
            //txtEmpId.Text = "";
            cmbMonth.SelectedIndex = DateTime.Today.Month - 1;
            cmbYear.SelectedItem = DateTime.Today.Year.ToString();

            ResetCheckboxes();



            MessageBox.Show("Fields Cleared.");

        }

        /// <summary>
        /// Resetting Dynamic Checkboxes
        /// </summary>
        private void ResetCheckboxes()
        {
            Control[] c;

            //Resetting Transaction Dataset
            
            if (ds != null)
            {
                for (int i = 1; i <= DateTime.DaysInMonth(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1) + 1; i++)
                {
                    for (int j = 1; j <= 48; j++)
                    {
                        c = this.Controls.Find("DynCheckBox-" + i.ToString() + "-" + j.ToString(), true);
                        if (c.Count() != 0)
                        {
                            CheckBox cb = (CheckBox)c[0];
                            if (ROLE.Equals("Emp"))
                            {
                                if ((cmbMonth.SelectedIndex + 1 > DateTime.Today.Month || cmbMonth.SelectedIndex + 1 < DateTime.Today.Month) || ((cmbMonth.SelectedIndex + 1 == DateTime.Today.Month) && (i > DateTime.Today.Day || i < DateTime.Today.Day)))
                                {
                                    cb.Enabled = false;
                                }
                                else
                                {
                                    cb.Enabled = true;
                                }
                            }


                            cb.Checked = false;
                        }
                    }

                }

                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        ds.Tables.RemoveAt(0);
                    }
                }
                ds = null;
            }
        }

        private void btnCheckViolation_Click(object sender, EventArgs e)
        {
            ViolationCheck();
        }

        private void ViolationCheck()
        {
            Control[] c;
            if (ds != null)
            {
                for (int i = 1; i <= DateTime.DaysInMonth(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1) + 1; i++)
                {
                    for (int j = 1; j <= 48; j++)
                    {
                        c = this.Controls.Find("DynCheckBox-" + i.ToString() + "-" + j.ToString(), true);
                        if (c.Count() != 0)
                        {
                            CheckViolation(c[0]);
                        }
                    }

                }
            }
        }


        /// <summary>
        /// To Verify the contract period of an employee
        /// </summary>
        /// <param name="dtTodayDate"></param>
        /// <returns></returns>
        private Boolean VerifyContractPeriod()
        {
            Boolean status = false;
            DateTime[] dtContractPeriod = dbAccessLayer.GetContractPeriod(USERID);
            if (dtContractPeriod != null)
            {
                if (DateTime .Today  < dtContractPeriod[0] || DateTime .Today  > dtContractPeriod[1])
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
            }
            else 
            {
                status = false;
            }
            return status;

        }

        private void tableLayoutPanel1_MouseHover(object sender, EventArgs e)
        {
            //if (((TableLayoutPanel )  sender).cell
                
        }

        private void UpdateDateDayLabels()
        {
            Control[] c;
            for (int i = 1; i <= 31; i++)
            {
                    
                c = this.Controls.Find("DynLabelDay" + i.ToString(), true);
                if (c.Count() != 0)
                {
                    try
                    {
                        ((Label)c[0]).Text = new DateTime(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1, i).DayOfWeek.ToString("G").Substring(0, 3);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        ((Label)c[0]).Text = "";
                        if (i > DateTime.DaysInMonth(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1))
                        {
                            ((Label)c[0]).Visible = false;
                        }
                        else
                        {
                            ((Label)c[0]).Visible = true;
                        }
                        continue;
                    }
                    if (i > DateTime.DaysInMonth(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1))
                    {
                        ((Label)c[0]).Visible = false;
                    }
                    else
                    {
                        ((Label)c[0]).Visible = true;
                    }
                }
            }
                for (int i = 1; i <= 31; i++)
                {
                    c = this.Controls.Find("DynLabelDate" + (i).ToString(), true);
                    if (c.Count() != 0)
                    {
                        if (i > DateTime.DaysInMonth(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1))
                        {
                            ((Label)c[0]).Visible = false;
                        }
                        else
                        {
                            ((Label)c[0]).Visible = true;
                        }
                    }
                }

                for (int i = 1; i <= 31; i++)
                {
                    for (int j=1;j<=48;j++)
                    {
                    c = this.Controls.Find("DynCheckBox-" + (i).ToString() + "-" + (j).ToString(), true);
                    if (c.Count() != 0)
                    {
                        if (i > DateTime.DaysInMonth(cmbYear.SelectedIndex + 1990, cmbMonth.SelectedIndex + 1))
                        {
                            ((CheckBox)c[0]).Visible = false;
                        }
                        else
                        {
                            ((CheckBox )c[0]).Visible = true;
                        }
                    }
                    }
                }
            
       }


        private DataRow GetEmployeeDetails(String strUserId)
        {
            DataTable dt = dbAccessLayer.RetrieveTable("tblempmaster", new String[] { "EmpNo" }, new String[] { strUserId  });
            if (dt .Rows .Count >0)
            {
                DataRow drEmployeeDetails = dt.NewRow();
                drEmployeeDetails["EmpNo"] = dt.Rows[0]["EmpNo"].ToString();
                drEmployeeDetails["EmpName"] = dt.Rows[0]["EmpName"].ToString();
                DataTable dt1 = dbAccessLayer.RetrieveTable("tblshipmaster", new String[] { "ShipNo" }, new String[] {dt .Rows [0]["EmpShip"] .ToString ()});
                if (dt1.Rows.Count > 0)
                {
                    drEmployeeDetails["EmpShip"] = dt1.Rows[0]["ShipName"].ToString();
                }
                else
                {
                    drEmployeeDetails["EmpShip"] = "";
                }
                return drEmployeeDetails;
            }
            else 
            {
                return null;
            }

        }

        private void LoadUserDetails(String strUserId)
        {
            DataRow drEmployeeDetails = GetEmployeeDetails(strUserId);
            if (drEmployeeDetails != null)
            {
                txtEmpId.Text = drEmployeeDetails["EmpNo"].ToString();
                txtName.Text = drEmployeeDetails["EmpName"].ToString();
                txtShipName.Text = drEmployeeDetails["EmpShip"].ToString();
            }
            else
            {
                MessageBox.Show("User Details not found");
            }
        }

        private Double  CalculateLast24HrRest(int day)
        {
            Double fTotalRest =0.0;
            for (int i = 0; i < 48; i++)
            {
                if (ds.Tables["tbltransaction"].Rows[day-1][i].ToString().Equals("0"))
                {
                    fTotalRest += 0.5;
                }
            }
            return fTotalRest;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmViolationRep objViolationRep = new frmViolationRep();
            objViolationRep.Show();
        }

        private void btnExitTrans_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnStandardEntry_Click(object sender, EventArgs e)
        {
            Control[] chkStdEntry,chkDyn;
            int iRow = DateTime.Today.Day;
            for (int i = 1; i <= 48; i++)
            {
                chkStdEntry = Controls.Find("chkStdEntry"+i.ToString (), true);
                chkDyn = Controls.Find("DynCheckBox-"+iRow .ToString ()+"-"+i.ToString (),true );
                if (chkStdEntry.Count() != 0 && chkDyn .Count () != 0)
                {
                    if (((CheckBox)chkStdEntry[0]).Checked)
                    {
                        
                        ((CheckBox)chkDyn[0]).Checked = true;
                    }
                    else
                    {
                        ((CheckBox)chkDyn[0]).Checked = false;
                    }

                }
            }
        }

        private void tabPgTrans_Click(object sender, EventArgs e)
        {

        }

        private void tableStandardEntry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblStdEntry24_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry23_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry22_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry21_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry20_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry19_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry18_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry17_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry16_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry15_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry14_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry13_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry12_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry11_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry10_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry9_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry8_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry7_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry6_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry5_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry4_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry3_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry2_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntry1_Click(object sender, EventArgs e)
        {

        }

        private void lblStdEntryRemarks_Click(object sender, EventArgs e)
        {

        }

        private void txtStdEntryRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry20_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry22_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry23_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry24_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry25_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry26_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry27_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry28_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry29_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry30_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry31_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry32_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry33_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry34_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry35_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry36_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry37_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry38_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry39_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry40_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry41_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry42_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry43_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry44_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry45_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry46_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry47_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStdEntry48_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblStandardEntry_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveTrans_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblWorkhrs_Click(object sender, EventArgs e)
        {

        }

        private void lblDay_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblSign_Click(object sender, EventArgs e)
        {

        }

        private void lblHrsOfRest_Click(object sender, EventArgs e)
        {

        }

        private void lblRemarks_Click(object sender, EventArgs e)
        {

        }

        private void lblMinimumRest_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay8_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay9_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay10_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay11_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay12_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay13_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay14_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay15_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay16_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay17_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay19_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay18_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay20_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay21_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay22_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay23_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay24_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay25_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay26_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay27_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay30_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay29_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay28_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarkDay31_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay8_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay9_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay10_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay11_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay12_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay13_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay14_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay15_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay16_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay17_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay18_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay19_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay20_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay21_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay22_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay23_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay24_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay25_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay26_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay27_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay28_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay29_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay30_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay31_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalRestDay32_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtShipName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblYear_Click(object sender, EventArgs e)
        {

        }

        private void lblMonth_Click(object sender, EventArgs e)
        {

        }

        private void lblShipName_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmpId_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmpId_Click(object sender, EventArgs e)
        {

        }

        private void txtRank_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblRank_Click(object sender, EventArgs e)
        {

        }

        private void tabPgCal_Click(object sender, EventArgs e)
        {

        }

        private void clndrMain_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void tabCtrlMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    
}
