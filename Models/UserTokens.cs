﻿namespace UniversityApiBackend.Models
{
    public class UserTokens
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public TimeSpan Validity { get; set; }
        public string RefreshToken { get; set; }
        public string EmailId { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
