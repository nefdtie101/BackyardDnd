using System;
using BackyardDndApi.Model;
using Database;
using Microsoft.Data.SqlClient;
using Repository.Interface;

namespace Repository.Repository
{
    public class DungeonMasterRepo : IDungeonMaster
    {
        private readonly DataBaseHelper _dataBaseHelper;
        private readonly Converter _converter;

        public DungeonMasterRepo(DataBaseHelper data, Converter conv)
        {
            _dataBaseHelper = data;
            _converter = conv;
        }

        public string Test(User user)
        {
            return "Ok!";
        }

        public void WheatherTime(string Time, string Weather, Campaign campaign)
        {
            try
            {
                var newWheatherTime = Weather + ";" + Time;

                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@CampaignName", campaign.CampaignName),
                    new SqlParameter("@Target", "CurrentWeatherTime"),
                    new SqlParameter("@NewValue", newWheatherTime)
                };
                var res = _dataBaseHelper.TriggerStoredProcNoTable("spUpdateCampaign", dataParams);
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CreateCampaign(Campaign campaign)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@CampaignName", campaign.CampaignName),
                    new SqlParameter("@DungeonMasterID", (int)campaign.UserId),
                    new SqlParameter("@PlayerIDs", campaign.PlayerIDs),
                    new SqlParameter("@Intro", campaign.Intro),
                    new SqlParameter("@CurrentWeather", campaign.CurrentWheatherTime),
                    new SqlParameter("@NPCTable", campaign.NPCTable),
                    new SqlParameter("@MonsterTable", campaign.MonsterTable)
                };
                _dataBaseHelper.TriggerStoredProcNoTable("spAddNewCampaign", dataParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string ViewCampaign(User user)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@idUser", user.UserId),
                };
                var res =_dataBaseHelper.TriggerStoredProcNoTable("spViewCampaigns", dataParams);
                return res.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}