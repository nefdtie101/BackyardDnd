using BackyardDndApi.Model;
using Microsoft.AspNetCore.Mvc;
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
                itemList = itemList + $"[{word}]";
            }
            return Ok("This works \n" + itemList);
        }
        
        [HttpPost]
        [Route("Show Spells")]
        public IActionResult ShowSpells(User user)
        {
            var spellList = "";
            var spells = _playerView.ShowSpells(user);
            foreach (var word in spells)
            {
                spellList = spellList + $"[{word}]";
            }
            return Ok("This works \n" + spellList);
        }
        
        [HttpPost]
        [Route("Show Main Stats")]
        public IActionResult ShowStats(User user)
        {
            var stats = _playerView.ShowMainStats(user);
            return Ok("This works \n" + stats);
        }
    }
}