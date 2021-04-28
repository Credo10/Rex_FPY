using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.Linq;
using System.Linq;
using HRLData;
using Encryption;

namespace FPY
{
    public class clsDAL
    {

        //Server=fnimssp02;Database=HRL;UID=credouser;PWD=CSoft01;MultipleActiveResultSets=True
        private const string DATABASE_CONNECT = "XDcbXgz9OydD53I9vRpurSklRmt6y9DeBolmQ5X6acOmA+Fr10CvjXsECU6cDqtULrbjI0ciMAm6KFeIJRLNmTTt0FE8/7beITzaXY2/NCG+SKY3F1PRyw==";
        //Server=fnimssp02;Database=ECR;UID=credouser;PWD=CSoft01;MultipleActiveResultSets=True
        private const string ECR_CONNECT = "XDcbXgz9OydD53I9vRpurSklRmt6y9De6GvWFTtRfk0t4Yi82/4C+9k5n3enZC362psHJ4JJBSawKNPR6I8ESt8N8GF7dScLnx6vzPpJSwX3b0WZ00EyYQ==";
        //Server=fnimssp02;Database=Rexroth;UID=credouser;PWD=CSoft01;MultipleActiveResultSets=True
        private const string REXROTH_CONNECT = "XDcbXgz9OydD53I9vRpurSklRmt6y9DeKGGT7tSrWk47l5nA26Di7r9cxrGKV84CFG+w3rWiGwMmRCrI7ddUFlEk4RyjtuH7L18rqD6nMcnlU/dKhcpvDQGEyzcjWwxV";
        //Server=fnimssp02;Database=Visual;UID=credouser;PWD=CSoft01;MultipleActiveResultSets=True
        private const string VISUAL_CONNECT = "XDcbXgz9OydD53I9vRpurSklRmt6y9DeUQ1xIiLEPLuMKIAe/ZYGU24yABXzs3c+b4X+q/NB5ratg+joHiQhZvmlpvGPVc/SMbrwhphMX+AiLK0cgz8iN0JYPLlBrycS";
        //private const string DATABASE_CONNECT = @"Server=10.225.43.59,56482;Database=BPS;UID=kcurnow;PWD=kcurnow;MultipleActiveResultSets=True";
        private const string BPS_CONNECT = "t/leDArYJt3cG6xdZRp3QHHUBgrmA4fSIiY+iemisBXl88D1xSKmL2+Z4/Uiq2cUJvaYTphC58hNe7OmDtMgXU06PtZRT4Xmq3TCUSqhRrbTkaXNEV1frxI2cB417mle";

        public static string GetCon(String strCons)
        {
            string connectionString;
            switch (strCons)
            {
                case "BPS":
                    connectionString = clsEncrypt.Decrypt(BPS_CONNECT);
                    break;
                case "ECR":
                    connectionString = clsEncrypt.Decrypt(ECR_CONNECT);
                    break;
                case "HRL":
                    connectionString = clsEncrypt.Decrypt(DATABASE_CONNECT);
                    break;
                case "Rexroth":
                    connectionString = clsEncrypt.Decrypt(REXROTH_CONNECT);
                    break;
                case "Visual":
                    connectionString = clsEncrypt.Decrypt(VISUAL_CONNECT);
                    break;
                default:
                    connectionString = clsEncrypt.Decrypt(DATABASE_CONNECT);
                    break;
            }
            return connectionString;
        }

        //public List<dynamic> Load(string strTable, int pk)
        //{
        //    HRLEntities db = clsStart.efdb();



        //    List() table = (ITable)db.GetType()
        //                   .GetProperty(strTable)
        //                   .GetValue(db, null);
        //}


        public static bool dsHasData(DataSet ds)
        {
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }


        public static DataSet ProcessSQL(string strSQL, string strCon)
        {
            Debug.WriteLine(strSQL);
            SqlConnection databaseConnection = null;
            SqlCommand databaseCommand = null;
            DataSet resultDataSet = null;
            SqlDataAdapter resultAdapter = null;

            // Retrieve database objects (Command and Connection).
            databaseConnection = GetDatabaseObjects(ref databaseCommand, GetCon(strCon), strSQL);

            try
            {
                // Execute procedure and populate DataSet.
                resultDataSet = new DataSet();
                resultAdapter = new SqlDataAdapter(databaseCommand);
                resultAdapter.Fill(resultDataSet);
            }
            catch (Exception ErrorObject)
            {
                // Error executing procedure (log message here if desired).
                //MessageBox.Show(ErrorObject.Message, "Process Data");
                //throw ErrorObject;

                //string strSQL = "INSERT INTO tblErrorLog(ER_Message) SELECT '" + ErrorObject.Message.ToString + "'";
                //ExecuteSQL(strSQL);
            }
            finally
            {
                if ((databaseConnection.State & ConnectionState.Open) == ConnectionState.Open)
                {
                    // Cleanup database connection
                    databaseConnection.Close();
                    databaseConnection.Dispose();
                }

                // Release instance handles
                databaseCommand = null;
                databaseConnection = null;
            }

            return (resultDataSet);
        }

