using System.Data.Entity;

namespace test.Models
{
    public class MvCContext : DbContext
    {
        //　　　　　入れ物　db上のテーブル
        public DbSet<Member> Members { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cate> Cates { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //azureやA5の方でデータ入れる際はN'とまと'と打たないと文字化けした　スキャフォールディングのcreateでは問題なし
        //TODO:membersは勝手にdb作ってくれたが（コードファースト）作ってくれずテーブルが見つからないとエラー吐く場合もある　なぜか
        //Articles Author Commentsの関連付け含めたテーブルは作ってくれた

        //ある日The model backing the 'MvCContext' context has changed since the database was created. というエラーが出てどのdb使うページも見れなくなった
        //webconfigのname部分の「context」を削除すれば通ったが今まで動いてたのが謎　この際にdbのデータは消えた
        //発行時にタイムアウトしてしまう
    }
}