using Microsoft.AspNetCore.Identity;

namespace VerySimpleForum.DataBase.Models
{
    public class User : IdentityUser
    {
        public int Likes { get; set; } = 0;
    }
}
