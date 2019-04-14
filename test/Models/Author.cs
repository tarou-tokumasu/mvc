using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]//not null
        [DisplayName("氏名")]
        public string Name { set; get; }

        [DisplayName("メールアドレス")]
        public string Email { set; get; }

        [DisplayName("生年月日")]
        [DisplayFormat(DataFormatString = "{0:yyyy年 MM月 dd日}")]
        public DateTime Birth { set; get; }
        
        //m:nの関係の時はIColle使う
        [DisplayName("記事")]
        public virtual ICollection<Article> Articles { set; get; }
    }
}