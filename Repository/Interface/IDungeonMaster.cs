using System;
using BackyardDndApi.Model;

namespace Repository.Interface
{
    public interface IDungeonMaster
    {
        public string Test(User user);
        public void WheatherTime(string Time, string Weather, Campaign campaign);
        public void CreateCampaign(Campaign campaign);
        public string ViewCampaign(User user);
    }
}