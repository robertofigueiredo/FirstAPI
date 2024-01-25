namespace Awesomedevevents.API.Entities
{
    public class DevEventSpeaker
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TalkTitle { get; set; } = string.Empty;
        public string TalkDescription { get; set; } = string.Empty;
        public string LinkedInProfile { get; set; } = string.Empty;

    }
}