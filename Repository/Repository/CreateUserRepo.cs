using System;
using System.Data;
using BackyardDndApi.Model;
using Database;
using Microsoft.Data.SqlClient;
using Repository.Interface;

namespace Repository.Repository
{
    public class CreateUser : ICreateUserInterface
    {
        private readonly DataBaseHelper _dataBaseHelper;
        private readonly Converter _converter;

        public CreateUser(DataBaseHelper data, Converter conv)
        {
            _dataBaseHelper = data;
            _converter = conv;
        }
        public void AddUser(User user)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@UserName", user.UserName),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@Role", (int) user.Role)
                };
                var res = _dataBaseHelper.TriggerStoredProcNoTable("spAddNewUser", dataParams);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public User GetUser(string Username)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@Username", Username),
                };
                var res = _dataBaseHelper.TriggerStoredProc("GetUser", dataParams);
                return _converter.ConvertUserModel(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        
    }
}