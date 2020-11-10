using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data.Core.EntityModels
{
    //TODO I may end up extending IdentityUser at some point.
    public class UserAccount
    {
        [Key]
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public UserAccount()
        {
            Guid = Guid.NewGuid();
        }
    }
}
