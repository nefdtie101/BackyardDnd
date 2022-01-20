using System;
using BackyardDndApi.Model;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;

namespace BackyardDndApi.Controllers
{
    [Route("api/DungeonMaster")]
    [ApiController]

    public class DungeonMasterController : ControllerBase
    {
        private readonly IDungeonMaster _dungeonMaster;

        public DungeonMasterController
        (
            IDungeonMaster dungeonMaster
        )
        {
            _dungeonMaster = dungeonMaster;
        }
        
        [HttpPost]
        [Route("AddCampaign")]
        public IActionResult AddCampaign(Campaign campaign)
        {
            _dungeonMaster.CreateCampaign(campaign);
            return Ok("Campaign Added");
        }

        [HttpPost]
        [Route("SeeCampaigns")]
        public IActionResult ViewCampaigns(User user)
        {
            var Output = _dungeonMaster.ViewCampaign(user);
            return Ok(Output);
        }

        [HttpPost]
        [Route("Set Time")]
        public IActionResult WheatherTime(string Time, string Weather, Campaign campaign)
        {
            _dungeonMaster.WheatherTime(Time, Weather, campaign);
            return Ok("Time Updated");
        }
        
        [HttpPost]
        [Route("Edit Player Stat")]
        public IActionResult EditPlayer(User user, string stat, int newStat)
        {
            _dungeonMaster.EditPlayer(user, stat, newStat);
            return Ok("Time Updated");
        }
    }
}