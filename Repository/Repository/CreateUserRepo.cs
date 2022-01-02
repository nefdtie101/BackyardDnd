using System;
using System.Data;
using BackyardDndApi.Model;
using Database;
using Microsoft.Data.SqlClient;
using Repository.Interface;

namespace Repository.Repository
{
    public class CreateUser : ICreateUserInterface
    {
        private readonly DataBaseHelper _dataBaseHelper;
        private readonly Converter _converter;

        public CreateUser(DataBaseHelper data, Converter conv)
        {
            _dataBaseHelper = data;
            _converter = conv;
        }
        public void AddUser(User user)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@UserName", user.UserName),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@Role", (int) user.Role)
                };
                var res = _dataBaseHelper.TriggerStoredProcNoTable("spAddNewUser", dataParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        

        public void AddPlayer(PlayerForm pForm)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@idUser", (int) pForm.UserId),
                    new SqlParameter("@CharacterName", pForm.CharacterName),
                    new SqlParameter("@Class", pForm.Class),
                    new SqlParameter("@CurrentLevel", (int) pForm.CurrentLevel),
                    new SqlParameter("@Background", pForm.Background),
                    new SqlParameter("@Race", pForm.Race),
                    new SqlParameter("@Alignment", pForm.Alignment),
                    new SqlParameter("@Experience", (int) pForm.Experience),
                    new SqlParameter("@ProfBonus", (int) pForm.ProfBonus),
                    new SqlParameter("@Inspiration", (int) pForm.Inspiration),
                    new SqlParameter("@Armor", (int) pForm.Armor),
                    new SqlParameter("@Speed", (int) pForm.Speed),
                    new SqlParameter("@Initiative", (int) pForm.Initiative),
                    new SqlParameter("@PassivePerception", (int) pForm.PassivePerception),
                    new SqlParameter("@TempHP", (int) pForm.TempHp),
                    new SqlParameter("@HP", (int) pForm.Hp),
                    new SqlParameter("@SpellsSkills", pForm.SpellsSkills),
                    new SqlParameter("@STR", (int) pForm.STR),
                    new SqlParameter("@STRSave", (int) pForm.STRSave),
                    new SqlParameter("@Athletics", (int) pForm.Athletics),
                    new SqlParameter("@DEX", (int) pForm.DEX),
                    new SqlParameter("@DEXSave", (int) pForm.DEXSave),
                    new SqlParameter("@Acrobatics", (int) pForm.Acrobatics),
                    new SqlParameter("@SleightOfHand", (int) pForm.SleightOfHand),
                    new SqlParameter("@Stealth", (int) pForm.Stealth),
                    new SqlParameter("@CON", (int) pForm.CON),
                    new SqlParameter("@CONSave", (int) pForm.CONSave),
                    new SqlParameter("@INTelligence", (int) pForm.INTelligence),
                    new SqlParameter("@INTSave", (int) pForm.INTSave),
                    new SqlParameter("@Arcana", (int) pForm.Arcana),
                    new SqlParameter("@History", (int) pForm.History),
                    new SqlParameter("@Investigation", (int) pForm.Investigation),
                    new SqlParameter("@Nature", (int) pForm.Nature),
                    new SqlParameter("@Religion", (int) pForm.Religion),
                    new SqlParameter("@WIS", (int) pForm.WIS),
                    new SqlParameter("@WISSave", (int) pForm.WISSave),
                    new SqlParameter("@AnimalHandling", (int) pForm.AnimalHandling),
                    new SqlParameter("@Insight", (int) pForm.Insight),
                    new SqlParameter("@Medicine", (int) pForm.Medicine),
                    new SqlParameter("@Perception", (int) pForm.Perception),
                    new SqlParameter("@Survival", (int) pForm.Survival),
                    new SqlParameter("@CHA", (int) pForm.CHA),
                    new SqlParameter("@CHASave", (int) pForm.CHASave),
                    new SqlParameter("@Deception", (int) pForm.Deception),
                    new SqlParameter("@Intimidation", (int) pForm.Intimidation),
                    new SqlParameter("@Performance", (int) pForm.Performance),
                    new SqlParameter("@Persuasion", (int) pForm.Persuasion),
                    new SqlParameter("@PersonalityTraits", pForm.PersonalityTraits),
                    new SqlParameter("@Ideals", pForm.Ideals),
                    new SqlParameter("@Flaws", pForm.Flaws),
                    new SqlParameter("@EquipmentIDs", pForm.EquipmentIDs),
                    new SqlParameter("@PhotoPath", pForm.PhotoPath),
                };
                var res = _dataBaseHelper.TriggerStoredProcNoTable("spAddNewPlayer", dataParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public bool Login(User user)
        {
            try
            {
                SqlParameter[] dataParams = new SqlParameter[]
                {
                    new SqlParameter("@Username", user.UserName),
                    new SqlParameter("@Password", user.Password)
                };
                var res = _dataBaseHelper.TriggerStoredProc("spLogin", dataParams);
                if (res.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}