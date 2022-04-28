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

        [HttpGet("searchByTitle/{searchInput}")]
        public IActionResult GetByTitle(string searchInput) {
         
            var videoGamesByTitle = _context.VideoGames.Where(vg => vg.Name.Contains(searchInput));

            return Ok(videoGamesByTitle);
        }
        [HttpGet("byPlatform-globalsales")]
        public IActionResult GetGamesByPlatform()
        {
            var platformTotalSales = _context.VideoGames.Select(vg => new { vg.Platform, vg.GlobalSales });
               

                 return Ok(platformTotalSales);
        }


    }
}
