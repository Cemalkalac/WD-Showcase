using SoundHunt_Showcase.Models;

namespace SoundHunt_Showcase.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<Playlist>> GetPlaylist(string playlist_id, int limit, string accessToken);
        
    }
}
