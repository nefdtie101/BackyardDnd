using BackyardDndApi.Model;

namespace Repository.Interface
{
    public interface IPlayerView
    {
        public string[] ShowItems(User user);
        public string[] ShowSpells(User user);
        public string ShowMainStats(User user);
    }
}