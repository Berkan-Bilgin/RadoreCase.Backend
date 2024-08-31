using ChatService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Api.Data
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> opt) : base(opt)
        {

        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(
                   new Room
                   {
                       Id = "Room-User1",
                       Name = "Room-User1",
                       CreatedAt = DateTime.UtcNow
                   },
                   new Room
                   {
                       Id = "Room-User2",
                       Name = "Room-User2",
                       CreatedAt = DateTime.UtcNow
                   }
               );

            modelBuilder.Entity<ChatMessage>().HasData(
                new ChatMessage
                {
                    Id = 1,
                    RoomId = "Room-User2", // Room-1 ile ilişkilendirildi
                    UserName = "Admin",
                    Message = "Hoş geldiniz! Burada her türlü soru ve sorunlarınızı paylaşabilirsiniz.",
                    Timestamp = DateTime.UtcNow
                },
                new ChatMessage
                {
                    Id = 2,
                    RoomId = "Room-User2", // Room-1 ile ilişkilendirildi
                    UserName = "User1",
                    Message = "Teşekkürler! Bu gerçekten harika bir özellik.",
                    Timestamp = DateTime.UtcNow
                }
            );
        }
    }
}
