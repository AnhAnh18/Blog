using BlogManagement.DAL.UnitOfWork;
using BlogManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogManagement.DAL.Entities;

namespace BlogManagement.Controllers
{
    public class AccountController : Controller
    {

        private IUnitOfWork uow;

        public AccountController()
        {
            uow = new UnitOfWork(new BlogDBContext());
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

        public void SendMail(String toEmail, int codeVerify)
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
            Account acc = uow.accountRepository.getByEmail(model.Email);
            if (acc != null)
                if (acc.PassWord == model.PassWord)
                    return true;
            return false;
        }

        private Boolean AccountConfirmed(String email)
        {
            Account acc = uow.accountRepository.getByEmail(email);
            if(acc != null)
                if (acc.EmailConfirmed)
                    return true;
            return false;
        }

    }
}