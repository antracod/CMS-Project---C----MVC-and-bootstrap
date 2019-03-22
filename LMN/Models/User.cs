using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMN.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public int permissionLevel { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

    }
}