using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LMN.Models
{
    public class LMNContext : DbContext
    {
        public LMNContext() : base("name=LMNContext")
        {
        }

        public System.Data.Entity.DbSet<LMN.Models.User> Users { get; set; }
    }
}
