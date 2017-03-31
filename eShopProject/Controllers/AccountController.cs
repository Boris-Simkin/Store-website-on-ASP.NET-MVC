using AutoMapper;
using DAL;
using DAL.Models;
using eShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace eShopProject.Controllers
{
    public class AccountController : Controller
    {
        UserRepository repository = new UserRepository();

        public ActionResult Registration()
        {
            UserView user = new UserView();
            if (User.Identity.IsAuthenticated)
            {
                User DALUser = repository.Find(User.Identity.Name);
                user = Mapper.Map<User, UserView>(DALUser);
            }
            return View(user);
        }

        public ActionResult AddUser(UserView user)
        {
            User DALUser = Mapper.Map<UserView, User>(user);
            if (!ModelState.IsValid)
                return View("Registration");
            if (!repository.TryRegister(DALUser))
            {
                ModelState.AddModelError(string.Empty, "שם המשתמש תפוס");
                return View("Registration");
            }

            return RedirectToAction("Main","Home");
        }

        public ActionResult UpdateUser(UserView user)
        {
            User DALUser = Mapper.Map<UserView, User>(user);
            if (!ModelState.IsValid)
            {
                return View("Registration");
            }
            repository.Update(DALUser);
            return RedirectToAction("Main", "Home");
        }

        public ActionResult Login(LoginView login)
        {
            if (ModelState.IsValid)
            {
                bool userValid = repository.Login(login.Username, login.Password);

                //Found in the repository
                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie(login.Username, true);
                }
                else
                    ModelState.AddModelError("", "שם המשתמש או הסיסמה לא נכונים");

            }
              return RedirectToAction("Main", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Main", "Home");
        }
    }
}