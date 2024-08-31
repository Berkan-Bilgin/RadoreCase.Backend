namespace ChatService.Api.Models
{

    public class ChatMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public DateTime Timestamp { get; set; }


        public string RoomId { get; set; }
        public Room Room { get; set; }
    }
}
