using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class MvCContext : DbContext
    {
        //　　　　　入れ物　db上のテーブル
        public DbSet<Member> Members { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}