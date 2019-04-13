using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Member
    {
        //db上のカラム名と同じでないと駄目
        public int Id { set; get; }

        [Required]
        [DisplayName("ユーザー名")]
        public string Name { set; get; }

        [DisplayName("ログインID")]
        public string LoginID { set; get; }

        [DisplayName("パスワード")]
        [DataType(DataType.Password)]

        public byte Rnd { set; get; }

        [DisplayName("購入履歴")]
        public virtual ICollection<Item> Items { set; get; }
    }
}