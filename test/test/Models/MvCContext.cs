using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class MvCContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}