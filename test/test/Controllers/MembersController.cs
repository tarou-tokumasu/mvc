using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class MembersController : Controller
    {
        private MvCContext db = new MvCContext();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }
        
        public ActionResult LogIn()
        {
            return View();
        }

        //ログアウト
        public ActionResult Logout()
        {
            Session.Remove("login");
            Session.Remove("loginID");
            TempData["success"] = "ログアウトしました";
            return RedirectToAction("Index", "Home");
        }
        //ログイン判定
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Password,Loginid")] Member member)
        {
            //1件取り出したい時に
            var dbMember = db.Members.SingleOrDefault(
                a => a.Loginid == member.Loginid);

            if (dbMember == null)
            {
                Session["test"] = "存在しないID";
                return View();
            }
                else
                {
                //パス認証
                var h = GetHash(dbMember.Rnd + member.Loginid);
                h = GetHash(h + member.Password);

                dbMember = db.Members.SingleOrDefault(
                    a => a.Password == h);

                if (dbMember == null)
                {
                    Session["test"] = "パスワードが違う";
                }
                    else {
                             Session["test"] = "ログイン成功";
                             Session["login"] = dbMember;
                            //TODO:_Layout.cshtmlで@modelが上手く扱えない
                             Session["loginID"] = dbMember.Loginid;

                             //システムメッセージに便利そう
                            TempData["success"] = "ログインに成功しました";
                            //return忘れずに 1つ指定で現在のコントローラー 2つ指定で別のコントローラに
                             return RedirectToAction("Index","Home");
                        }

                
            }

            return View();
        }


            // GET: Members/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Password,Loginid")] Member member)
        {
            if (ModelState.IsValid)
            {
                //ランダム文字列作ってテーブルに保存
                Guid g = System.Guid.NewGuid();
                member.Rnd = g.ToString("N").Substring(0, 8);
                
                //上のランダム+loginIDで暗号化
                var h = GetHash(member.Rnd + member.Loginid);

                //上の暗号化したもの+パスワードで暗号化
                member.Password = GetHash(h + member.Password);
                
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        public string GetHash(string str)
        {
            byte[] byteValues = Encoding.UTF8.GetBytes(str);
            SHA256 crypto256 = new SHA256CryptoServiceProvider();
            byte[] hash256Value = crypto256.ComputeHash(byteValues);

            StringBuilder hashedText = new StringBuilder();
            for (int i = 0; i < hash256Value.Length; i++)
            {
                
                hashedText.AppendFormat("{0:X2}", hash256Value[i]);
            }
            return hashedText.ToString();
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password,Loginid")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
