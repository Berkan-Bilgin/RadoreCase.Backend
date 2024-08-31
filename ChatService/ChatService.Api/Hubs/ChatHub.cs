using Microsoft.AspNetCore.SignalR;

namespace ChatService.Api.Hubs
{
    public class ChatHub : Hub
    {


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
            // Mesajı sadece belirtilen odaya gönder
            await Clients.Group(roomName).SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.Items["RoomName"]?.ToString());
            await base.OnDisconnectedAsync(exception);
        }
    }
}
