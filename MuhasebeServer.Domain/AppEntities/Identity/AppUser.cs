﻿using Microsoft.AspNetCore.Identity;


namespace MuhasebeServer.Domain.AppEntities.Identity
{
    public sealed class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameLastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpires { get; set; }
    }
}
