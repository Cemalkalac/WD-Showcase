using Microsoft.AspNetCore.Mvc;
using SoundHunt_Showcase.Models;
using SoundHunt_Showcase.Services;
using System.Diagnostics;

namespace SoundHunt_Showcase.Controllers
{
    public class GameController : Controller
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        public GameController(ISpotifyAccountService spotifyAccountService, IConfiguration configuration, ISpotifyService spotifyService)
        {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifyService = spotifyService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string genreDropdown)
        {

            var newReleases = await GetReleases(genreDropdown);
            return View(newReleases);
        }

        private async Task<IEnumerable<Playlist>> GetReleases(string playlist)
        {
            try
            {

                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newReleases = await _spotifyService.GetPlaylist(playlist, 20, token);

                return newReleases;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return Enumerable.Empty<Playlist>();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
