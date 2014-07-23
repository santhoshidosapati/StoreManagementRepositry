﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SQLConnector;
using System.Data;
using SuperMarket.ResponceClass;

namespace SuperMarket.Classes
{
    public class Transaction
    {
        const string SUCCESS_MSG = "Successfully {0}  Transaction";
        const string Failure_MSG = "Unable to {0} a Transaction";
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { set; get; }
        public int Quqntity { set; get; }
        public decimal Profit { set; get; }


        public Response Create(Transaction objTransaction)
        {
            SQLConnector.DBOperations objdb = new DBOperations(Properties.Settings.Default.SuperMarketConnectionString);
            string stInsert = @"INSERT INTO [Transaction] ([Name],[Date],[Quqntity] ,[Profit])
             VALUES (@Name, @Date, @Quqntity, @Profit)";
            string[] strAddParameterName = new string[] { "Name", "Date", "Quqntity", "Profit" };
            object[] objAddparametervalue = new object[] { objTransaction.Name, objTransaction.Date, objTransaction.Quqntity, this.Profit };
            if (!objdb.ExecuteQuery(stInsert, strAddParameterName, objAddparametervalue))
                return new Response(9999, string.Format(Failure_MSG, "insert"));

            else

                return new Response(5555, string.Format(SUCCESS_MSG, "inserted"));
        }

       public Response Delete(Transaction objTransaction)
        {
            DBOperations objdb = new DBOperations(Properties.Settings.Default.SuperMarketConnectionString);
            string strDelete = "DELETE FROM [UsersTable] WHERE Id=@Id";
            string[] strAddParameterName = new string[] { "Id" };
            object[] objAddparametervalue = new object[] { objTransaction.Id };
            if (!objdb.ExecuteQuery(strDelete, strAddParameterName, objAddparametervalue))

                return new Response(9999, string.Format(Failure_MSG, "delete"));
            else

                return new Response(5555, string.Format(SUCCESS_MSG, "deleted"));
        }

        public Response Update(Transaction objTransaction)
        {
            DBOperations objdb = new DBOperations(Properties.Settings.Default.SuperMarketConnectionString);
            string strUpsate = @"UPDATE [SuperMarket].[dbo].[Transaction]
               SET [Name] = @Name
                  ,[Date] = @Date, date,>
                  ,[Quqntity] = @Quqntity, int,>
                  ,[Profit] = @Profit, money,>
             WHERE Id=@Id ";
            string[] strAddParameterName = new string[] { "Name", "Date", "Quqntity","Profit","Id" };
            object[] objAddparametervalue = new object[] { objTransaction.Name, objTransaction.Date, objTransaction.Quqntity ,objTransaction.Profit,objTransaction.Id};
            if (!objdb.ExecuteQuery(strUpsate, strAddParameterName, objAddparametervalue))
                return new Response(9999, string.Format(Failure_MSG, "update"));
            else
                return new Response(5555, string.Format(SUCCESS_MSG, "updated"));
        }

        public static UsersTable Get(int Id)
        {
            DBOperations objdb = new DBOperations(Properties.Settings.Default.SuperMarketConnectionString);
            UsersTable objUsersTable = new UsersTable();
            string strGetOneRecord = "SELECT * FROM [Transaction] where Id=@Id";
            string[] strAddParameterName = new string[] { "Id" };
            object[] objAddparametervalue = new object[] { objUsersTable.Id };
            System.Data.DataTable objtab = objdb.ExecuteGetAllQuery(strGetOneRecord, strAddParameterName, objAddparametervalue);
            return objUsersTable;
        }

        public static List<Transaction> GetAll()
        {
            DBOperations objdb = new DBOperations(Properties.Settings.Default.SuperMarketConnectionString);
            List<Transaction> lstTransaction = new List<Transaction>();
            Transaction objTransaction = new Transaction();
            string strGetOneRecord = "SELECT * FROM [Transaction]";
            string[] strAddParameterName = new string[] { };
            object[] objAddparametervalue = new object[] { };
            DataTable objtab = new DataTable();
            objtab = objdb.ExecuteGetAllQuery(strGetOneRecord, strAddParameterName, objAddparametervalue);

            for (int i = 0; i < objtab.Rows.Count; i++)
            {
                int intId;
                DateTime dtDate;
                int intQuqntity;
                decimal decProfit;
                objTransaction = new Transaction();
                int.TryParse(objtab.Rows[i]["Id"].ToString(), out intId);
                objTransaction.Id = intId;
                objTransaction.Name = objtab.Rows[i]["Name"] != null ? objtab.Rows[i]["Name"].ToString() : string.Empty;
                DateTime.TryParse(objtab.Rows[i]["Date"].ToString(), out dtDate);
                objTransaction.Date = dtDate;
                int.TryParse(objtab.Rows[i]["Quantity"].ToString(), out intQuqntity);
                objTransaction.Quqntity = intQuqntity;
                decimal.TryParse(objtab.Rows[i]["Profit"].ToString(), out decProfit);
                objTransaction.Profit = decProfit;              
                lstTransaction.Add(objTransaction);
            }
            return lstTransaction;
        }
    }
}