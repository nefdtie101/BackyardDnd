namespace BackyardDndApi.Model
{
    public class PlayerForm
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string CharacterName { get; set; }
        public string Class { get; set; }
        public int CurrentLevel { get; set; }
        public string Background { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public int Experience { get; set; }
        public int ProfBonus { get; set; }
        public int Inspiration { get; set; }
        public int Armor { get; set; }
        public int Speed { get; set; }
        public int Initiative { get; set; }
        public int PassivePerception { get; set; }
        public int TempHp { get; set; }
        public int Hp { get; set; }
        public string SpellsSkills { get; set; }
        public int STR { get; set; }
        public int STRSave { get; set; }
        public int Athletics { get; set; }
        public int DEX { get; set; }
        public int DEXSave { get; set; }
        public int Acrobatics { get; set; }
        public int SleightOfHand { get; set; }
        public int Stealth { get; set; }
        public int CON { get; set; }
        public int CONSave { get; set; }
        public int INTelligence { get; set; }
        public int INTSave { get; set; }
        public int Arcana { get; set; }
        public int History { get; set; }
        public int Investigation { get; set; }
        public int Nature { get; set; }
        public int Religion { get; set; }
        public int WIS { get; set; }
        public int WISSave { get; set; }
        public int AnimalHandling { get; set; }
        public int Insight { get; set; }
        public int Medicine { get; set; }
        public int Perception { get; set; }
        public int Survival { get; set; }
        public int CHA { get; set; }
        public int CHASave { get; set; }
        public int Deception { get; set; }
        public int Intimidation { get; set; }
        public int Performance { get; set; }
        public int Persuasion { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Flaws { get; set; }
        public string EquipmentIDs { get; set; }
        public string PhotoPath { get; set; }
    }
}