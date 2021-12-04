using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataBaseHleper
{
    public class DataBaseHelper
    {
        private readonly IConfiguration _configuration;
        protected SqlCommand _sqlCommand = null;

        public DataBaseHelper(IConfiguration configuration)
        {
            try
            {
                _configuration = configuration;
                Connect();
                _sqlCommand = new SqlCommand();
                _sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        //Connect To Db
        protected void Connect()
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Sql"));
            sqlConnection.Open();
            
        }
        
        
        //Execute Stored Proc with params and return data table 
        public DataTable TriggerStoredProc(string proc , SqlParameter[] p)
        {
            try
            {
                _sqlCommand.CommandText = proc;
                _sqlCommand.Parameters.AddRange(p);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(_sqlCommand);
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

    }
}