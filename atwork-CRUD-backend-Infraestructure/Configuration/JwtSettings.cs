﻿namespace atwork_CRUD_backend_Infraestructure.Configuration
{
    public class JwtSettings
    {
        public required string Secret { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required int ExpirationInMinutes { get; set; }
    }
}