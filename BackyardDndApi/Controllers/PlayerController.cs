using System;
using System.Net.Mime;
using BackyardDndApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Repository.Interface;

namespace BackyardDndApi.Controllers
{
    [Route("api/player")]
    [ApiController]
    
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerView _playerView;

        public PlayerController
        (
            IPlayerView playerView
        )
        {
            _playerView = playerView;
        }
        
        [HttpPost]
        [Route("Show Items")]
        public IActionResult ShowItems(User user)
        {
            var itemList = "";
            var inventory = _playerView.ShowItems(user);
            foreach (var word in inventory)
            {
                itemList = itemList + $"{word},";
            }
            itemList = itemList.Remove(itemList.Length - 1, 1);
            CharacterStats cStats = new CharacterStats
            {
                EquipmentIDs = itemList
            };
            return Ok(cStats);
        }
        
        [HttpPost]
        [Route("Show Spells")]
        public IActionResult ShowSpells(User user)
        {
            var spellList = "";
            var spells = _playerView.ShowSpells(user);
            foreach (var word in spells)
            {
                spellList = spellList + $"{word},";
            }
            spellList = spellList.Remove(spellList.Length - 1, 1);  
            CharacterStats cStats = new CharacterStats
            {
                SpellsSkills = spellList
            };
            return Ok(cStats);
        }
        
        [HttpPost]
        [Route("Show Main Stats")]
        public IActionResult ShowMainStats(User user)
        {
            var arrStats = _playerView.ShowMainStats(user);

            CharacterStats cStats = new CharacterStats
            {
                STR = Int32.Parse(arrStats[0]),
                DEX = Int32.Parse(arrStats[1]),
                CON = Int32.Parse(arrStats[2]),
                INTelligence = Int32.Parse(arrStats[3]),
                WIS = Int32.Parse(arrStats[4]),
                CHA = Int32.Parse(arrStats[5])
            };

            return Ok(cStats);
        }
        
        [HttpPost]
        [Route("Show Sub Stats")]
        public IActionResult ShowSubStats(User user)
        {
            var stats = _playerView.ShowSubStats(user);
            
            CharacterStats cStats = new CharacterStats
            {
                STRSave = Int32.Parse(stats[0]),
                Athletics = Int32.Parse(stats[1]),
                DEXSave = Int32.Parse(stats[2]),
                Acrobatics = Int32.Parse(stats[3]),
                SleightOfHand = Int32.Parse(stats[4]),
                Stealth = Int32.Parse(stats[5]),
                CONSave = Int32.Parse(stats[6]),
                INTSave = Int32.Parse(stats[7]),
                Arcana = Int32.Parse(stats[8]),
                History = Int32.Parse(stats[9]),
                Investigation = Int32.Parse(stats[10]),
                Nature = Int32.Parse(stats[11]),
                Religion = Int32.Parse(stats[12]),
                WISSave = Int32.Parse(stats[13]),
                AnimalHandling = Int32.Parse(stats[14]),
                Insight = Int32.Parse(stats[15]),
                Medicine = Int32.Parse(stats[16]),
                Perception = Int32.Parse(stats[17]),
                Survival = Int32.Parse(stats[18]),
                CHASave = Int32.Parse(stats[19]),
                Deception = Int32.Parse(stats[20]),
                Intimidation = Int32.Parse(stats[21]),
                Performance = Int32.Parse(stats[22]),
                Persuasion = Int32.Parse(stats[23]),
            };
            
            return Ok(cStats);
        }
        
        [HttpPost]
        [Route("Roll")]
        public IActionResult Roll(User user, int Roll, string Stat)
        {
            var RollOutput = _playerView.Roll(user, Roll, Stat);
            return Ok(RollOutput);
        }
    }
}