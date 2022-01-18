namespace BackyardDndApi.Model
{
    public class CharacterStats : CharacterNarrative
    {
        public string CharacterName { get; set; }
        public string Class { get; set; }
        public int CurrentLevel { get; set; }
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
        public string EquipmentIDs { get; set; }
    }
}