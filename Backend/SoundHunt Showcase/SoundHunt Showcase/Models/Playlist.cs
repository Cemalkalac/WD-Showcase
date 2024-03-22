namespace SoundHunt_Showcase.Models
{
    public class Playlist
    {
        public string Name { get; set; }
        public string Artists { get; set; }
        public string Preview_Url { get; set; }
        public List<Question> Questions { get; set; }

        public Playlist()
        {
            Questions = new List<Question>();
        }
    }
    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
    }
}
