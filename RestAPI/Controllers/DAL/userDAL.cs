using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RestAPI.Models;
using System.Data;
namespace RestAPI.Controllers.DAL
{
    public class userDAL
    {

        public DataSet GetIO()
        {
            using (SqlConnection mycon = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                mycon.Open();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                cmd.Connection = mycon;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "displayIO";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
                         
            }
           
        }
        public string add(string  uids , string xpos, string ypos, string orientation, string type, string timestamp)
        {
            
            using (SqlConnection mycon = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                mycon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mycon;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "insertdata";
                cmd.Parameters.AddWithValue("id", uids);
                cmd.Parameters.AddWithValue("xpos", xpos);
                cmd.Parameters.AddWithValue("ypos", ypos);
                cmd.Parameters.AddWithValue("orientation", orientation);
                cmd.Parameters.AddWithValue("type", type);
                cmd.Parameters.AddWithValue("timestamp", timestamp);
                cmd.ExecuteNonQuery();

                return "1";
            }
        }
    }
    public class text
    {
    }
}