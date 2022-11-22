using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VerySimpleForum.DataBase.Models;

namespace VerySimpleForum.DataBase
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<SubTopic> SubTopics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
