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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data ekleme
            modelBuilder.Entity<ChatMessage>().HasData(
                new ChatMessage
                {
                    Id = 1,
                    RoomName = "Room-1",
                    UserName = "Admin",
                    Message = "Hoş geldiniz! Burada her türlü soru ve sorunlarınızı paylaşabilirsiniz.",
                    Timestamp = DateTime.Now
                },
                new ChatMessage
                {
                    Id = 2,
                    RoomName = "Room-1",
                    UserName = "User1",
                    Message = "Teşekkürler! Bu gerçekten harika bir özellik.",
                    Timestamp = DateTime.Now
                }
            );
        }
    }
}
