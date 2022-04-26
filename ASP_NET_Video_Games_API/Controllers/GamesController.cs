using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_Video_Games_API.Models;

namespace ASP_NET_Video_Games_API.Controllers
{   //api/Games
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllVideoGames()
        {
            var allVideoGames = _context.VideoGames;

            return Ok(allVideoGames);
        }

        [HttpGet("{Id}")]
        public IActionResult GetGamesbyId(int Id)
        {
            var videoGames = _context.VideoGames.Where(vg => vg.Id == Id); 
            return Ok(videoGames);
        }
        [HttpGet("{Platform}")]
        public IActionResult GetGamesByPlatform(string platform)
        {
            var platform = _context.VideoGames;
            var platformData = platform.Where(p => p.Platform == platform);
            foreach (VideoGame platform in platformData)
            return Ok(platformData);
        }
    }

}
