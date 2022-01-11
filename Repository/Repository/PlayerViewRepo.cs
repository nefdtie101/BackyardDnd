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
    }
}