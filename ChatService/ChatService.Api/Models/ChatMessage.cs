namespace ChatService.Api.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
