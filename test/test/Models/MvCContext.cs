using System.Data.Entity;

namespace test.Models
{
    public class MvCContext : DbContext
    {
        //　　　　　入れ物　db上のテーブル
        public DbSet<Item> Items { get; set; }
        public DbSet<Cate> Cates { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Member> Members { set; get; }

        //azureやA5の方でデータ入れる際はN'とまと'と打たないと文字化けした　スキャフォールディングのcreateでは問題なし
        //TODO:membersは勝手にdb作ってくれたが（コードファースト）作ってくれずテーブルが見つからないとエラー吐く場合もある　なぜか
        //Articles Author Commentsの関連付け含めたテーブルは作ってくれた
    }
}