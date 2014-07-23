using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace SQLConnector
{
    public class DBOperations
    {
        SqlConnection _objScon = null;
        string _strConnectionstring = string.Empty;
        public DBOperations(  string  strConnectionstring)
        {
            _objScon = new SqlConnection(strConnectionstring);
        }
        public void Openconnection()
        {
            if (_objScon == null)
            {
                _objScon = new SqlConnection(_strConnectionstring);
            }
            _objScon.Open();
        }
        public void Closeconnection()
        {
            if (_objScon != null)
            {
                _objScon.Close();
                _objScon.Dispose();
            }
        }
        public bool ExecuteQuery(string strQuery,string[] strArrParameterName,object[] objArrParameterValue)
        {
            bool blnVal = false;
            if (strArrParameterName.Length != objArrParameterValue.Length)
            {
                return false;
            }
            Openconnection();
            SqlCommand objScmd = new SqlCommand(strQuery,_objScon);
            for (int i = 0; i < strArrParameterName.Length; i++)
            {
                objScmd.Parameters.AddWithValue(strArrParameterName[i],objArrParameterValue[i]);
            }
            if (objScmd.ExecuteNonQuery() < 1)
                blnVal = false;
            else
                blnVal = true;
            Closeconnection();
            return blnVal;
        }
        public DataTable ExecuteGetAllQuery(string strQuery, string[] strArrParameterName, object[] objArrParameterValue)
        {
            if (strArrParameterName.Length != objArrParameterValue.Length)
            {
                return null;
            }
            Openconnection();
            SqlCommand objScmd = new SqlCommand(strQuery, _objScon);
            for (int i = 0; i < strArrParameterName.Length; i++)
            {
                objScmd.Parameters.AddWithValue(strArrParameterName[i],objArrParameterValue[i]);
            }
            SqlDataAdapter sdaExecute = new SqlDataAdapter(objScmd);
            DataTable dtRetVal = new DataTable();
            sdaExecute.Fill(dtRetVal);         
            Closeconnection();
            return dtRetVal;
        }
        
    }
}
