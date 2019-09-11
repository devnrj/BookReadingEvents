using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using Service;
using Web.Helper;
using Web.Models;
using Web.Filters;

namespace Web.Controllers
{
    [UserAuthenticationFilter]
    public class UserController : Controller
    {
        // GET: User
        
        public ActionResult Index()
        {
            if (Session["UserData"] == null)
            {
                return View("Index", "Home");
            }
            else if (((UserViewModel)Session["UserData"]).IsAdmin == true)
            {
                return RedirectToAction("Index", "Event");
            }
            return View((UserViewModel)Session["UserData"]);

        }

        // GET: User/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDto user = UserService.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        // POST: User/Create
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                model.IsAdmin = false;
                model.DateOfCreation = DateTime.Now;
                model.Guid = Guid.NewGuid();
                UserDto user = Mapper.ToUserDto(model);
                if (UserService.UserExists(user.UserAccount) == true)
                {
                    ModelState.AddModelError("user.UserAccount.EmailId", "User with emailid " + user.UserAccount.EmailId + "already exists");
                    return View();
                }
                UserService.CreateUser(user);
                return RedirectToAction("Index", "Home");
            }

            return View();

        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserAccountViewModel uavm)
        {

            UserDto user = UserService.IsValidUser(Mapper.ToUserAccountDto(uavm));
            if (user != null)
            {
                user.UserAccount = null;
                Session["UserData"] = Mapper.ToUserViewModel(user);
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var e in errors)
                {
                    Debug.Write(e.Exception + " " + e.ErrorMessage);
                }

                ModelState.AddModelError("", "Username or password does not match");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]    
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
