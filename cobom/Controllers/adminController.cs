﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cobom.Controllers
{
    [Authorize]
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }
    }
}