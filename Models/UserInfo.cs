using System;
using System.Collections.Generic;

namespace Asp.net_Api_Practice.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
