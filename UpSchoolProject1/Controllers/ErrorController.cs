﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UpSchoolProject1.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Page404()
        {
            return View();
        }
    }
}