        public static DataSet GetAccessData(string strSQL, string strConPre)
        {


            DataSet ds = new DataSet();

            string strCon = clsUtility.ConnectionVal(strConPre);

            try
            {
                using (var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strCon))
                using (var comm = conn.CreateCommand())
                {

                    comm.CommandText = strSQL;
                    comm.CommandType = CommandType.Text;
                    conn.Open();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(comm))
                    {
                        adapter.Fill(ds);
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text);

            }

            return ds;
        }

        public static bool ExecuteSQL(string strSQL, string strCon)
        {
            SqlConnection databaseConnection = null;
            SqlCommand databaseCommand = null;

            // Retrieve database objects (Command and Connection).
            databaseConnection = GetDatabaseObjects(ref databaseCommand, GetCon(strCon), strSQL);

            try
            {
                // Execute procedure and populate DataSet.
                databaseCommand.ExecuteScalar();
            }
            catch (Exception ErrorObject)
            {
                // Error executing procedure (log message here if desired).
                //MessageBox.Show(ErrorObject.Message, "Credo");
                //throw ErrorObject;
            }
            finally
            {
                if ((databaseConnection.State & ConnectionState.Open) == ConnectionState.Open)
                {
                    // Cleanup database connection
                    databaseConnection.Close();
                    databaseConnection.Dispose();
                }

                // Release instance handles
                databaseCommand = null;
                databaseConnection = null;
            }

            return true;
        }

        public bool ExecuteScalarSQL(string strSQL, string strCon)
        {
            SqlConnection databaseConnection = null;
            SqlCommand databaseCommand = null;
            object oVar;

            // Retrieve database objects (Command and Connection).
            databaseConnection = GetDatabaseObjects(ref databaseCommand, GetCon(strCon), strSQL);

            try
            {
                // Execute procedure and populate DataSet.
                oVar = databaseCommand.ExecuteScalar();
            }
            catch (Exception ErrorObject)
            {
                // Error executing procedure (log message here if desired).
                MessageBox.Show(ErrorObject.Message, "Credo");
                //throw ErrorObject;
            }
            finally
            {
                if ((databaseConnection.State & ConnectionState.Open) == ConnectionState.Open)
                {
                    // Cleanup database connection
                    databaseConnection.Close();
                    databaseConnection.Dispose();
                }

                // Release instance handles
                databaseCommand = null;
                databaseConnection = null;
            }

            return true;
        }

        private static SqlConnection GetDatabaseObjects(ref SqlCommand databaseCommand, string connectionString, string storedProcedureName)
        {
            // Create database connections
            SqlConnection databaseConnection = new SqlConnection(connectionString);

            // Initialize variables
            databaseCommand = null;

            try
            {
                // Open database
                databaseConnection.Open();

                // Prepare command object.
                databaseCommand = databaseConnection.CreateCommand();
                databaseCommand.CommandText = storedProcedureName;
                //databaseCommand.CommandType = CommandType.StoredProcedure;
                databaseCommand.CommandType = CommandType.Text;
                databaseCommand.CommandTimeout = 90;
            }
            catch (Exception ErrorObject)
            {
                // Failure to connect or create command object error (log error if desired)
                if ((databaseConnection.State & ConnectionState.Open) == ConnectionState.Open)
                {
                    // Cleanup database connection
                    databaseConnection.Close();
                    databaseConnection.Dispose();
                }

                // Release instance handles
                databaseCommand = null;
                databaseConnection = null;

                // Reraise error.
                MessageBox.Show(ErrorObject.Message, "Credo");
                //throw ErrorObject;
            }

            // Return the database connection object.
            return (databaseConnection);
        }

        private void CreateInputParameter(SqlCommand databaseCommand, string parameterName, SqlDbType parameterType, int parameterSize)
        {
            // Add parameter to the command object.
            if (parameterSize > 0)
            {
                databaseCommand.Parameters.Add(parameterName, parameterType, parameterSize);
            }
            else
            {
                databaseCommand.Parameters.Add(parameterName, parameterType);
            }

            // Set the value of the parameter.
            databaseCommand.Parameters[parameterName].Direction = ParameterDirection.Input;
        }

        private void CreateOutputParameter(SqlCommand databaseCommand, string parameterName, SqlDbType parameterType, int parameterSize)
        {
            // Add parameter to the command object.
            if (parameterSize > 0)
            {
                databaseCommand.Parameters.Add(parameterName, parameterType, parameterSize);
            }
            else
            {
                databaseCommand.Parameters.Add(parameterName, parameterType);
            }

            // Set the value of the parameter.
            databaseCommand.Parameters[parameterName].Direction = ParameterDirection.Output;
        }

    }
}
