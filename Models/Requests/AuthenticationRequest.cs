﻿namespace API_Marketplace_.net_7_v1.Models.Requests
{
    public partial class UserAPIHandler
    {
        public class AuthenticationRequest
        {
            public string Email { get; set; }
            public string PasswordHash { get; set; }
        }
    }
}
