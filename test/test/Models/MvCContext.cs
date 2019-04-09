using System.Data.Entity;

namespace test.Models
{
    public class MvCContext : DbContext
    {
        //　　　　　入れ物　db上のテーブル
        public DbSet<Member> Members { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cate> Cates { get; set; }

        //azureやA5の方でデータ入れる際はN'とまと'と打たないと文字化けした　スキャフォールディングのcreateでは問題なし
    }
}