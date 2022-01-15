using System;
using System.Xml.Serialization;
using BackyardDndApi.Model;
using Database;
using Microsoft.Data.SqlClient;
using Repository.Interface;

namespace Repository.Repository
{
    public class PlayerViewRepo : IPlayerView
    {
        private readonly DataBaseHelper _dataBaseHelper;
        private readonly Converter _converter;

        public PlayerViewRepo(DataBaseHelper data, Converter conv)
        {
            _dataBaseHelper = data;
            _converter = conv;
        }

        public string[] ShowItems(User user)
        {
            
            try
            {
                string[] Target =
                {
                    "EquipmentIDs"
                };
                var res = _dataBaseHelper.ShowValue("spShowItems", Target);
                var arrItems = res.Split(',');

                return arrItems;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public string[] ShowSpells(User user)
        {
            
            try
            {
                string[] Target =
                {
                    "SpellsSkills"
                };
                var res = _dataBaseHelper.ShowValue("spShowSpells", Target);
                var arrSpells = res.Split(',');

                return arrSpells;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public string ShowMainStats(User user)
        {
            
            try
            {
                string[] Target =
                {
                    "STR",
                    "DEX",
                    "CON",
                    "INTelligence",
                    "WIS",
                    "CHA"
                };
                var res = _dataBaseHelper.ShowValue("spShowMainStats", Target);

                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public string ShowSubStats(User user)
        {
            
            try
            {
                string[] Target =
                {
                    "STRSave",
                    "Athletics", 
                    "DEXSave",
                    "Acrobatics",
                    "SleightOfHand",
                    "Stealth",
                    "CONSave",
                    "INTSave",
                    "Arcana",
                    "History",
                    "Investigation",
                    "Nature",
                    "Religion",
                    "WISSave",
                    "AnimalHandling",
                    "Insight",
                    "Medicine",
                    "Perception",
                    "Survival",
                    "CHASave",
                    "Deception",
                    "Intimidation",
                    "Performance",
                    "Persuasion"
                };
                var res = _dataBaseHelper.ShowValue("spShowSubStats", Target);

                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string Roll(User user, int Roll, string Stat)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@Stat", Stat),
                    new SqlParameter("@Target", user.UserId.ToString())
                };
                var res = _dataBaseHelper.ShowModifier("spShowModifier", dataParams);
                Random Dice = new Random();
                int rollOutput = Dice.Next(1, Roll);
                int FinalRoll;
                var Modifier = 0;
                if (Stat is "STR" or "DEX" or "CON" or "INTellegence" or "WIS" or "CHA")
                {
                    switch (Int32.Parse(res)) 
                    {
                        case 1:
                            Modifier = -5;
                            break;
                        case 2:
                            Modifier = -4;
                            break;
                        case 3:
                            Modifier = -4;
                            break;
                        case 4:
                            Modifier = -3;
                            break;
                        case 5:
                            Modifier = -3;
                            break;
                        case 6:
                            Modifier = -2;
                            break;
                        case 7:
                            Modifier = -2;
                            break;
                        case 8:
                            Modifier = -1;
                            break;
                        case 9:
                            Modifier = -1;
                            break;
                        case 10:
                            Modifier = 0;
                            break;
                        case 11:
                            Modifier = 0;
                            break;
                        case 12:
                            Modifier = 1;
                            break;
                        case 13:
                            Modifier = 1;
                            break;
                        case 14:
                            Modifier = 2;
                            break;
                        case 15:
                            Modifier = 2;
                            break;
                        case 16:
                            Modifier = 3;
                            break;
                        case 17:
                            Modifier = 3;
                            break;
                        case 18:
                            Modifier = 4;
                            break;
                        case 19:
                            Modifier = 4;
                            break;
                        case 20:
                            Modifier = 5;
                            break;
                    }
                    FinalRoll = rollOutput + Modifier;
                }
                else
                {
                    Modifier = Int32.Parse(res);
                }
                FinalRoll = rollOutput + Modifier;
                return "You rolled: " + rollOutput.ToString() + "\nYour " + Stat + " modifier: " + Modifier + "\nFinal Amount: " + FinalRoll.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}