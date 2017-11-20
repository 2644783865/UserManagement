using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class KYLIELoginController : Controller
    {
        // GET: KYLIELogin
        public ActionResult Index()
        {
            return View(new LoginModels());
        }

        [HttpPost]
        public ActionResult Index(LoginModels login)
        {
            LoginModels result = new LoginModels();
            result = login;
            return RedirectToAction("Success", "KYLIELogin", login);
        }


        public ActionResult Success(LoginModels login)
        {
            // Originates from WinForms.
            if (Request.ServerVariables["HTTP_USER_AGENT"].Contains("WOW64"))
            {
                var results = new SuccessLogin();
                results.user_email = login.user_email;
                results.user_password = login.user_password;
                return View(results);
            }
            else {
                return View();
            }
        }

    }
}