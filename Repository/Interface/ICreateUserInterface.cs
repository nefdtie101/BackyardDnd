using BackyardDndApi.Model;

namespace Repository.Interface
{
    public interface ICreateUserInterface
    {
        public void AddUser(User user);
        public bool Login(User user);
        public void AddCharacter(PlayerForm pForm);
        public void DeleteCharacter(PlayerForm pForm);
        public void AddAdmin(User user);
    }
}