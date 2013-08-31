using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestHourCalc
{
    class RestHourViolation
    {


        public DataTable  CreateDummyTransTable(String strTableName)
        {
           
            DataTable dt = new DataTable(strTableName );
            //DataTable dt2 = new DataTable("tblLastSevenTrans");
            
                for (int j = 1; j <= 48; j++)
                {
                    DataColumn dc = new DataColumn("Hour" + (j).ToString(), Type.GetType("System.Byte"));
                    dt.Columns.Add(dc);
                    

                }
                if (strTableName.Equals("tbltransaction"))
                {
                    for (int i = 0; i < 31; i++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 1; j <= 48; j++)
                        {
                            dr["Hour" + (j).ToString()] = 0;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                else
                {

                    for (int i = 0; i < 7; i++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 1; j <= 48; j++)
                        {
                            dr["Hour" + (j).ToString()] = 0;
                        }
                        dt.Rows.Add(dr);
                    }
                }
            return dt;
        }

        

        public int CheckForViolation(int violationNumber, String strHourDetail)
        {
            int violation = 0;
            switch (violationNumber)
            {
                case 1:
                    violation = CheckForViolation1(strHourDetail);
                    break;
                case 2:
                    violation = CheckForViolation2(strHourDetail);
                    break;
                case 3:
                case 4:
                    violation = CheckForViolation3and4(strHourDetail);
                    break;
                case 5:
                    violation = CheckForViolation5(strHourDetail);
                    break;
                case 6:
                    violation = CheckForViolation6(strHourDetail);
                    break;
                case 7:
                    violation = CheckForViolation7(strHourDetail);
                    break;
            }
            return violation;

        }
        private int CheckForViolation1(String strHourDetails)
        {
            int indexOfRest = 0;
            int indexOfWork = 0;
            Boolean boolViolationFlag = false;
            while (indexOfRest != -1 || indexOfWork != -1)
            {
                indexOfRest = strHourDetails.IndexOf('0', indexOfWork);
                if (indexOfRest != -1)
                {
                    indexOfWork = strHourDetails.IndexOf('1', indexOfRest);
                    if (indexOfWork != -1)
                    {
                        if ((indexOfWork - indexOfRest) < 12)
                        {
                            boolViolationFlag = true;
                        }
                        else
                        {
                            boolViolationFlag = false;
                            break;
                        }
                    }
                    else
                    {
                        if ((strHourDetails.Length - indexOfRest) < 12)
                        {
                            boolViolationFlag = true;
                        }
                        else
                        {
                            boolViolationFlag = false;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }

            }


            if (boolViolationFlag)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        private int CheckForViolation2(String strHourDetails)
        {
            char[] chrHourDetails = strHourDetails.ToCharArray();
            int countOfRest = 0;
            for (int i = 0; i < chrHourDetails.Length; i++)
            {
                if (chrHourDetails[i] == '0')
                {
                    countOfRest++;
                }
            }

            if (countOfRest < 20)
            {
                return 1;
            }

            return 0;
        }


        private int CheckForViolation3and4(String strHourDetails)
        {
            int indexOfRest = 0;
            int indexOfWork = 0;
            int countOfRestSequence = 0;
            while (indexOfRest != -1 && indexOfWork != -1)
            {
                indexOfRest = strHourDetails.IndexOf('0', indexOfWork);
                if (indexOfRest != -1)
                {
                    countOfRestSequence++;
                    indexOfWork = strHourDetails.IndexOf('1', indexOfRest);
                }
            }

            if (countOfRestSequence == 3)
            {
                return 1;
            }
            else if (countOfRestSequence > 3)
            {
                return 2;
            }

            return 0;
        }

        private int CheckForViolation5(String strHourDetails)
        {
            char[] chrHourDetails = strHourDetails.ToCharArray();
            int countOfRest = 0;
            for (int i = 0; i < chrHourDetails.Length; i++)
            {
                if (chrHourDetails[i] == '0')
                {
                    countOfRest++;
                }
            }

            if (countOfRest < 154)
            {
                return 1;
            }

            return 0;
        }

        private int CheckForViolation6(String strHourDetails)
        {
            char[] chrHourDetails = strHourDetails.ToCharArray();
            int countOfRest = 0;
            for (int i = 0; i < chrHourDetails.Length; i++)
            {
                if (chrHourDetails[i] == '0')
                {
                    countOfRest++;
                }
            }

            if (countOfRest < 140)
            {
                return 1;
            }

            return 0;
        }

        private int CheckForViolation7(String strHourDetails)
        {
            char[] chrHourDetails = strHourDetails.ToCharArray();
            int countOfRest = 0;
            for (int i = 0; i < chrHourDetails.Length; i++)
            {
                if (chrHourDetails[i] == '0')
                {
                    countOfRest++;
                }
            }

            if (countOfRest < 72)
            {
                return 1;
            }

            return 0;
        }




    }
}
