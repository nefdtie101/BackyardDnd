namespace BackyardDndApi.Model
{
    public class PlayerForm : CharacterStats
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}