using System;
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
        public ActionResult Index2View(Models.RegisterModels rmodels, string Uid, string xpos, string ypos, string orientation, string type)
        {

            string timestamp = Convert.ToString(DateTime.Now);
           if (Request.Form.Count > 0)
            {

            string a = rmodels.adddata(Uid,xpos,ypos,orientation,type,timestamp);
            ViewBag.result = a;
         
            }
            return View();
          

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
