using System;
using System.Data;
using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Database
{
    public class DataBaseHelper 
    {
        private readonly IConfiguration _configuration;
        public DataBaseHelper(IConfiguration configuration)
        {
            try
            {
                _configuration = configuration;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Connect To Db
        private void Connect()
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Sql"));
            sqlConnection.Open();

        }

        private void Close()
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Sql"));
            sqlConnection.Close();
        }


        // //Execute Stored Proc with params and return data table 
        public DataTable TriggerStoredProc(string proc, SqlParameter[] p)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Sql"));
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(proc ,sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddRange(p);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Execute Stored Proc with params and return  no data table 
        public int TriggerStoredProcNoTable(string proc, SqlParameter[] p)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Sql"));
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(proc ,sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddRange(p);
                int res = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public string ShowValue(string proc, string[] Target)
        {
            try
            {
                var res = "";
                SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                using(sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(proc,sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    var dbReader = sqlCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        
                        foreach (var word in Target)
                        {
                            var temp = dbReader[word].ToString();
                            res = res + $"[{temp}]";
                        }
                    }
                    dbReader.Close();
                }
                sqlConnection.Close();
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public string ShowModifier(string proc, SqlParameter[] p)
        {
            try
            {
                string res = "";
                SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Sql"));

                using(sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(proc,sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(p);
                    var dbReader = sqlCommand.ExecuteReader();
                    while (dbReader.Read())
                    {
                        res = dbReader.GetInt32(0).ToString();
                    }
                    dbReader.Close();
                }
                sqlConnection.Close();
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

       
