using Microsoft.EntityFrameworkCore;
using Rabbit.Model.Entities;

namespace RabbitMqMessage.DAO
{
    public class RabbitMqContext : DbContext
    {
        public DbSet<RabbitMessage> RabbitMessage { get; set; } = null!;

        public DbSet<RabbitMessageLog> RabbitMessageLog { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer("Server=DESKTOP-O4IDJK1\\SQLEXPRESS,1433;Database=Mazatech;User ID=sa;Password=pr0d@p123;Trusted_Connection=False; TrustServerCertificate=True;");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=DESKTOP-O4IDJK1\\SQLEXPRESS;Database=Mazatech;User ID=sa;Password=pr0d@p123;Trusted_Connection=False; TrustServerCertificate=True;");

        
    
    }
}