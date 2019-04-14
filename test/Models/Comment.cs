using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
            //これは一体
            [DisplayColumn("Body")]

public class Comment
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        public string Name { set; get; }

        [DisplayName("コメント")]
        public string Body { set; get;}

        [DisplayName("更新日")]
        [DisplayFormat(DataFormatString ="{0:yyyy年 MM月 dd日}")]
        public DateTime Updated { set; get; }

        //1:nの関係の時
        [DisplayName("記事")]
        public virtual Article Article { set; get; }
}
}