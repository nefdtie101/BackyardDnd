using System;
using System.Data;
using BackyardDndApi.Model;
using BackyardDndApi.Model.Enum;

namespace Database
{
    public class Converter
    {
        public User ConvertUserModel(DataTable dtUser)
        {
            User user = new User();
            foreach (DataRow itemRow in dtUser.Rows)
            {
                user.UserId = Convert.ToInt32(itemRow["idUser"]);
                user.UserName = itemRow["UserName"].ToString();
                user.Password = itemRow["Password"].ToString();
                user.Role = (Roles) Convert.ToInt32(itemRow["Role"]);
            }

            return user;
        }
    }
}