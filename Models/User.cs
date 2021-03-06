using BackyardDndApi.Model.Enum;
using Microsoft.EntityFrameworkCore;

namespace BackyardDndApi.Model
{
    public class User 
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}