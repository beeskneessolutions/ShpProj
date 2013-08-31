using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Globalization;


namespace RestHourCalc
{
    class DBAccessLayer
    {
        
        MySqlConnection mySqlConn;
        MySqlCommand mySqlComm;
        MySqlDataAdapter mySqlAdapterTrans, mySqlAdapterViolation;
        public DBAccessLayer()
        {
            mySqlConn = new MySqlConnection();
            mySqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["RestHourCalc.Properties.Settings.ShipRestCalc"].ConnectionString;
            mySqlComm = new MySqlCommand();
            mySqlComm.Connection = mySqlConn;
            mySqlAdapterTrans = new MySqlDataAdapter("", mySqlConn);
            mySqlAdapterViolation = new MySqlDataAdapter("", mySqlConn);
        }

        /// <summary>
        /// Retrieves a complete table
        /// </summary>
        /// <param name="strTableName">Table name</param>
        /// <returns></returns>
        public DataTable RetrieveTable(String strTableName)
        {
            DataTable dt = new DataTable();
            try
            {
                mySqlComm.CommandText = "select * from " + strTableName;
                mySqlAdapterTrans.SelectCommand = mySqlComm;
                mySqlAdapterTrans.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;

        }

        /// <summary>
        /// To retrieve values from table based on condition
        /// </summary>
        /// <param name="strTableName">Table from which data needs to be retrieved</param>
        /// <param name="strColumnName">List of column names</param>
        /// <param name="strValue">List of values. In the same order as column name</param>
        /// <returns>Data table</returns>
        public DataTable RetrieveTable(String strTableName, String[] strColumnName, String[] strValue)
        {
            DataTable dt = new DataTable();
            String command = "Select * from " + strTableName + " where ";
            for (int i = 0; i < strColumnName.Length; i++)
            {
                if (i == strColumnName.Length - 1)
                {
                    command += strColumnName[i] + "= '" + strValue[i] + "' ";
                }
                else
                {
                    command += strColumnName[i] + "= '" + strValue[i] + "' and ";
                }
            }
            try
            {
                mySqlComm.CommandType = CommandType.Text;
                mySqlComm.CommandText = command;
                mySqlAdapterTrans.SelectCommand = mySqlComm;
                mySqlAdapterTrans.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }


        public Boolean UpdateTable(String strTableName, String[] strColumnName, String[] strValue, String[] strCondColumn, String[] strCondValue)
        {
            Boolean status = false;
            String command = "Update " + strTableName + " set ";


            for (int i = 0; i < strColumnName.Length; i++)
            {
                if (i == strColumnName.Length - 1)
                {
                    command += strColumnName[i] + "= '" + strValue[i] + "' where ";
                }
                else
                {
                    command += strColumnName[i] + "= '" + strValue[i] + "', ";
                }
            }
            for (int i = 0; i < strCondColumn.Length; i++)
            {
                if (i == strCondColumn.Length - 1)
                {
                    command += strCondColumn[i] + "= '" + strCondValue[i] + "' ";
                }
                else
                {
                    command += strCondColumn[i] + "= '" + strCondValue[i] + "' and ";
                }
            }
            try
            {
                mySqlConn.Open();
                mySqlComm.CommandType = CommandType.Text;
                mySqlComm.CommandText = command;
                mySqlAdapterTrans.SelectCommand = mySqlComm;
                if (mySqlComm.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                mySqlConn.Close();
            }
            catch (Exception ex)
            {
                status = false;
                mySqlConn.Close();
            }

            return status;
        }



        public Boolean DeleteRow(String strTableName, String[] strColumnName, String[] strValue)
        {

            Boolean status = false;
            String command = "Delete from " + strTableName + " where ";


            for (int i = 0; i < strColumnName.Length; i++)
            {
                if (i == strColumnName.Length - 1)
                {
                    command += strColumnName[i] + "= '" + strValue[i] + "'";
                }
                else
                {
                    command += strColumnName[i] + "= '" + strValue[i] + "' and ";
                }
            }


            try
            {
                mySqlConn.Open();
                mySqlComm.CommandType = CommandType.Text;
                mySqlComm.CommandText = command;
                mySqlAdapterTrans.SelectCommand = mySqlComm;
                if (mySqlComm.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                mySqlConn.Close();
            }
            catch (Exception ex)
            {
                status = false;
                mySqlConn.Close();
            }

            return status;
        }
        /// <summary>
        /// Saves value to the mentioned Table
        /// </summary>
        /// <param name="strTableName">Target Table Name</param>
        /// <param name="values">Array of values to be stored. Number of values should be equal to number of columns in target table.</param>
        /// <returns></returns>
        public Boolean SaveToTable(String strTableName, String[] values)
        {
            Boolean status = false;
            try
            {
                mySqlConn.Open();
                mySqlComm.CommandText = "Insert into " + strTableName + " values(";
                for (int i = 0; i < values.Length; i++)
                {
                    if (i != values.Length - 1)
                    {
                        mySqlComm.CommandText += "@Value" + i.ToString() + ",";
                    }
                    else
                    {
                        mySqlComm.CommandText += "@Value" + i.ToString() + ")";
                    }
                    mySqlComm.Parameters.Add(new MySqlParameter("@Value" + i.ToString(), values[i]));
                }

                if (mySqlComm.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }


            }
            catch (Exception ex)
            {
                status = false;
                mySqlConn.Close();
            }
            finally
            {
                for (int i = 0; i < values.Length; i++)
                {
                    mySqlComm.Parameters.RemoveAt("@Value" + i.ToString());
                }
                mySqlConn.Close();
            }
            return status;
        }

        /// <summary>
        /// To retrieve the stored transaction details for a month
        /// </summary>
        /// <param name="strEmpId">Employee Id for which details needs to be fetched</param>
        /// <param name="iMonth">The Month for which transaction is needed</param>
        /// <param name="strYear">The year for which transaction is needed</param>
        /// <returns></returns>
        public DataSet GetTransaction(string strEmpId, int iMonth, string strYear)
        {
            DataSet dsTrans = new DataSet();
            String strStartYear = strYear;
            String strEndYear = strYear;
            int iEndMonth = iMonth + 1;
            if (iMonth == 12)
            {
                strEndYear = (Int16.Parse(strStartYear) + 1).ToString();
                iEndMonth = 1;
            }
            try
            {
                mySqlComm.CommandType = CommandType.Text;
                mySqlComm.CommandText = "select TransHour0_5,TransHour1_0,TransHour1_5,TransHour2_0,TransHour2_5,TransHour3_0,TransHour3_5,TransHour4_0,TransHour4_5,TransHour5_0,TransHour5_5,TransHour6_0,TransHour6_5,TransHour7_0,TransHour7_5,TransHour8_0,TransHour8_5,TransHour9_0,TransHour9_5,TransHour10_0,TransHour10_5,TransHour11_0,TransHour11_5,TransHour12_0,TransHour12_5,TransHour13_0,TransHour13_5,TransHour14_0,TransHour14_5,TransHour15_0,TransHour15_5,TransHour16_0,TransHour16_5,TransHour17_0,TransHour17_5,TransHour18_0,TransHour18_5,TransHour19_0,TransHour19_5,TransHour20_0,TransHour20_5,TransHour21_0,TransHour21_5,TransHour22_0,TransHour22_5,TransHour23_0,TransHour23_5,TransHour24_0 from tbltransaction where EmpNo = '" + strEmpId + "' and (TransDate between '" + strStartYear + "-" + iMonth.ToString() + "-01' and '" + strEndYear + "-" + iEndMonth.ToString() + "-01')";
                mySqlAdapterTrans.SelectCommand = mySqlComm;
                mySqlAdapterTrans.Fill(dsTrans, "tbltransaction");
                mySqlComm.CommandText = "select TransHour0_5,TransHour1_0,TransHour1_5,TransHour2_0,TransHour2_5,TransHour3_0,TransHour3_5,TransHour4_0,TransHour4_5,TransHour5_0,TransHour5_5,TransHour6_0,TransHour6_5,TransHour7_0,TransHour7_5,TransHour8_0,TransHour8_5,TransHour9_0,TransHour9_5,TransHour10_0,TransHour10_5,TransHour11_0,TransHour11_5,TransHour12_0,TransHour12_5,TransHour13_0,TransHour13_5,TransHour14_0,TransHour14_5,TransHour15_0,TransHour15_5,TransHour16_0,TransHour16_5,TransHour17_0,TransHour17_5,TransHour18_0,TransHour18_5,TransHour19_0,TransHour19_5,TransHour20_0,TransHour20_5,TransHour21_0,TransHour21_5,TransHour22_0,TransHour22_5,TransHour23_0,TransHour23_5,TransHour24_0 from tbltransaction where EmpNo = '" + strEmpId + "' and (TransDate between '" + strStartYear + "-" + (iMonth - 1).ToString() + "-25' and '" + strEndYear + "-" + (iMonth - 1).ToString() + "-31')";
                mySqlAdapterTrans.SelectCommand = mySqlComm;
                mySqlAdapterTrans.Fill(dsTrans, "tblLastSevenTrans");
            }
            catch (Exception ex)
            {
                dsTrans = null;
            }
            return dsTrans;
        }

        public DataSet GetViolation(string strEmpId, DateTime fromDate, DateTime toDate)
        {
            DataSet dsViolation = new DataSet();
            /*String strStartYear = strYear;
            String strEndYear = strYear;
            int iEndMonth = iMonth + 1;
            if (iMonth == 12)
            {
                strEndYear = (Int16.Parse(strStartYear) + 1).ToString();
                iEndMonth = 1;
            }*/
            try
            {
                mySqlComm.CommandType = CommandType.Text;
                mySqlComm.CommandText = "select TransHour0_5,TransHour1_0,TransHour1_5,TransHour2_0,TransHour2_5,TransHour3_0,TransHour3_5,TransHour4_0,TransHour4_5,TransHour5_0,TransHour5_5,TransHour6_0,TransHour6_5,TransHour7_0,TransHour7_5,TransHour8_0,TransHour8_5,TransHour9_0,TransHour9_5,TransHour10_0,TransHour10_5,TransHour11_0,TransHour11_5,TransHour12_0,TransHour12_5,TransHour13_0,TransHour13_5,TransHour14_0,TransHour14_5,TransHour15_0,TransHour15_5,TransHour16_0,TransHour16_5,TransHour17_0,TransHour17_5,TransHour18_0,TransHour18_5,TransHour19_0,TransHour19_5,TransHour20_0,TransHour20_5,TransHour21_0,TransHour21_5,TransHour22_0,TransHour22_5,TransHour23_0,TransHour23_5,TransHour24_0 from tblviolation where EmpNo = '" + strEmpId + "' and TransDate between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "'";
                mySqlAdapterViolation.SelectCommand = mySqlComm;
                mySqlAdapterViolation.Fill(dsViolation, "tblviolation");
            }
            catch (Exception ex)
            {
                dsViolation = null;
            }
            return dsViolation;
        }

        public Boolean SetTransaction(String strEmpId, DateTime date, String strTransHour,String strRest24Hrs, String strRemarks,String strChiefSign, String strLast24Hrs, String strLast72Hrs)
        {
            Boolean status = false;
            try
            {
                mySqlConn.Open();
                mySqlComm.CommandType = CommandType.StoredProcedure;
                mySqlComm.CommandText = "sp_tbltransaction_set";
                mySqlComm.Parameters.Add(new MySqlParameter("EmpNo", strEmpId));
                mySqlComm.Parameters.Add(new MySqlParameter("TransDate", date));
                mySqlComm.Parameters.Add(new MySqlParameter("TransHour", strTransHour));
                mySqlComm .Parameters .Add (new MySqlParameter ("TotalRest",strRest24Hrs ));
                mySqlComm .Parameters .Add (new MySqlParameter ("Remark",strRemarks));
                mySqlComm .Parameters .Add (new MySqlParameter ("ChiefSign",strChiefSign ));
                mySqlComm .Parameters .Add (new MySqlParameter ("Rest24Hr",strLast24Hrs  ));
                mySqlComm .Parameters .Add (new MySqlParameter ("Rest72Hr",strLast72Hrs ));
                if (mySqlComm.ExecuteNonQuery() > 0)
                {
                    status = true;
                }

            }

            catch (Exception ex)
            {
                status = false;
                mySqlConn.Close();
            }

            finally
            {
                mySqlComm.Parameters.RemoveAt("EmpNo");
                mySqlComm.Parameters.RemoveAt("TransDate");
                mySqlComm.Parameters.RemoveAt("TransHour");
                mySqlComm.Parameters.RemoveAt("TotalRest");
                mySqlComm.Parameters.RemoveAt("Remark");
                mySqlComm.Parameters.RemoveAt("ChiefSign");
                mySqlComm.Parameters.RemoveAt("Rest24Hr");
                mySqlComm.Parameters.RemoveAt("Rest72Hr");
                mySqlConn.Close();
            }

            return status;
        }


        public Boolean SetViolation(String strEmpId, DateTime date, String strViolation)
        {
            Boolean status = false;
            try
            {
                mySqlConn.Open();
                mySqlComm.CommandType = CommandType.StoredProcedure;
                mySqlComm.CommandText = "sp_tblviolation_set";
                mySqlComm.Parameters.Add(new MySqlParameter("EmpNo", strEmpId));
                mySqlComm.Parameters.Add(new MySqlParameter("TransDate", date));
                mySqlComm.Parameters.Add(new MySqlParameter("TransHour", strViolation));
                if (mySqlComm.ExecuteNonQuery() > 0)
                {
                    status = true;
                }

            }

            catch (Exception ex)
            {
                status = false;
                mySqlConn.Close();
            }

            finally
            {
                mySqlComm.Parameters.RemoveAt("EmpNo");
                mySqlComm.Parameters.RemoveAt("TransDate");
                mySqlComm.Parameters.RemoveAt("TransHour");
                mySqlConn.Close();
            }

            return status;
        }

        /// <summary>
        /// Check for a valid user name and password.
        /// </summary>
        /// <param name="strUserId">User Id</param>
        /// <param name="strPassword">Password</param>
        /// <returns>Returns the Role of the employee if Authentication passes else will return null.</returns>
        public String AuthenticateUser(String strUserId, String strPassword)
        {
            String strRole = String.Empty;
            DataTable dt = new DataTable();
            try
            {
                mySqlConn.Open();
                mySqlComm.CommandType = CommandType.Text;
                mySqlComm.CommandText = "Select * from tblsecurity where UserId = '" + strUserId + "' and Password = '" + strPassword + "'";
                mySqlAdapterTrans.SelectCommand = mySqlComm;
                mySqlAdapterTrans.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    strRole = dt.Rows[0]["Role"].ToString();
                }
                else
                {
                    strRole = null;
                }
            }

            catch (Exception ex)
            {
                strRole = null;
                mySqlConn.Close();
            }

            finally
            {
                mySqlConn.Close();
            }

            return strRole;
        }


        public DateTime[] GetContractPeriod(String strEmployeeId)
        {
            DateTime[] dtContractPeriod = {DateTime .Today,DateTime .Today }; 
            DataTable dtTemp = new DataTable();
            DateTime dt ;
           
            
            try
            {
                mySqlConn.Open();
                mySqlComm.CommandType = CommandType.Text;
                mySqlComm.CommandText = "Select * from tblempmaster where EmpNo = '" + strEmployeeId +"'";
                mySqlAdapterTrans.SelectCommand = mySqlComm;
                mySqlAdapterTrans.Fill(dtTemp);
                if (dtTemp.Rows.Count > 0)
                {
                    
                   // bool bformat=DateTime .TryParseExact (dtTemp .Rows [0]["EmpFrom"].ToString (),"ddMMyyyy",CultureInfo.InvariantCulture  ,System.Globalization.DateTimeStyles.None ,out dt );//DateTime .Parse ( dtTemp.Rows[0]["EmpFrom"].ToString());
                    dtContractPeriod[0] = DateTime.Parse(dtTemp.Rows[0]["EmpFrom"].ToString());
                    dtContractPeriod[1] = DateTime.Parse(dtTemp.Rows[0]["EmpTo"].ToString());
                   

                }
                else
                {
                    dtContractPeriod = null;
                }
            }
            catch (Exception ex)
            {
                mySqlConn.Close();
                dtContractPeriod = null;
            }
            finally
            {
                mySqlConn.Close();
            }

            return dtContractPeriod;


        }

        
    }
}
