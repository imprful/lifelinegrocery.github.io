using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConnString;

        public Functions() 
        {
            ConnString = "Data Source=P-REALMEBOOK\\SQLEXPRESS10;Initial Catalog=OnlineGroceryManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Con= new SqlConnection(ConnString);
            cmd = new SqlCommand();
            cmd.Connection = Con;

        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query,ConnString);
            sda.Fill(dt);
            return dt;
        }
        public int SetData(string Query)
        {
            int Cnt = 0;
            if(Con.State==ConnectionState.Closed)
            {
                Con.Open();

            }
            cmd.CommandText= Query;
            Cnt =cmd.ExecuteNonQuery();
            return Cnt; 
        }
    }
}   