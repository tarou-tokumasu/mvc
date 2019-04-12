using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
            //何故ここに
            [DisplayColumn("Body")]

public class Comment
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        public string Name { set; get; }

        [DisplayName("コメント")]
        public string Body { set; get;}

        [DisplayName("更新日")]
        public DateTime Updated { set; get; }

        //紐づけ？
        public int? ArticleId { get; set; }

        [DisplayName("記事")]
        public virtual Article Article { set; get; }
}
}