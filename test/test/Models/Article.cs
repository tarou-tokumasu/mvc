using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Article
    {
        public int Id { set; get; }

        [DisplayName("URL")]
        [DataType(DataType.Url)]
        public string Url { set; get; }

        [DisplayName("タイトル")]
        public string Title { set; get; }

        // [DisplayName("カテゴリー")]
        // public CategoryEnum Category { set; get; }

        [DisplayName("概要")]
        [DataType(DataType.MultilineText)]
        public string Description { set; get; }

        [DisplayName("ビュー数")]
        public int ViewCount { set; get; }

        [DisplayName("公開日")]
        [DisplayFormat(DataFormatString ="{0:yyyy年 MM月 dd日}")]
        public DateTime Published { set; get; }

        [DisplayName("公開済")]
        public bool Released { set; get; }

        //1:nのリレーション
        [DisplayName("コメント")]
        public virtual ICollection<Comment> Comments { set; get; }
}
}