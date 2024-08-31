using ChatService.Api.Data;
using ChatService.Api.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatDbContext _context;

        public ChatHub(ChatDbContext context)
        {
            _context = context;
        }

        private static List<string> _rooms = new List<string>();

        public async Task JoinRoom(string room)
        {
            // Eğer oda listede yoksa, listeye ekle
            if (!_rooms.Contains(room))
            {
                _rooms.Add(room);
            }
            // Kullanıcıyı belirli bir odaya katılmak için gruba ekleyin
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            // Odaya katıldığını diğer kullanıcılara bildirmek için bir mesaj gönderebilirsiniz
            await Clients.Group(room).SendAsync("ReceiveMessage", $"{Context.ConnectionId} odaya katıldı: {room}");

            await Clients.Group("AdminGroup").SendAsync("ReceiveRoomList", _rooms);

        }

        public async Task AddAdminToGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "AdminGroup");

            // Admin katıldığında mevcut oda listesini gönderin
            await Clients.Caller.SendAsync("ReceiveRoomList", _rooms);
        }



        public async Task SendMessage(string roomName, string user, string message)
        {
            try
            {
                // Veritabanına mesajı önce kaydet
                var chatMessage = new ChatMessage
                {
                    RoomName = roomName,
                    UserName = user,
                    Message = message,
                    Timestamp = DateTime.Now
                };

                _context.ChatMessages.Add(chatMessage);
                await _context.SaveChangesAsync();

                // Mesajı sadece belirtilen odaya gönder
                await Clients.Group(roomName).SendAsync("ReceiveMessage", user, message);
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine($"Error occurred: {ex.Message}");
                // İsteğe bağlı olarak hata loglama veya diğer işlemleri burada yapabilirsiniz.
            }
        }

        public async Task LoadMessages(string roomName)
        {
            // Veritabanından mesaj geçmişini yükle
            var messages = await _context.ChatMessages
                .Where(m => m.RoomName == roomName)
                .OrderBy(m => m.Timestamp) // Mesajları zaman damgasına göre sıralayın
                .ToListAsync();

            // Mesajları çağıran istemciye gönder
            await Clients.Caller.SendAsync("ReceiveMessages", messages);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.Items["RoomName"]?.ToString());
            await base.OnDisconnectedAsync(exception);
        }
    }
}
