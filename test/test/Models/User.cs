using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class User
    {
        //先頭は大文字
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
    }
}