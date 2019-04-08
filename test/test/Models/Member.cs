using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Member
    {
        //db上のカラム名と同じでないと駄目
        public int Id { set; get; }
        public string Name { set; get; }
        //0~255 sqlではtinyint　合わせないとエラー
        public byte Age { set; get; }
        public byte Rnd { set; get; }
        public string Loginid { set; get; }
        public string Password { set; get; }
    }
}