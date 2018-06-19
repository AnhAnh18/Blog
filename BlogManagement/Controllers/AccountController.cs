using BlogManagement.DAL.UnitOfWork;
using BlogManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogManagement.DAL.Entities;
using BlogManagement.BLL;
using System;

namespace BlogManagement.Controllers
{
    public class AccountController : Controller
    {

        private AccountBLL accountBLL;

        public AccountController()
        {
            accountBLL = new AccountBLL(new UnitOfWork(new BlogDBContext()));
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!checkAccount(model))
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác!");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(model.Email, model.Remember);
            return Redirect("/Home/Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (EmailIsExists(model.Email))
            {
                ModelState.AddModelError("", "Email đã tồn tại!");
                return View(model);
            }
            if(model.PassWord != model.ComfirmPass)
            {
                ModelState.AddModelError("", "Mật khẩu không khớp!");
                return View(model);
            }
            if((int)Session["code"] != model.codeVerify)
            {
                ModelState.AddModelError("", "Mã xác thực không đúng!");
                return View(model);
            }
            Account acc = new Account(1, model.Email, model.UserName, model.PassWord, "user_default.png", false, true);
            accountBLL.Add(acc);
            Session.Remove("code");
            return Redirect("/Account/Login");
        }

        [HttpPost]
        public void Send(String email)
        {
            Session["code"] = genCode();
            SendMail(email, (int)Session["code"]);
        }

        public Boolean EmailIsExists(String email)
        {
            Account acc = accountBLL.getByEmail(email);
            if (acc != null)
                return true;
            return false;
        }

        private int genCode()
        {
            return new Random().Next(100000, 1000000);
        }

        private void SendMail(String toEmail, int codeVerify)
        {
            MailMessage mail = new MailMessage("quan.droidvpn@gmail.com", toEmail);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("quan.droidvpn@gmail.com", "quan1997");
            mail.Subject = "Code verify your email.";
            mail.Body = "Your code: " + codeVerify;
            client.Send(mail);
        }

        private Boolean checkAccount(LoginModel model)
        {
            Account acc = accountBLL.getByEmail(model.Email);
            if (acc != null)
                if (acc.PassWord == model.PassWord)
                    return true;
            return false;
        }

        private Boolean AccountConfirmed(String email)
        {
            Account acc = accountBLL.getByEmail(email);
            if(acc != null)
                if (acc.EmailConfirmed)
                    return true;
            return false;
        }

    }
}