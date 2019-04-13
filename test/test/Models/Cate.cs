using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Cate
    {
        public int Id { set; get; }
        [Required]
        [DisplayName("カテゴリ名")]
        public string Name { set; get; }
        
        //紐づけ
        public virtual ICollection<Item> Items { set; get; }
    }
}