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
            if (!_rooms.Contains(room))
            {
                _rooms.Add(room);
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            // Odaya katıldığını diğer kullanıcılara bildir
            await Clients.Group(room).SendAsync("ReceiveMessage", $"{Context.ConnectionId} odaya katıldı: {room}");

            await Clients.Group("AdminGroup").SendAsync("ReceiveRoomList", _rooms);

        }


        public async Task JoinRoomFromUser(string roomName)
        {
            // oda var mı
            var room = await _context.Rooms.SingleOrDefaultAsync(r => r.Name == roomName);

            if (room == null)
            {
                room = new Room { Id = roomName, Name = roomName, CreatedAt = DateTime.UtcNow };
                _context.Rooms.Add(room);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }

            // Kullanıcıyı gruba ekle
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);

            // Odaya katıldığını diğer kullanıcılara bildir
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} odaya katıldı: {roomName}");

            // Adminlere oda listesini gönder bura yanlış ya 
            var rooms = await _context.Rooms.Select(r => r.Name).ToListAsync();
            await Clients.Group("AdminGroup").SendAsync("ReceiveRoomList", rooms);
        }

        private static readonly Dictionary<string, bool> _adminJoinedRooms = new Dictionary<string, bool>();

        public async Task JoinRoomFromAdmin(string roomName)
        {
            // Adminin odaya daha önce katılıp katılmadığını kontrol et
            if (_adminJoinedRooms.TryGetValue(roomName, out bool isAdminJoined) && isAdminJoined)
            {
                return;
            }

            _adminJoinedRooms[roomName] = true;

            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"Admin odaya katıldı: {roomName}");
        }

        public async Task AddAdminToGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "AdminGroup");

            // Admin katıldığında mevcut oda listesini gönderin
            await Clients.Caller.SendAsync("ReceiveRoomList", _rooms);
        }



        public async Task SendMessage(string roomId, string user, string message)
        {
            try
            {
                var chatMessage = new ChatMessage
                {
                    RoomId = roomId,
                    UserName = user,
                    Message = message,
                    Timestamp = DateTime.Now
                };

                _context.ChatMessages.Add(chatMessage);
                await _context.SaveChangesAsync();

                // Mesajı sadece belirtilen odaya gönder
                await Clients.Group(roomId).SendAsync("ReceiveMessage", user, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        public async Task LoadMessages(string roomId)
        {
            // zamana göre mesajları getir receiveMessages dinleyenlere gönder
            var messages = await _context.ChatMessages
                .Where(m => m.RoomId == roomId)
                .OrderBy(m => m.Timestamp) // Mesajları zaman damgasına göre sıralayın
                .ToListAsync();

            await Clients.Caller.SendAsync("ReceiveMessages", messages);
        }

        public async Task LoadRooms()
        {
            //tarihe göre odaları getir ReceiveRooms dinleyenlere gönder
            var rooms = await _context.Rooms
                .OrderBy(r => r.CreatedAt).Select(r => r.Name)
                .ToListAsync();

            await Clients.Caller.SendAsync("ReceiveRooms", rooms);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.Items["RoomName"]?.ToString());
            await base.OnDisconnectedAsync(exception);
        }
    }
}
