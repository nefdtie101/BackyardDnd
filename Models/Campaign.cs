namespace BackyardDndApi.Model
{
    public class Campaign : User
    {
        public string CampaignName { get; set; }
        public int DungeonMasterID { get; set; }
        public string PlayerIDs { get; set; }
        public string Intro { get; set; }
        public string CurrentWheatherTime { get; set; }
        public int NPCTable { get; set; }
        public int MonsterTable { get; set; }
    }
}