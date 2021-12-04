using BackyardDndApi.Model.Enum;

namespace BackyardDndApi.Model
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public Roles Role { get; set; }
    }
}