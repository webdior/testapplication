﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace trashminingredux.Controllers
{
    public class HomeController : Controller
    {
      
        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        //public ActionResult Index(Models.RegisterModels m)
        //{
        //   ViewBag.data =  m.getdata();
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}
       [HttpPost]
        public ActionResult Index2View(Models.RegisterModels rmodels, string Uid, string xpos, string ypos, string orientation, string type, string timestamp)
        {
          

            if (Request.Form.Count > 0)
            {

              //  Uid = Convert.ToInt32(Request.Form["Uid"]);
            string a = rmodels.adddata(Uid,xpos,ypos,orientation,type,timestamp);
            ViewBag.result = a;
              // Your Logic here with posted data
            }
            return View();
            //if (ModelState.IsValid)
            //{
            
            //    string a = rmodels.adddata();

            //    ViewBag.result = a;
            //}
            //return View("Index2View",rmodels);

        }
        [HttpGet]
        public ActionResult Index2View()
        {
        // rmodels.adddata();
            return View();
        }
        public ActionResult Index(Models.RegisterModels m)
        {
            if (m.uid > 0)
            {
               // m.adddata();
            }
           
            return View("Index", m);
        }

    }
}
