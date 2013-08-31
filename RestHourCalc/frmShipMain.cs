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
    public partial class frmShipMain : Form
    {
        DBAccessLayer objDBAccess = new DBAccessLayer();
        String strUserRole = string.Empty;
        public string strUsrName { get; set; }
        public frmShipMain(String strUserName,String strRole)
        {
            InitializeComponent();
            strUsrName = strUserName;
            strUserRole = strRole;
            if (strUserRole.Equals("Emp"))
            {
                shipToolStripMenuItem.Enabled = false;
                reportToolStripMenuItem.Enabled = false;
            }
            else
            {
                shipToolStripMenuItem.Enabled = true ;
                reportToolStripMenuItem.Enabled = true ;
            }
        }
        
               
        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment objFrmDept = new frmDepartment();
            objFrmDept.Show();
        }

        private void fleetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFleet objFrmFleet = new frmFleet();
            objFrmFleet.Show();
        }

        private void shipTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShipType objFrmShiptype = new frmShipType();
            objFrmShiptype.Show();
        }

        private void employeeTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpType objFrmEmpType = new frmEmpType();
            objFrmEmpType.Show();
        }

        private void exitShipManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ShipMasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShipMaster objFrmShipMaster = new frmShipMaster();
            objFrmShipMaster.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpMaster objFrmEmpMaster = new frmEmpMaster();
            objFrmEmpMaster.Show();
        }

        private void workingHoursEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRestHourManager objFrmRHM = new frmRestHourManager(strUsrName,strUserRole );
            if (!objFrmRHM.IsDisposed)
            {
                objFrmRHM.Show();
            }
        }

        
        public void AccessControl()
        {
            if (objDBAccess.AuthenticateUser(strUsrName, strPswd) == "Emp")
            {
                shipToolStripMenuItem.Enabled = false;
                reportToolStripMenuItem.Enabled = false;
            }
        }
        public string strPswd { get; set; }

        private void violationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViolationRep objViolationRep = new frmViolationRep();
            objViolationRep.Show();
        }
    }
}
