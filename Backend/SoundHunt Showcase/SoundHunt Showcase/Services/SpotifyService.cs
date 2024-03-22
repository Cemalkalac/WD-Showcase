using SoundHunt_Showcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoundHunt_Showcase.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;

        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylist(string playlist_id, int limit, string accessToken)
        {
            // Set the authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Make the HTTP GET request to fetch the playlist
            var response = await _httpClient.GetAsync($"playlists/{playlist_id}?limit={limit}");

            // Ensure a successful response
            response.EnsureSuccessStatusCode();

            // Read and deserialize the response JSON
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetPlaylistResult>(responseStream);

            // Collect all unique artists from the playlist
            var allArtists = responseObject?.tracks?.items
                .SelectMany(item => item.track?.artists?.Select(artist => artist.name) ?? Enumerable.Empty<string>())
                .Distinct()
                .ToList() ?? new List<string>(4);

            // Map the response to Playlist objects
            var playlists = responseObject?.tracks?.items.Select(item =>
            {
                var playlist = new Playlist
                {
                    Name = item.track?.name ?? "Unknown",
                    Artists = string.Join(",", item.track?.artists?.Select(artist => artist.name) ?? Enumerable.Empty<string>()),
                    Preview_Url = item.track?.preview_url ?? "Unknown",
                };

                // Add questions and answers
                playlist.Questions = new List<Question>
                {
                    new Question
                    {
                        Text = "Who is the artist of this Track?",
                        Answers = ShuffleAnswers(allArtists, playlist.Artists)
                    }
                    // Add more questions as needed
                };

                return playlist;
            }) ?? Enumerable.Empty<Playlist>(); // Return an empty enumerable if responseObject is null

            return playlists;
        }

        private List<string> ShuffleAnswers(List<string> allAnswers, string correctAnswer)
        {
            var random = new Random();
            var shuffledAnswers = new List<string>();

            // Voeg het juiste antwoord toe
            shuffledAnswers.Add(correctAnswer);

            // Voeg drie willekeurige antwoorden toe (zonder het correcte antwoord)
            var otherAnswers = allAnswers.Where(answer => answer != correctAnswer).ToList();
            var randomOtherAnswers = otherAnswers.OrderBy(x => random.Next()).Take(3);
            shuffledAnswers.AddRange(randomOtherAnswers);

            // Meng de lijst om de volgorde te randomiseren
            shuffledAnswers = shuffledAnswers.OrderBy(x => random.Next()).ToList();

            return shuffledAnswers;
        }



    }
}
