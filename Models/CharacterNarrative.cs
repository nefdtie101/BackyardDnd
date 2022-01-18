namespace BackyardDndApi.Model
{
    public class CharacterNarrative : MainStats
    {
        public string Background { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Flaws { get; set; }
        public string PhotoPath { get; set; }
    }
}