namespace ChatService.Api.Models
{
    public class Room
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ChatMessage> ChatMessages { get; set; }
    }

}
