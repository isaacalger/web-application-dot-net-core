using System;

namespace WebApplication.Data.Core.EntityModels
{
    public class UserAccount
    {
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
