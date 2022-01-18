using BackyardDndApi.Model;

namespace Repository.Interface
{
    public interface IPlayerView
    {
        public string[] ShowItems(User user);
        public string[] ShowSpells(User user);
        public string[] ShowMainStats(User user);
        public string[] ShowSubStats(User user);
        public Rolling Roll(User user, int Roll, string Stat);
    }
}