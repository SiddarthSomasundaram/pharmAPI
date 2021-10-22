using System;
using System.Collections.Generic;

#nullable disable

namespace AdminAPI.Models
{
    public partial class CustomerDetail
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public string Password { get; set; }
    }
}
