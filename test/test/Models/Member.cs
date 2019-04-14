using System;
using System.Collections.Generic;
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
        public string Loginid { set; get; }
        [DataType(DataType.Password)]
        public string Password { set; get; }

        public string Rnd { set; get; }

    }
}